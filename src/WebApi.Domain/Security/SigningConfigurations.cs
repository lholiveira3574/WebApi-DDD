using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;

namespace WebApi.Domain.Security
{
    public class SigningConfigurations
    {
        public SecurityKey Key { get; private set; }
        public SigningCredentials signingCredentials { get; private set; }

        public SigningConfigurations()
        {
            using (var provider = new RSACryptoServiceProvider(2048))
            {
                Key = new RsaSecurityKey(provider.ExportParameters(true));
            }

            signingCredentials = new SigningCredentials(Key, SecurityAlgorithms.RsaSha256Signature);
        }
    }
}