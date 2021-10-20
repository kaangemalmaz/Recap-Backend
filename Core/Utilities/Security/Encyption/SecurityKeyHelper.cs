using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Core.Utilities.Security.Encyption
{
    public class SecurityKeyHelper
    {
        public static SecurityKey CreateSecurityKey(string securityKey)
        {
            return new SymmetricSecurityKey(key: Encoding.UTF8.GetBytes(securityKey));
        }
        
    }
}
