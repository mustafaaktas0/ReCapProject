using Core.Entities.Concrete;
using Core.Utilities.Security;
using Core.Utilities.Security.Encryption;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Core.Extensions;
namespace Core.Utilities.Helper.Security.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        public IConfiguration Configuration { get; }//APi deki appsetiings okumaya yarar sadece readonly
        private TokenOptions _tokenOptions;//okunan değerleri tutmak
        private DateTime _accessTokenExpiration; // oturum suresini tarihe cevirmek için
        public JwtHelper(IConfiguration configuration)
        {
            Configuration = configuration;
            _tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);

        }
        public AccessToken CreateToken(User user ,List<OperationClaim> operationClaims)
        {
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecuriyToken(_tokenOptions, user, signingCredentials, operationClaims);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityTokenHandler.WriteToken(jwt); // token yazdırmak için
            return new AccessToken()
            {
                Token = token,
             Expiration = _accessTokenExpiration
            };
        }

        public JwtSecurityToken CreateJwtSecuriyToken(TokenOptions tokenOptions,User user,SigningCredentials signingCredentials ,List<OperationClaim> operationClaims) // token olusturma
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.Now,
                claims: SetClaims(user, operationClaims),
                signingCredentials: signingCredentials
            );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims) // claim bilgilerini kutuphaneye uygun cevirmek için
        {
            var claims = new List<Claim>();
            claims.AddNameIdentifier(user.Id.ToString()); // claim frameworkunu extension ettik
            claims.AddEmail(user.Email);
            claims.AddName($"{user.FirstName} {user.LastName}");
            claims.AddRoles(operationClaims.Select(c => c.Name).ToArray());

            return claims;
        }
    }
}
