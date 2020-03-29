using System.Security.Cryptography;
using System.Text;

namespace AgendaVoluntaria.Api.Utils
{
    public static class SecurityUtils
    {
        public static string EncryptPassword(string password)
        {
            SHA256 sha256Hash = SHA256.Create();

            byte[] data = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
            {
                stringBuilder.Append(data[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }
    }
}
