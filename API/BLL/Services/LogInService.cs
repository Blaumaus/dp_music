using System;
using System.Text;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using BLL.DTO;
using BLL.Models;
using BLL.Interfaces;
using System.Linq;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using DAL.Repositories;
using DAL;

namespace BLL.Services
{
    public class LogInService : ILogInService
    {
        private readonly PasswordHasher passwordHasher;
        private readonly UnitOfWork unitOfWork;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IConfiguration _configuration;

        const int notFoundStatusCode = 404;

        public LogInService(dp_musicContext context, IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            passwordHasher = new PasswordHasher();
            unitOfWork = new UnitOfWork(context);
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }
        public RestResponse<bool> LogIn(LogInDto logInDto)
        {
            int expirationTime = Int32.Parse(_configuration["Cookie:ExpirationTime"]);
            var identity = GetIdentity(logInDto);
            if (identity == null)
            {
                return RestResponse<bool>.Fail(notFoundStatusCode, "Invalid username or password!");
            }
            var now = DateTime.UtcNow;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                    issuer: _configuration["Jwt:Issuer"],
                    audience: _configuration["Jwt:Audience"],
                    notBefore: now,
                    claims: identity.Claims,
                    expires: DateTime.UtcNow.AddHours(expirationTime),
                    signingCredentials: signIn);
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            var cookieHelper = new CookieHelper(_httpContextAccessor);
            cookieHelper.SetCookie("jwtToken", encodedJwt, expirationTime);
            return RestResponse<bool>.Success(true);
        }
        private ClaimsIdentity GetIdentity(LogInDto logInDto)
        {
            string hashedPassword = passwordHasher.HashPassword(logInDto.Password);
            var user = unitOfWork.User.Find(x => x.Login == logInDto.Login && x.Password == hashedPassword).FirstOrDefault();
            if (user == null)
            {
                return null;
            }
            var claims = new List<Claim>
            {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, user.Id.ToString()),
            };
            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}
