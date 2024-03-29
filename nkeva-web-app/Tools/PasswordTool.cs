﻿using System.Security.Cryptography;
using System.Text;

namespace nkeva_web_app.Tools
{
    public class PasswordTool
    {
        const int keySize = 512;
        const int iterations = 350000;

        public static string HashPassword(string password, out byte[] salt)
        {
            salt = RandomNumberGenerator.GetBytes(keySize);
            var hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations,
                HashAlgorithmName.SHA512,
                keySize);
            return Convert.ToHexString(hash);
        }

        public static bool VerifyPassword(string password, string hash, byte[] salt)
        {
            var hashToCompare = Rfc2898DeriveBytes.Pbkdf2(password, salt, iterations, HashAlgorithmName.SHA512, keySize);
            return hashToCompare.SequenceEqual(Convert.FromHexString(hash));
        }

        public static string GenerateRandomPassword(int len)
        {
            var password = new byte[len];
            RandomNumberGenerator.Fill(password);
            return Convert.ToHexString(password);
        }
    }
}
