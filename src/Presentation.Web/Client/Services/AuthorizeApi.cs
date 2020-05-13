using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using UnderTheBrand.Presentation.Web.Shared;

namespace UnderTheBrand.Presentation.Web.Client.Services
{
    public class AuthorizeApi
    {
        private readonly HttpClient httpClient;

        public AuthorizeApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task Login(LoginParameters loginParameters)
        {
            StringContent stringContent = new StringContent(JsonSerializer.Serialize(loginParameters), Encoding.UTF8, "application/json");
            HttpResponseMessage result = await httpClient.PostAsync("api/Authorize/Login", stringContent);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public async Task Logout()
        {
            HttpResponseMessage result = await httpClient.PostAsync("api/Authorize/Logout", null);
            result.EnsureSuccessStatusCode();
        }

        public async Task Register(RegisterParameters registerParameters)
        {
            var stringContent = new StringContent(JsonSerializer.Serialize(registerParameters), Encoding.UTF8, "application/json");
            HttpResponseMessage result = await httpClient.PostAsync("api/Authorize/Register", stringContent);
            if (result.StatusCode == System.Net.HttpStatusCode.BadRequest) throw new Exception(await result.Content.ReadAsStringAsync());
            result.EnsureSuccessStatusCode();
        }

        public Task<UserInfo> GetUserInfo() => httpClient.GetFromJsonAsync<UserInfo>("api/Authorize/UserInfo");
    }
}