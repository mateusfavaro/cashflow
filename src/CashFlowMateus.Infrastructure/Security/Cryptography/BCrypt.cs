using BCrypt.Net;
using CashFlowMateus.Domain.Security.Cryptography;
using BC = BCrypt.Net.BCrypt;

namespace CashFlowMateus.Infrastructure.Security.Cryptography
{
    public class BCrypt : IPasswordEncripter
    {
        public string Encrypt(string password)
        {
            string passwordHash = BC.HashPassword(password);

            return passwordHash;
        }
    }
}
