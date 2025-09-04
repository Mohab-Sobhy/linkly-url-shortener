using linkly_url_shortener.Domain.Interfaces;
using UAParser;

namespace linkly_url_shortener.Infrastructure.Parser;

public class UserAgentParser : IUserAgentParser
{
    private readonly UAParser.Parser _parser;

    public UserAgentParser()
    {
        _parser = UAParser.Parser.GetDefault();
    }
    
    public (string Browser, string OS, string Device) Parse(string userAgent)
    {
        var clientInfo = _parser.Parse(userAgent);

        string browser = $"{clientInfo.UA.Family} {clientInfo.UA.Major}";
        string os = $"{clientInfo.OS.Family} {clientInfo.OS.Major}";
        string device = clientInfo.Device.Family;

        return (browser, os, device);
    }
}