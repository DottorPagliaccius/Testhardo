using System.Text.Json.Serialization;

namespace Testhardo;

public class OpenApiDocument
{
    [JsonPropertyName("openapi")]
    public required string Version { get; set; }
    public Dictionary<string, Path> Paths { get; set; } = [];
    public ApiComponents? Components { get; set; }

    public IEnumerable<string> Tags => Paths.Values.SelectMany(x => x.Operations.Values).SelectMany(x => x.Tags).Distinct();

    public class Info
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Version { get; set; }
    }

    public class Path
    {
        public Operation? Get { get; set; }
        public Operation? Post { get; set; }
        public Operation? Put { get; set; }
        public Operation? Delete { get; set; }

        public IDictionary<string, Operation> Operations => new Dictionary<string, Operation?>
        {
            { HttpVerbs.Get, Get },
            { HttpVerbs.Post, Post },
            { HttpVerbs.Put, Put },
            { HttpVerbs.Delete, Delete }
        }.Where(kvp => kvp.Value != null).ToDictionary(kvp => kvp.Key, kvp => kvp.Value!);
    }

    public class Operation
    {
        public List<string> Tags { get; set; } = [];
        public List<Parameter> Parameters { get; set; } = [];
        public Dictionary<string, Response> Responses { get; set; } = [];
    }

    public class Parameter
    {
        public string Name { get; set; }
        public string In { get; set; }
        public Schema Schema { get; set; }
    }

    public class Schema
    {
        public string Type { get; set; }
        public Dictionary<string, Schema> Properties { get; set; } = [];
        public Schema Items { get; set; }

        [JsonPropertyName("$ref")]
        public string Reference { get; set; }
    }

    public class Response
    {
        public string Description { get; set; }
        public Dictionary<string, MediaType> Content { get; set; } = [];
    }

    public class MediaType
    {
        public Schema Schema { get; set; }
    }

    public class ApiComponents
    {
        public Dictionary<string, Schema> Schemas { get; set; } = [];
        public Dictionary<string, Parameter> Parameters { get; set; } = [];
        public Dictionary<string, Response> Responses { get; set; } = [];
    }

    public class SecurityScheme
    {
        public string Type { get; set; } // es: "http", "apiKey", "oauth2"
        public string Scheme { get; set; } // es: "bearer", "basic"
        public string BearerFormat { get; set; } // es: "JWT"
        public string Name { get; set; } // per apiKey
        public string In { get; set; } // "header", "query"
        public OAuthFlows Flows { get; set; }
    }

    public class OAuthFlows
    {
        public OAuthFlow Implicit { get; set; }
        public OAuthFlow Password { get; set; }
        public OAuthFlow ClientCredentials { get; set; }
        public OAuthFlow AuthorizationCode { get; set; }
    }

    public class OAuthFlow
    {
        public string AuthorizationUrl { get; set; }
        public string TokenUrl { get; set; }
        public string RefreshUrl { get; set; }
        public Dictionary<string, string> Scopes { get; set; } = [];
    }
}