using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Features.Heshing
{
    public class Heshing : IHeshing
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iteration = 100000;

        private readonly HashAlgorithmName Algoritm = HashAlgorithmName.SHA512;

        public string Hash(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iteration, Algoritm, HashSize);

            return $"{Convert.ToHexString(hash)}-{Convert.ToHexString(salt)}";
        }
    }
}
