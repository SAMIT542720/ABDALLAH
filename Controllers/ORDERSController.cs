using ABDALLAH.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ABDALLAH.Controllers
{
    
    public class ORDERSController : Controller
    {
        private readonly IOrderService _orderService;
        public ORDERSController(IOrderService orderService)
        {
            _orderService = orderService;
        }
        public async Task<IActionResult> Index()
        {
            return View("Index");
        }
        //search for an order 
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMOVIES = await _orderService.
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredresult = allMOVIES.Where(n => n.Name.Contains(searchString) || n.Description.Contains(searchString)).ToList();
                return View("Index", filteredresult);
            }
            return View("Index", allMOVIES);
        }
    }
}
