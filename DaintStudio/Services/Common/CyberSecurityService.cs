
using System.Security.Cryptography;
using System.Text;

namespace DaintStudio.Services.Common;

public class CyberSecurityService
{
    // Helper: derive a fixed 32-byte key from string input (SHA256)
    private static byte[] DeriveKeyFromString(string key)
    {
        using var sha = SHA256.Create();
        return sha.ComputeHash(Encoding.UTF8.GetBytes(key));
    }

    // Encrypt string using AES-GCM with a key (string)
    public static string Encrypt(string plaintext, string key)
    {
        // Convert key (string) → 32 bytes (AES-256)
        byte[] keyBytes = DeriveKeyFromString(key);

        byte[] nonce = new byte[12]; // recommended size for GCM
        RandomNumberGenerator.Fill(nonce);

        byte[] plainBytes = Encoding.UTF8.GetBytes(plaintext);
        byte[] cipherBytes = new byte[plainBytes.Length];
        byte[] tag = new byte[16];

        using var aes = new AesGcm(keyBytes);
        aes.Encrypt(nonce, plainBytes, cipherBytes, tag);

        // Combine: nonce + tag + ciphertext → base64
        byte[] combined = new byte[nonce.Length + tag.Length + cipherBytes.Length];
        Buffer.BlockCopy(nonce, 0, combined, 0, nonce.Length);
        Buffer.BlockCopy(tag, 0, combined, nonce.Length, tag.Length);
        Buffer.BlockCopy(cipherBytes, 0, combined, nonce.Length + tag.Length, cipherBytes.Length);

        return Convert.ToBase64String(combined);
    }

    // Decrypt string using AES-GCM with the same key
    public static string Decrypt(string base64Cipher, string key)
    {
        byte[] keyBytes = DeriveKeyFromString(key);
        byte[] combined = Convert.FromBase64String(base64Cipher);

        byte[] nonce = new byte[12];
        byte[] tag = new byte[16];
        byte[] cipherBytes = new byte[combined.Length - nonce.Length - tag.Length];

        Buffer.BlockCopy(combined, 0, nonce, 0, nonce.Length);
        Buffer.BlockCopy(combined, nonce.Length, tag, 0, tag.Length);
        Buffer.BlockCopy(combined, nonce.Length + tag.Length, cipherBytes, 0, cipherBytes.Length);

        byte[] plainBytes = new byte[cipherBytes.Length];
        using var aes = new AesGcm(keyBytes);
        aes.Decrypt(nonce, cipherBytes, tag, plainBytes);

        return Encoding.UTF8.GetString(plainBytes);
    }

    public static void Test()
    {
        string key = "xxx";  // key bí mật của bạn
        string original = "Đây là dữ liệu nhạy cảm";

        // Encrypt
        string encrypted = Encrypt(original, key);
        Console.WriteLine("Encrypted: " + encrypted);

        // Decrypt
        string decrypted = Decrypt(encrypted, key);
        Console.WriteLine("Decrypted: " + decrypted);
    }

}