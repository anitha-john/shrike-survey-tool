﻿using Microsoft.Extensions.Caching.Memory;
using Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuthenticationBoundedContext
{
    public class TokenService
    {
        private IMemoryCache memoryCache;
        private readonly TokenAuthOptions tokenOptions;

        /// <summary>
        /// Token service for generation and caching into memory
        /// </summary>
        /// <param name="serviceSettings"></param>
        /// <param name="memoryCache"></param>
        /// <param name="tokenOptions"></param>
        public TokenService(IMemoryCache memoryCache, TokenAuthOptions tokenOptions)
        {
            this.memoryCache = memoryCache;
            this.tokenOptions = tokenOptions;
        }

        /// <summary>
        /// Create a new token , store and return to the user.
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public JwtSecurityToken GetJwtSecurityToken(User user)
        {
            JwtSecurityToken securityToken = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                claims: GetTokenClaims(user),
                expires: DateTime.UtcNow.AddMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["TokenLifetime"])),
                signingCredentials: tokenOptions.SigningCredentials
            );

            // Set the cache in Memory
            memoryCache.Set(securityToken.Id, securityToken,
                new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromMinutes(Convert.ToDouble(ConfigurationManager.AppSettings["SessionTimeout"]))));

            return securityToken;
        }

        private IEnumerable<Claim> GetTokenClaims(User user)
        {
            List<Claim> claims = new List<Claim>
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, user.emailID.ToString()),
                    new Claim("email", user.emailID.ToString()),
                    new Claim("password", user.pwd.ToString()),
                    new Claim("roles", (user.role == Role.admin?0:1).ToString()),
                    new Claim("application", "shrike-survey")
                };


            return claims;
        }
    }
}
