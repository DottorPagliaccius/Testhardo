namespace Testhardo;

internal class OpenApiParsingException : Exception
{
    public OpenApiParsingException() { }
    public OpenApiParsingException(string? message) : base(message) { }
    public OpenApiParsingException(string? message, Exception? innerException) : base(message, innerException) { }
}