using ABDALLAH.Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace ABDALLAH.Controllers
{
    public class PRODUCTController : Controller
    {
        private readonly IProductService _service;

        public PRODUCTController(IProductService service)
        {
            _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var allproduct = await _service.GetAllAsync();
            return View(allproduct);
        }
        public async Task<IActionResult> Filter(string searchString)
        {
            var allMOVIES = await _service.GetAllAsync(n =>n.Orders);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredresult = allMOVIES.Where(n => n.CostumerFullName.Contains(searchString) || n.CotumerCity.Contains(searchString) ||n.Destination.Contains(searchString) || n.NameFR.Contains(searchString) || n.NameAR.Contains(searchString)).ToList();
                return View("Index", filteredresult);
            }
            return View("Index", allMOVIES);
        }
    }
}
