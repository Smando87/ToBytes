using System.Security.Cryptography;
using System.Text;

namespace ToBytes.Extensions;

public static class CryptoExtensions
{
    public static byte[] Encrypt(this byte[] bytes, string password)
    {
        byte[] encryptedData;

        // Convert the password to a byte array using a hash function
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Generate a random key and initialization vector (IV)
            byte[] key = new byte[passwordBytes.Length];
            byte[] iv = new byte[16]{ 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };
            

            // Encrypt the data
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Key = passwordBytes;
                aes.IV = iv;

                var encryptor = aes.CreateEncryptor();

                using (var ms = new System.IO.MemoryStream())
                using (var cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                {
                    cs.Write(bytes, 0, bytes.Length);
                    cs.FlushFinalBlock();

                    encryptedData = ms.ToArray();
                }
            }
        }

        return encryptedData;
    }
    
    public static byte[] Decrypt(this byte[] encryptedBytes, string password)
    {
        byte[] decryptedData;

        // Convert the password to a byte array using a hash function
        using (var sha256 = SHA256.Create())
        {
            byte[] passwordBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

            // Generate a random key and initialization vector (IV)
            byte[] key = new byte[passwordBytes.Length];
            byte[] iv = new byte[16]{ 0x00, 0x01, 0x02, 0x03, 0x04, 0x05, 0x06, 0x07, 0x08, 0x09, 0x0A, 0x0B, 0x0C, 0x0D, 0x0E, 0x0F };

            

            // Decrypt the data
            using (var aes = new AesCryptoServiceProvider())
            {
                aes.Key = passwordBytes;
                aes.IV = iv;

                var decryptor = aes.CreateDecryptor();

                using (var ms = new System.IO.MemoryStream())
                using (var cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Write))
                {
                    cs.Write(encryptedBytes, 0, encryptedBytes.Length);
                    cs.FlushFinalBlock();

                    decryptedData = ms.ToArray();
                }
            }
        }

        return decryptedData;
    }
}