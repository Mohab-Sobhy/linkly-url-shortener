namespace linkly_url_shortener.Domain.Interfaces;

public interface IUserAgentParser
{
    (string Browser, string OS, string Device) Parse(string userAgent);
}