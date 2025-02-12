using Microsoft.AspNetCore.Mvc;
using MultiTenantECommerce.Application.Config;
using MultiTenantECommerce.Application.DTOs;
using System.Text.Json;

namespace LuvCeramicArt.Shop.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly HttpClient _httpClient;
        private readonly TenantConfig _tenantConfig;

        public CategoryMenuViewComponent(HttpClient httpClient, TenantConfig tenantConfig)
        {
            _httpClient = httpClient;
            _tenantConfig = tenantConfig;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var languageCode = GetLanguageFromCookie();
            var categories = await GetCategoriesFromApi(languageCode);

            if (categories == null || !categories.Any())
                return View(new List<CategoryResponseDto>());

            return View(categories);
        }

        private string GetLanguageFromCookie()
        
        {
            var cookieValue = HttpContext.Request.Cookies["selectedLanguage"];
            return !string.IsNullOrEmpty(cookieValue) ? cookieValue : "tr"; 
        }

        private async Task<List<CategoryResponseDto>> GetCategoriesFromApi(string languageCode)
        {
            var requestUrl = $"https://localhost:7030/api/Category/tenant/{_tenantConfig.TenantId}/{languageCode}";

            var response = await _httpClient.GetAsync(requestUrl);
            if (!response.IsSuccessStatusCode)
                return new List<CategoryResponseDto>();

            var json = await response.Content.ReadAsStringAsync();
            return JsonSerializer.Deserialize<List<CategoryResponseDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CategoryResponseDto>();
        }
    }
}
