using System;
using System.Security.Cryptography;
using System.Text;

namespace Polyv.SDK.Live
{
    public class PasswordGenerator
    {
        private static readonly char[] Letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
        private static readonly char[] Digits = "1234567890".ToCharArray();
        private static readonly char[] AllChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();

        public static string GenerateRandomPassword(int length)
        {
            if (length < 2)
                throw new ArgumentException("Password length must be at least 2 to include both letters and digits.");

            var password = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                // 确保密码中至少包含一个字母和一个数字
                password.Append(Letters[GetRandomIndex(rng, Letters.Length)]);
                password.Append(Digits[GetRandomIndex(rng, Digits.Length)]);

                // 生成剩余的随机字符
                for (int i = 2; i < length; i++)
                {
                    password.Append(AllChars[GetRandomIndex(rng, AllChars.Length)]);
                }
            }

            // 打乱字符顺序
            return ShufflePassword(password.ToString());
        }

        private static int GetRandomIndex(RandomNumberGenerator rng, int length)
        {
            byte[] randomByte = new byte[1];
            rng.GetBytes(randomByte);
            return randomByte[0] % length;
        }

        private static string ShufflePassword(string password)
        {
            char[] array = password.ToCharArray();
            Random rng = new Random();
            int n = array.Length;
            while (n > 1)
            {
                int k = rng.Next(n--);
                char temp = array[n];
                array[n] = array[k];
                array[k] = temp;
            }
            return new string(array);
        }
    }
}