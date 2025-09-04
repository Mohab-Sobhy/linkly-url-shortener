using System.Security.Cryptography;
using System.Text;
using linkly_url_shortener.Domain.Interfaces;

namespace linkly_url_shortener.Infrastructure.Cryptography;

public class StringHasher : IStringHasher
{
    public byte[] HashToSha256(string s)
    {
        using(SHA256 sha256 = SHA256.Create())
        {
            return sha256.ComputeHash( Encoding.UTF8.GetBytes(s) );
        }
    }
    
    public byte[] HashToSha256(string s, byte[] salt)
    {
        byte[] passBytes = Encoding.UTF8.GetBytes(s);
        byte[] combined = passBytes.Concat(salt).ToArray();

        using (SHA256 sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(combined);
        }
    }
    public static byte[] GetMd5Hash(string input)
    {
        using (MD5 md5 = MD5.Create())
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(input);
            byte[] hashBytes = md5.ComputeHash(inputBytes);
            return hashBytes;
        }
    }
}