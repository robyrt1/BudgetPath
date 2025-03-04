using FinanceApi.Domain.Shared.Interfaces;

namespace FinanceApi.Infra.Services
{
    public class BCryptPasswordHasher : ICryptHash
    {
        public string HashPassword(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password);
        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
    }
}
