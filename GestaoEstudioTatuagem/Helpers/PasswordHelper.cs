using System.Security.Cryptography;
using System.Text;

namespace GestaoEstudioTatuagem.Helpers
{
    public static class PasswordHelper
    {
        public static string HashPassword(string senha)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(senha));

                StringBuilder builder = new StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public static bool VerifyPasswordHash(string senhaDigitada, string senhaHashSalva)
        {
            var hashDaDigitada = HashPassword(senhaDigitada);
            return hashDaDigitada == senhaHashSalva;
        }
    }
}