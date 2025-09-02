namespace linkly_url_shortener.Domain.Interfaces;

public interface IStringHasher
{
    public byte[] HashToSha256(string s);
    public byte[] HashToSha256(string s, byte[] salt);
}