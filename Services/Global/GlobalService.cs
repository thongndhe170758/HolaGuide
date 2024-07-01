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

        public static double CalculateDistance(double lat1, double lon1, double lat2, double lon2)
        {
            const double earthRadiusKm = 6371; // Radius of the Earth in kilometers

            // Convert latitude and longitude from degrees to radians
            double degToRad = Math.PI / 180;
            double φ1 = lat1 * degToRad;
            double φ2 = lat2 * degToRad;
            double Δφ = (lat2 - lat1) * degToRad;
            double Δλ = (lon2 - lon1) * degToRad;

            // Haversine formula
            double a = Math.Sin(Δφ / 2) * Math.Sin(Δφ / 2) +
                       Math.Cos(φ1) * Math.Cos(φ2) *
                       Math.Sin(Δλ / 2) * Math.Sin(Δλ / 2);
            double c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            double distance = earthRadiusKm * c; // Distance in kilometers

            return distance;
        }

        public static string FromDateToTime(DateTime input)
        {
            var now = DateTime.Now;
            var minute = now.Subtract(input).TotalMinutes;
            if(minute < 1) return "Vừa xong";
            if(minute >= 1 && minute < 60)
            {
                return minute + " phút trước";
            }
            if(minute >= 60 && minute < (60 * 24))
            {
                var hour = Math.Floor(minute / 60);
                return hour + " giờ trước";
            }
            if(minute >= (60 * 24) && minute < (60 * 24 * 30))
            {
                var day = Math.Floor(minute / (60 * 24));
                return day + " ngày trước";
            }
            if(minute >= (60 * 24 * 30) && minute < (60 * 24 * 30 * 12))
            {
                var month = Math.Floor(minute / (60 * 24 * 30));
                return month + " tháng trước";
            }

            var year = Math.Floor(minute / (60 * 24 * 30 * 12));
            return year + " năm trước";
        }

        public static string GetEngCategoryName(int category)
        {
            switch(category)
            {
                case 1:
                    {
                        return "motel";
                    }
                case 2:
                    {
                        return "medical";
                    }
                case 3:
                    {
                        return "entertainment";
                    }
                case 4:
                    {
                        return "shopping";
                    }
                default:
                    {
                        return "others";
                    }
            }
        }
    }
}
