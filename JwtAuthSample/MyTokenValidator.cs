using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthSample
{
    public class MyTokenValidator : ISecurityTokenValidator
    {
        public bool CanValidateToken => true;//也可以对Token进行验证 判断是否为空之类

        public int MaximumTokenSizeInBytes { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool CanReadToken(string securityToken)
        {
            return true;
        }

        public ClaimsPrincipal ValidateToken(string securityToken, TokenValidationParameters validationParameters, out SecurityToken validatedToken)
        {
            validatedToken = null;

            var identity = new ClaimsIdentity(JwtBearerDefaults.AuthenticationScheme);

            if(securityToken == "abcdefg")
            {
                identity.AddClaim(new Claim("name", "luochuanwei"));
                identity.AddClaim(new Claim("SuperAdminOnly", "true"));
                identity.AddClaim(new Claim(ClaimsIdentity.DefaultRoleClaimType, "user"));
            }

            var principal = new ClaimsPrincipal(identity);

            return principal;
        }
    }
}
