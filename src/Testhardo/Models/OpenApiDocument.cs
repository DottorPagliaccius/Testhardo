using System.Globalization;
using System.Text.Json;

namespace Testhardo;

public class OpenApiOperation
{
    public string Method { get; set; } = string.Empty;
    public string Path { get; set; } = string.Empty;
    public string OperationId { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public List<OpenApiParameter> Parameters { get; set; } = [];
    public OpenApiRequestBody? RequestBody { get; set; }
    public Dictionary<string, OpenApiResponse> Responses { get; set; } = [];
}

public class OpenApiParameter
{
    public string Name { get; set; } = string.Empty;
    public string In { get; set; } = string.Empty;  // query, path, header, cookie
    public bool Required { get; set; }
    public string Type { get; set; } = string.Empty;
    public string Format { get; set; } = string.Empty;
    public object? MockValue { get; set; }
    public string? Description { get; set; }

    public string? Value { get; set; }

    public bool IsValid => TryGetTypedValue(out _);

    public object? TypedValue
    {
        get
        {
            TryGetTypedValue(out var value);

            return value;
        }
    }

    public bool TryGetTypedValue(out object? value)
    {
        value = null;

        var text = Value?.Trim();

        if (string.IsNullOrEmpty(text))
            return !Required;

        switch (Type.ToLowerInvariant())
        {
            case "string":

                switch (Format.ToLowerInvariant())
                {
                    case "uuid":

                        if (Guid.TryParse(text, out var guid))
                        {
                            value = guid;
                            return true;
                        }
                        return false;

                    case "date":

                        if (DateOnly.TryParse(text, CultureInfo.InvariantCulture, out var date))
                        {
                            value = date;
                            return true;
                        }
                        return false;

                    case "date-time":

                        if (DateTimeOffset.TryParse(text, CultureInfo.InvariantCulture, out var dto))
                        {
                            value = dto;
                            return true;
                        }
                        return false;

                    default:
                        value = text;
                        return true;
                }

            case "integer":

                if (Format.Equals("int64", StringComparison.OrdinalIgnoreCase))
                {
                    if (long.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var longValue))
                    {
                        value = longValue;
                        return true;
                    }

                    return false;
                }

                if (int.TryParse(text, NumberStyles.Integer, CultureInfo.InvariantCulture, out var intValue))
                {
                    value = intValue;
                    return true;
                }

                return false;

            case "number":

                if (Format.Equals("float", StringComparison.OrdinalIgnoreCase))
                {
                    if (float.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var floatValue))
                    {
                        value = floatValue;
                        return true;
                    }

                    return false;
                }

                if (double.TryParse(text, NumberStyles.Float, CultureInfo.InvariantCulture, out var doubleValue))
                {
                    value = doubleValue;
                    return true;
                }

                return false;

            case "boolean":

                if (bool.TryParse(text, out var boolValue))
                {
                    value = boolValue;
                    return true;
                }

                return false;

            default:
                value = text;
                return true;
        }
    }
}

public class OpenApiRequestBody
{
    public string ContentType { get; set; } = "application/json";
    public bool Required { get; set; }
    public string? Schema { get; set; }
    public object? MockData { get; set; }

    public string? Value { get; set; }
    public bool IsValid => Validate(out _);

    public bool Validate(out string? error)
    {
        error = null;

        if (string.IsNullOrWhiteSpace(Value))
        {
            if (Required)
            {
                error = "Body is required";
                return false;
            }

            return true;
        }

        if (!ContentType.Contains("json", StringComparison.OrdinalIgnoreCase))
            return true;

        try
        {
            JsonDocument.Parse(Value);
            return true;
        }
        catch (JsonException ex)
        {
            error = ex.Message;
            return false;
        }
    }
}

public class OpenApiResponse
{
    public string StatusCode { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string ContentType { get; set; } = "application/json";
    public string Schema { get; set; } = string.Empty;
    public object? MockData { get; set; }
}