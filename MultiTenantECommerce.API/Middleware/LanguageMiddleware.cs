using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace MultiTenantECommerce.API.Middleware
{
    public class LanguageMiddleware
    {
        private readonly RequestDelegate _next;

        public LanguageMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            // Kullanıcının seçtiği dili çerezden al
            if (context.Request.Cookies.ContainsKey("selectedLanguage"))
            {
                var language = context.Request.Cookies["selectedLanguage"];
                context.Items["Language"] = language;
            }
            else
            {
                // Varsayılan dili "tr" yap ve çerez olarak ekle
                context.Response.Cookies.Append("selectedLanguage", "tr", new CookieOptions
                {
                    Expires = DateTime.Now.AddYears(1)
                });
                context.Items["Language"] = "tr";
            }

            await _next(context); // Sonraki middleware'e geç
        }
    }
}
