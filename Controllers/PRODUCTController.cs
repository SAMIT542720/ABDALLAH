using ABDALLAH.Data.Services;
using ABDALLAH.Models;
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
        //public async Task<IActionResult> Filter(string searchString)
        //{
        //    var allMOVIES = await _service.GetAllAsync(n =>n.Orders);
        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        var filteredresult = allMOVIES.Where(n => n.CostumerFullName.Contains(searchString) || n.CotumerCity.Contains(searchString) ||n.Destination.Contains(searchString) || n.NameFR.Contains(searchString) || n.NameAR.Contains(searchString)).ToList();
        //        return View("Index", filteredresult);
        //    }
        //    return View("Index", allMOVIES);
        //}
        public async Task<IActionResult> Details(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);
            if (actordetails == null) { return View("Not Found"); }
            return View(actordetails);
        }
        //Edit actor :update
        public async Task<IActionResult> Edit(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);
            if (actordetails == null)
            {
                return View("Not Found");
            }
            return View(actordetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("CostumerFullName,CotumerCity,CostumerPhoneNumber,PNumber,NameFR,NameAR,Benefit,Price,Description,Destination,Date,ShippingPayment,Statu")] PRODUCT product)
        {

            if (!ModelState.IsValid)
            {
                return View(product);
            }
            await _service.UpdateAsync(id, product);

            return RedirectToAction(nameof(Index));
        }
    }
}
