using LuvCeramicArt.Shop.Helpers;
using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.DTOs;
using Newtonsoft.Json;
using System.Text;

namespace LuvCeramicArt.Shop.Controllers
{
    public class LoginController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly IConfiguration _configuration;
        private readonly string _apiBaseUrl;

        public LoginController(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _configuration = configuration;
            _apiBaseUrl = _configuration["ApiSettings:BaseUrl"];
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string name, string email, string password)
        {
            var tenantId = AppSettingsHelper.GetTenantId();

            var userDto = new UserDto
            {
                FullName = name,
                Email = email,
                Password = password,
                Role = "User"  
            };

            var jsonContent = new StringContent(JsonConvert.SerializeObject(userDto), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_apiBaseUrl}/api/User?tenantId={tenantId}", jsonContent);

            if (response.IsSuccessStatusCode)
            {
                return Json(new { success = true, message = "Kayıt başarılı! Şimdi giriş yapabilirsiniz." });
            }
            else
            {
                return Json(new { success = false, message = "Kayıt başarısız! Lütfen tekrar deneyin." });
            }
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(string email, string password)
        {
            var response = await _httpClient.GetAsync($"{_apiBaseUrl}/api/User?email={email}&password={password}");

            if (!response.IsSuccessStatusCode)
            {
                return Json(new { success = false, message = "Kullanıcı adı veya şifre hatalı!" });
            }

            var jsonString = await response.Content.ReadAsStringAsync();
            var responseData = JsonConvert.DeserializeObject<dynamic>(jsonString);

            return Json(new { success = true, message = responseData.message });
        }

    }
}
