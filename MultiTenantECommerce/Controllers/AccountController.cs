using Microsoft.AspNetCore.Mvc;

namespace LuvCeramicArt.Shop.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Account()
        {
            return View();
        }
    }
}
