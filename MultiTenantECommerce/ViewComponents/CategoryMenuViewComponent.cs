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
            var categories = await GetCategoriesFromApi();

            if (categories == null || !categories.Any())
                return View(new List<CategoryResponseDto>()); 

            return View(categories);
        }

        private async Task<List<CategoryResponseDto>> GetCategoriesFromApi()
        {
            var languageCode = "tr"; // Kullanıcı dili
            var requestUrl = $"https://localhost:7030/api/Category/tenant/{_tenantConfig.TenantId}/{languageCode}";

            var response = await _httpClient.GetAsync(requestUrl);
            if (!response.IsSuccessStatusCode)
                return new List<CategoryResponseDto>();

            var json = await response.Content.ReadAsStringAsync();
            var categories = JsonSerializer.Deserialize<List<CategoryResponseDto>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<CategoryResponseDto>();

            return categories;
        }
    }
}
