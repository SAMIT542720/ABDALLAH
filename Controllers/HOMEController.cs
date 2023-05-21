using Microsoft.AspNetCore.Mvc;

namespace ABDALLAH.Controllers
{
    public class HOMEController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
