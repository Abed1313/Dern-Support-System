using Dern_Support_System.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Tunify_Platform.Repositories.Servises
{
    public class JwtTokenServeses
    {
        private IConfiguration _configuration;
        private readonly SignInManager<AppUser> _signInManager;

        public JwtTokenServeses(IConfiguration configuration, SignInManager<AppUser> signInManager)
        {
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            _signInManager = signInManager ?? throw new ArgumentNullException(nameof(signInManager));
        }


        public static TokenValidationParameters ValidateToken(IConfiguration configuration)
        {
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = GetSecurityKey(configuration),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        }
        private static SecurityKey GetSecurityKey(IConfiguration configuration)
        {
            var secretKey = configuration["JWT:SecretKey"];
            if (string.IsNullOrEmpty(secretKey))
            {
                throw new InvalidOperationException("Jwt Secret key is missing or not configured properly.");
            }

            var secretBytes = Encoding.UTF8.GetBytes(secretKey);
            return new SymmetricSecurityKey(secretBytes);
        }


        public async Task<string> GenerateToken(AppUser user, TimeSpan expiryDate)
        {
            var userPrincipal = await _signInManager.CreateUserPrincipalAsync(user);
            if (userPrincipal == null)
            {
                throw new InvalidOperationException("Failed to create user principal.");
            }

            var signingKey = GetSecurityKey(_configuration);
            if (signingKey == null)
            {
                throw new InvalidOperationException("Signing key not configured properly.");
            }

            // Add custom claims
            var claims = new List<Claim>
            {
                new Claim("Email", user.Email),
                new Claim(ClaimTypes.Role, "Admin") // Ensure this matches how roles are added
            };
            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow + expiryDate,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256),
                claims: claims
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
