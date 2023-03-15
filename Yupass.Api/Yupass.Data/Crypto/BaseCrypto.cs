using System.Security.Cryptography;
using System.Text;

namespace Yupass.Data.Crypto;

public class BaseCrypto
{
    public Encoding Encode
    {
        get;
        private set;
    }

    public BaseCrypto() : this(Encoding.Default) { }
    public BaseCrypto(Encoding encoding)
    {
        this.Encode = encoding;
    }

    public string Encrypt(string text)
    {
        byte[] bytes = Encode.GetBytes(text);

        return Convert.ToBase64String(bytes);
    }

    public string Decrypt(string text)
    {
        byte[] bytes = Convert.FromBase64String(text);

        return Encode.GetString(bytes);
    }

    public static string EncryptSha256(string text)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(text));

        StringBuilder builder = new();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }

        return builder.ToString();
    }

}


