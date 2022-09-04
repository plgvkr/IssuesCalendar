using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace WebAPI;

public class AuthOptions
{
    public const string Key = "this is my very long secret key 123456789";

    public const string Audience = "Client";

    public const string Issuer = "Server";
    public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
        new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Key));
}