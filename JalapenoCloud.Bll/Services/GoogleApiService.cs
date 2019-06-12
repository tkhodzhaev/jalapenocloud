using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens;
using System.Linq;
using System.Net;
using System.Security.Claims;
using ComfortFramework.Core.Extenders;
using JalapenoCloud.Common.Helpers;
using JalapenoCloud.Dal.Domain.Enums;
using Microsoft.IdentityModel.Tokens.JWT;

namespace JalapenoCloud.Bll.Services
{
    public static class GoogleApiService
    {
        public static string GetUserIdByToken(string token)
        {
            var service = new SettingService();
            string uriTemplate = service.GetDbSetting<string>(DbSettingKey.TokenValidationUriTemplate);
            string uri = uriTemplate.Parameters(token);

            var web = new WebClient();
            string json = web.DownloadString(uri);

            string googleId = JsonHelper.FindJProperty(json, "id");

            return googleId;
        }

        public static string GetUserIdByJwt(string jwt, out string userEmail)
        {
            userEmail = string.Empty;
            var service = new SettingService();
            string userId = null;

            //Секретный Client ID веб сервиса.
            string audience = service.GetDbSetting<string>(DbSettingKey.Audience);

            //Секретный Client ID приложения.
            string[] azp = service.GetDbSetting<string>(DbSettingKey.Azp).Split(new []{";"},StringSplitOptions.RemoveEmptyEntries);

            var tokenHandler = new JWTSecurityTokenHandler();
            SecurityToken securityToken = tokenHandler.ReadToken(jwt);
            var jwtSecurityToken = securityToken as JWTSecurityToken;

            userEmail = GetClaimValue(jwtSecurityToken, "email");
            userId = GetClaimValue(jwtSecurityToken, "id");
            var sub = GetClaimValue(jwtSecurityToken, "sub");
            if (string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(sub))
            {
                userId = sub;
            }

            var validationParameters =
                new TokenValidationParameters()
                {
                    AllowedAudience = audience,
                    ValidIssuer = "accounts.google.com",
                    ValidateExpiration = true,
                    ValidateSignature = false,
                };

            try
            {
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(jwtSecurityToken, validationParameters);
                bool allGood = ValidateClaim(jwtSecurityToken, "azp", azp) && ValidateClaim(jwtSecurityToken, "aud", audience);
                if (!allGood)
                {
                    userId = null;
                }
            }
            catch(Exception ex)
            {
                userId = null;
                NotificationAndLogService.LogException("Error while resolving googleId", ex);
            }

            return userId;
        }

        private static bool ValidateClaim(JWTSecurityToken securityToken, string type, string value)
        {
            string claim = GetClaimValue(securityToken, type);

            if (claim == null)
                return false;

            return claim == value;
        }

        private static bool ValidateClaim(JWTSecurityToken securityToken, string type, IEnumerable<string> values)
        {
            string claim = GetClaimValue(securityToken, type);
            if (claim == null)
                return false;

            return values.Contains(claim);
        }

        private static string GetClaimValue(JWTSecurityToken securityToken, string type)
        {
            var claim = securityToken.Claims.SingleOrDefault(x => x.Type == type);

            if (claim == null)
                return null;

            return claim.Value;
        }
    }
}