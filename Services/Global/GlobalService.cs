using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Services.Global
{
    public static class GlobalService
    {
        public static string HashPassword(string password)
        {
            // Convert the password string to bytes
            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);

            // Compute the MD5 hash
            using (MD5 md5 = MD5.Create())
            {
                byte[] hashBytes = md5.ComputeHash(passwordBytes);

                // Convert the hash bytes to a hexadecimal string
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2"));
                }

                return sb.ToString();
            }
        }

        public static bool VerifyPassword(string enteredPassword, string storedEncryptedPassword)
        {
            // Hash the entered password using MD5
            string hashedEnteredPassword = HashPassword(enteredPassword);

            // Compare the hashed version of the entered password with the stored encrypted password
            return hashedEnteredPassword == storedEncryptedPassword;
        }
    }
}
