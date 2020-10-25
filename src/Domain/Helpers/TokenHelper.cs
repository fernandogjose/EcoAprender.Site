using System;
using System.Linq;

namespace Domain.Helpers
{
    public static class TokenHelper
    {
        public static string Create()
        {
            var time = BitConverter.GetBytes(DateTime.UtcNow.ToBinary());
            var key = Guid.NewGuid().ToByteArray();
            var token = Convert.ToBase64String(time.Concat(key).ToArray());

            return token;
        }

        public static bool Validate(string token)
        {
            var data = Convert.FromBase64String(token);
            var when = DateTime.FromBinary(BitConverter.ToInt64(data, 0));
            return when >= DateTime.UtcNow.AddHours(-24);
        }

        public static int CreateTokenForForgetPassword()
        {
            var randNum = new Random();
            var token = randNum.Next(1000, 999999);
            return token;
        }
    }
}
