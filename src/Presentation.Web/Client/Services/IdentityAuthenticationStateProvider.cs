using System;
using System.Linq;
using System.Net.Http;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Authorization;
using UnderTheBrand.Presentation.Web.Shared;

namespace UnderTheBrand.Presentation.Web.Client.Services
{
    public class IdentityAuthenticationStateProvider : AuthenticationStateProvider
    {
        private UserInfo? userInfoCache;
        private readonly AuthorizeApi authorizeApi;

        public IdentityAuthenticationStateProvider(AuthorizeApi authorizeApi)
        {
            this.authorizeApi = authorizeApi;
        }

        public async Task Login(LoginParameters loginParameters)
        {
            await authorizeApi.Login(loginParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Register(RegisterParameters registerParameters)
        {
            await authorizeApi.Register(registerParameters);
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public async Task Logout()
        {
            await authorizeApi.Logout();
            userInfoCache = null;
            NotifyAuthenticationStateChanged(GetAuthenticationStateAsync());
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            try
            {
                var userInfo = await GetUserInfo();
                if (userInfo.IsAuthenticated)
                {
                    var claims = new[] { new Claim(ClaimTypes.Name, userInfoCache.UserName) }.Concat(userInfoCache.ExposedClaims.Select(c => new Claim(c.Key, c.Value)));
                    identity = new ClaimsIdentity(claims, "Server authentication");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Request failed:" + ex.ToString());
            }

            return new AuthenticationState(new ClaimsPrincipal(identity));
        }

        private async Task<UserInfo> GetUserInfo()
        {
            if (userInfoCache != null && userInfoCache.IsAuthenticated) return userInfoCache;
            userInfoCache = await authorizeApi.GetUserInfo();
            return userInfoCache;
        }
    }
}
