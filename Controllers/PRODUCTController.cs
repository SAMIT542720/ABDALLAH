using ABDALLAH.Data.Services;
using ABDALLAH.Data.ViewModels;
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
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _service.GetAllAsync(n => n.Orders);
            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredresult = allProducts.Where(n => n.CostumerFullName.Contains(searchString) || n.CotumerCity.Contains(searchString) || n.Destination.Contains(searchString) || n.NameFR.Contains(searchString) || n.NameAR.Contains(searchString)).ToList();
                return View("Index", filteredresult);
            }
            return View("Index", allProducts);
        }
        public async Task<IActionResult> Details(int id)
        {
            var actordetails = await _service.GetByIdAsync(id);
            if (actordetails == null) { return View("Not Found"); }
            return View(actordetails);
        }
        //Edit actor :update
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM data)
        {
            if (id != data.ID)
            {
                return View("Not Found");
            }
            await _service.UpdateMovieAsync(data);
            return RedirectToAction(nameof(Index));
        }
        //DELETING AN ORDER
        public async Task<IActionResult> Delete(int id)
        {
            var pdatails = await _service.GetByIdAsync(id);
            if (pdatails == null) return View("NotFound");
            return View(pdatails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pdatails = await _service.GetByIdAsync(id);
            if (pdatails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
        //add new product.
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("CostumerFullName,CotumerCity, CostumerPhoneNumber,PNumber,NameFR,NameAR,Benefit,Price, Description,Destination,Date,ShippingPayment,Statu")] PRODUCT prosuct)
        {
            if (!ModelState.IsValid)
            {
                return View(prosuct);
            }
            await _service.AddAsync(prosuct);
            return RedirectToAction(nameof(Index));
        }
    }
}
