using System.Text;
using System.Security.Cryptography;

namespace RockPaperScissors
{
    internal class RandomKey_HMAC
    {
        public string Key()
        {
            byte[] RandomValue = new byte[32];
            RandomNumberGenerator RndGen = RandomNumberGenerator.Create();
            RndGen.GetBytes(RandomValue);

            string doi = BitConverter.ToString(RandomValue).Replace("-", "").ToLower();
            return doi;
        }
        public string HMACHASH(string choice, string key)
        {
            var shaKeyBytes = Encoding.UTF8.GetBytes(key);
            var shaAlgorithm = new HMACSHA256(shaKeyBytes);
            {
                var signatureBytes = Encoding.UTF8.GetBytes(choice);
                var signatureHashBytes = shaAlgorithm.ComputeHash(signatureBytes);
                var signatureHashHex = string.Concat(Array.ConvertAll(signatureHashBytes, b => b.ToString("X2"))).ToLower();
                return signatureHashHex;
            }
        }
    }
}
