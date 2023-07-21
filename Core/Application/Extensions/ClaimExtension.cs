using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Application.Extensions
{
    public static class ClaimExtension
    {
        public static void AddNameIdentitfier(this ICollection<Claim> claim, string nameIdentitfier)
        {
            claim.Add(new Claim(ClaimTypes.NameIdentifier, nameIdentitfier));
        }
        public static void AddEmail(this ICollection<Claim> claims, string email)
        {
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, email));
        }

        public static void AddName(this ICollection<Claim> claims, string name)
        {
            claims.Add(new Claim(ClaimTypes.Name, name));
        }

        public static void AddRoles(this ICollection<Claim> claims, string[] roles)
        {
            roles.ToList().ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role)));
        }

    }
}
