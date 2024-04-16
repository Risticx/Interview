using System.Security.Cryptography;
using System.Text;

namespace Application.Validator
{
    public class HashValidator
    {
        private string? SecretKey = Environment.GetEnvironmentVariable("SECRET_KEY");
        public HashValidator(){}

        public string ValidateHash(string externalTransactionId, string userId, decimal amount, string currency) 
        {

            if (SecretKey == null)
            {
                throw new InvalidOperationException("SecretKey is not set.");
            } 

            string payload = $"{externalTransactionId}{userId}{amount}{currency}";
            byte[] secretKeyBytes = Encoding.UTF8.GetBytes(SecretKey!);

            using (HMACSHA256 hmac = new HMACSHA256(secretKeyBytes))
            {
                byte[] payloadBytes = Encoding.UTF8.GetBytes(payload);
                byte[] hashBytes = hmac.ComputeHash(payloadBytes);

                return Convert.ToBase64String(hashBytes);
            }
        }

    }
}