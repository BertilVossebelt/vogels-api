using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;

namespace vogels_api.Services;

public class JwtService
{
    private readonly string _secureKey;

    public JwtService(IConfiguration configuration) {
        _secureKey = configuration.GetSection("SecureKey").Value;
    }
    
    public string Generate(int id)
    {
        var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secureKey));
        var credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha384Signature);
        var header = new JwtHeader(credentials);
        
        var expiry = DateTime.Today.AddDays(1);
        var payload = new JwtPayload(id.ToString(), null, null, null, expiry);
        var securityToken = new JwtSecurityToken(header, payload);

        return new JwtSecurityTokenHandler().WriteToken(securityToken);
    }

    public JwtSecurityToken Verify(string jwt)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_secureKey);
        tokenHandler.ValidateToken(jwt, new TokenValidationParameters
        {
           IssuerSigningKey = new SymmetricSecurityKey(key),
           ValidateIssuerSigningKey = true,
           ValidateIssuer = false,
           ValidateAudience = false,
        }, out SecurityToken validatedToken);

        return (JwtSecurityToken) validatedToken;
    }
}