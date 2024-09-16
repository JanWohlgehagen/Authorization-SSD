using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Enums;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace JWT.Services
{
    public class JwtTokenService
    {
        private readonly IConfiguration _configuration;

        public JwtTokenService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string CreateTokenWithAttributes(List<Permissions> permissisons)
        {
            // Define user claims for the token
            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, "user_id_123"), // Unique identifier for the user
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) // Token ID
            };

            // Add custom attributes (like permissions) as claims
            foreach (var permission in permissisons)
            {
                claims.Add(new Claim("permissions", permission.ToString()));
            }

            // Create signing credentials using a symmetric security key
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Set the token expiration time
            var expiration = DateTime.UtcNow.AddMinutes(30);

            // Create the JWT token
            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: expiration,
                signingCredentials: creds
            );

            // Return the serialized token
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}