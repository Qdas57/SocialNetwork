using Microsoft.IdentityModel.Tokens;
using SocialNetwork.Core;
using SocialNetwork.Models.Output;
using SocialNetwork.Services.Repositories;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.Services.Services
{
    public class UserService
    {
        private UserRepository _userRepository;

        private RefreshTokenRepository _refreshTokenRepository;

        public UserService(UserRepository userRepository, RefreshTokenRepository refreshTokenRepository)
        {
            _userRepository = userRepository;
            _refreshTokenRepository = refreshTokenRepository;
        }
        /// <summary>
        /// Метод проведёт аутентификацию пользователя.
        /// </summary>
        /// <param name="email">Емейл.</param>
        /// <param name="password">Пароль.</param>
        /// <returns>Данные пользователя после аутентификации: токены.</returns>
        public async Task<LoginResult> AuthenticateUserAsync(string email, string password)
        {
            UserOutput? findedUser = await _userRepository.IdentityUserAsync(email, password);

            if (findedUser is null)
            {
                throw new ArgumentException($"Пользователя с таким емейлом и паролем не найдено!");
            }

            // удалим все старые токены пользователя
            await _refreshTokenRepository.DeleteAllAsync(findedUser.UserId);

            var claimsIdentity = GetClaimsIdentity(findedUser);

            var accessToken = GenerateAccessToken(claimsIdentity.Claims);

            var refreshToken = GenerateRerfreshToken();

            await _refreshTokenRepository.CreateAsync(refreshToken, findedUser.UserId);

            return new LoginResult
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken
            };
        }

        private ClaimsIdentity GetClaimsIdentity(UserOutput user)
        {
            var claims = new List<Claim>
            {
                new Claim("userId",user.UserId.ToString()),
                new Claim("username", user.FirstName),
                new Claim("email", user.Email),
            };

            return new ClaimsIdentity(claims, "JwtToken", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
        }
        
        private string GenerateAccessToken(IEnumerable<Claim> claims)
        {
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AccessTokenOptions.ISSUER,
                    audience: AccessTokenOptions.AUDIENCE,
                    notBefore: now,
                    claims: claims,
                    expires: now.AddMinutes(AccessTokenOptions.LIFETIME),
                    signingCredentials: new SigningCredentials(AccessTokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            string accessToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return accessToken;
        }

        private string GenerateRerfreshToken()
        {
            var now = DateTime.UtcNow;
            // создаем JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: RefreshTokenOptions.ISSUER,
                    audience: RefreshTokenOptions.AUDIENCE,
                    notBefore: now,
                    claims: null,
                    expires: now.AddMinutes(RefreshTokenOptions.LIFETIME),
                    signingCredentials: new SigningCredentials(RefreshTokenOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            string refreshToken = new JwtSecurityTokenHandler().WriteToken(jwt);

            return refreshToken;
        }
    }
}
