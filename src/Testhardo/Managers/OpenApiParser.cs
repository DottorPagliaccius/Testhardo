using Bogus;
using Microsoft.OpenApi.Models;
using Microsoft.OpenApi.Readers;
using System.Text;
using System.Text.Json;

namespace Testhardo;

public class OpenApiParser
{
    private readonly Faker _faker = new();
    private readonly HttpClient _httpClient;

    public OpenApiParser(HttpClient? httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
    }

    public async Task<List<OpenApiOperation>> ParseAsync(string source)
    {
        await using var stream = IsUrl(source) ? await DownloadOpenApiAsync(source) : await GetFileStreamAsync(source);

        return await ParseStreamAsync(stream);
    }

    private static bool IsUrl(string source)
    {
        return Uri.TryCreate(source, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeHttps);
    }

    private async Task<Stream> DownloadOpenApiAsync(string url)
    {
        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var content = await response.Content.ReadAsByteArrayAsync();

        return new MemoryStream(content);
    }

    private async Task<Stream> GetFileStreamAsync(string filePath)
    {
        if (!File.Exists(filePath))
            throw new FileNotFoundException($"OpenAPI file not found: {filePath}");

        var extension = Path.GetExtension(filePath).ToLower();

        if (extension is ".yaml" or ".yml")
            return await ConvertYamlToJsonStreamAsync(filePath);

        return File.OpenRead(filePath);
    }

    private async Task<Stream> ConvertYamlToJsonStreamAsync(string yamlFilePath)
    {
        var yamlContent = await File.ReadAllTextAsync(yamlFilePath);
        var deserializer = new YamlDotNet.Serialization.Deserializer();
        var yamlObject = deserializer.Deserialize<object>(yamlContent);

        var serializer = new YamlDotNet.Serialization.SerializerBuilder().JsonCompatible().Build();

        var json = serializer.Serialize(yamlObject);

        return new MemoryStream(Encoding.UTF8.GetBytes(json));
    }

    private async Task<List<OpenApiOperation>> ParseStreamAsync(Stream stream)
    {
        var operations = new List<OpenApiOperation>();

        var reader = new OpenApiStreamReader();

        var result = await reader.ReadAsync(stream);

        var document = result.OpenApiDocument;
        var diagnostic = new OpenApiDiagnostic();

        if (diagnostic.Errors.Count > 0)
        {
            var errors = string.Join("\n", diagnostic.Errors.Select(e => $"- {e.Message}"));
            throw new OpenApiParsingException($"OpenAPI parsing errors:\n{errors}");
        }

        foreach (var path in document.Paths)
        {
            foreach (var operation in path.Value.Operations)
            {
                var apiOperation = new OpenApiOperation
                {
                    Method = operation.Key.ToString().ToUpper(),
                    Path = path.Key,
                    OperationId = operation.Value.OperationId ?? $"{operation.Key}_{path.Key.Replace("/", "_")}",
                    Summary = operation.Value.Summary ?? operation.Value.Description ?? string.Empty
                };

                // Parametri (query, path, header)
                if (operation.Value.Parameters != null)
                {
                    foreach (var parameter in operation.Value.Parameters)
                    {
                        apiOperation.Parameters.Add(new OpenApiParameter
                        {
                            Name = parameter.Name,
                            In = parameter.In.ToString().ToLower(),
                            Required = parameter.Required,
                            Type = parameter.Schema?.Type ?? "string",
                            Format = parameter.Schema?.Format ?? string.Empty,
                            Description = parameter.Description,
                            MockValue = GenerateMockValue(parameter.Schema)
                        });
                    }
                }

                if (operation.Value.RequestBody != null)
                {
                    var content = operation.Value.RequestBody.Content.FirstOrDefault();
                    if (content.Value != null)
                    {
                        apiOperation.RequestBody = new OpenApiRequestBody
                        {
                            ContentType = content.Key,
                            Required = operation.Value.RequestBody.Required,
                            Schema = JsonSerializer.Serialize(content.Value.Schema, new JsonSerializerOptions { WriteIndented = true }),
                            MockData = GenerateMockFromSchema(content.Value.Schema)
                        };
                    }
                }

                foreach (var response in operation.Value.Responses)
                {
                    var content = response.Value.Content.FirstOrDefault();

                    apiOperation.Responses[response.Key] = new OpenApiResponse
                    {
                        StatusCode = response.Key,
                        Description = response.Value.Description ?? string.Empty,
                        ContentType = content.Key ?? "application/json",
                        Schema = content.Value != null
                            ? JsonSerializer.Serialize(content.Value.Schema, new JsonSerializerOptions { WriteIndented = true })
                            : string.Empty,
                        MockData = content.Value != null
                            ? GenerateMockFromSchema(content.Value.Schema)
                            : null
                    };
                }

                operations.Add(apiOperation);
            }
        }

        return operations;
    }

    private object? GenerateMockValue(OpenApiSchema? schema)
    {
        if (schema == null) return null;

        if (schema.Example != null)
        {
            return schema.Example;
        }

        if (schema.Enum?.Count > 0)
        {
            return schema.Enum[0];
        }

        return schema.Type switch
        {
            "string" => GenerateStringMock(schema.Format),
            "integer" => schema.Format == "int64" ? _faker.Random.Long(1, 1000) : _faker.Random.Int(1, 1000),
            "number" => schema.Format == "double" ? _faker.Random.Double(1, 1000) : _faker.Random.Float(1, 1000),
            "boolean" => _faker.Random.Bool(),
            "array" => GenerateArrayMock(schema),
            "object" => GenerateMockFromSchema(schema),
            _ => null
        };
    }

    private string GenerateStringMock(string? format) => format switch
    {
        "date" => _faker.Date.Recent().ToString("yyyy-MM-dd"),
        "date-time" => _faker.Date.Recent().ToString("O"),
        "email" => _faker.Internet.Email(),
        "uri" => _faker.Internet.Url(),
        "uuid" => Guid.NewGuid().ToString(),
        "hostname" => _faker.Internet.DomainName(),
        "ipv4" => _faker.Internet.Ip(),
        "ipv6" => _faker.Internet.Ipv6(),
        _ => _faker.Lorem.Word()
    };

    private object GenerateArrayMock(OpenApiSchema schema)
    {
        var items = new List<object?>();
        var count = schema.MinItems ?? 2;

        for (int i = 0; i < count; i++)
        {
            items.Add(GenerateMockValue(schema.Items));
        }

        return items;
    }

    private object? GenerateMockFromSchema(OpenApiSchema? schema)
    {
        if (schema == null) return null;

        if (schema.Example != null)
        {
            return schema.Example;
        }

        if (schema.Type == "array")
        {
            return GenerateArrayMock(schema);
        }

        if (schema.Type == "object" || schema.Properties?.Count > 0)
        {
            var obj = new Dictionary<string, object?>();

            foreach (var property in schema.Properties ?? new Dictionary<string, OpenApiSchema>())
            {
                obj[property.Key] = GenerateMockValue(property.Value);
            }

            return obj;
        }

        // Se ha allOf, anyOf, oneOf
        if (schema.AllOf?.Count > 0)
        {
            var merged = new Dictionary<string, object?>();
            foreach (var subSchema in schema.AllOf)
            {
                if (GenerateMockFromSchema(subSchema) is Dictionary<string, object?> dict)
                {
                    foreach (var kvp in dict)
                    {
                        merged[kvp.Key] = kvp.Value;
                    }
                }
            }

            return merged;
        }

        if (schema.AnyOf?.Count > 0)
        {
            return GenerateMockFromSchema(schema.AnyOf.First());
        }

        if (schema.OneOf?.Count > 0)
        {
            return GenerateMockFromSchema(schema.OneOf.First());
        }

        return GenerateMockValue(schema);
    }
}