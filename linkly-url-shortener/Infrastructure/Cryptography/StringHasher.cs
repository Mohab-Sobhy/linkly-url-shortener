using System.Security.Cryptography;
using System.Text;

namespace linkly_url_shortener.Utils;

public class StringHasher
{
    public static byte[] HashToSha256(string s)
    {
        using(SHA256 sha256 = SHA256.Create())
        {
            return sha256.ComputeHash( Encoding.UTF8.GetBytes(s) );
        }
    }
    
    public static byte[] HashToSha256(string s, byte[] salt)
    {
        byte[] passBytes = Encoding.UTF8.GetBytes(s);
        byte[] combined = passBytes.Concat(salt).ToArray();

        using (SHA256 sha256 = SHA256.Create())
        {
            return sha256.ComputeHash(combined);
        }
    }

}