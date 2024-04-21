using System.IdentityModel.Tokens.Jwt;

using System;
using Microsoft.IdentityModel.Tokens;

namespace CarModelManagement.Configuration
{
  
    public class JwtHelper
    {
        public static bool IsTokenExpired(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            try
            {
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken;

                if (jwtToken == null)
                {
                    return true; // Token couldn't be parsed, consider it expired
                }

                var expiryTime = jwtToken.ValidTo;

                if (expiryTime == null)
                {
                    return true; // Expiry time not set, consider it expired
                }

                return expiryTime <= DateTime.UtcNow;
            }
            catch (Exception)
            {
                // Exception occurred while parsing the token, consider it expired
                return true;
            }
        }
    }

}
