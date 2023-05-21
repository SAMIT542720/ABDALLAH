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
            string userid = User.FindFirstValue(ClaimTypes.NameIdentifier);
            string userRole = User.FindFirstValue(ClaimTypes.Role);
            var orders = await _orderService.GetOrdersByUserIDAndRolAsync(userid, userRole);
            return View(orders);
        }
    }
}
