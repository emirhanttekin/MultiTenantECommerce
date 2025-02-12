using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;

public class LanguageController : Controller
{
    public IActionResult ChangeLanguage(string culture)
    {
        Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
            CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
            new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) });

        // Eğer Referer yoksa ana sayfaya yönlendir.
        var returnUrl = Request.Headers["Referer"].ToString();
        if (string.IsNullOrEmpty(returnUrl))
        {
            return RedirectToAction("Index", "Home");
        }

        return Redirect(returnUrl);
    }
}
