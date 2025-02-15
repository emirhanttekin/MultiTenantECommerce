using Microsoft.AspNetCore.Mvc;

namespace LuvCeramicArt.Shop.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
