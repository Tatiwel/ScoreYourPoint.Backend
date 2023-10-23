using System.Security.Cryptography;
using System.Text;

namespace ScoreYourPoint.Infra.Utils.Cryptography
{
    public static class Cryptography
    {
        public static string GenerateHash(this string password)
        {
            var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            return Encoding.UTF8.GetString(hashedBytes);
        }

        public static bool CompareHash(this string password, string hash)
        {
            var hashedBytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));
            var hashedPassword = Encoding.UTF8.GetString(hashedBytes);
            return hashedPassword == hash;
        }
    }
}
