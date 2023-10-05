using ABDALLAH.Data.Base;
using ABDALLAH.Data.ViewModels;
using ABDALLAH.Models;
using Microsoft.EntityFrameworkCore;

namespace ABDALLAH.Data.Services
{
    public class ProductService : EntityBaseRepository<PRODUCT>, IProductService
    {
        private readonly AppDbContext _context;
        public ProductService(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task AddNewMovieAsync(NewProductVM data)
        {
            throw new NotImplementedException();
        }

        public Task<PRODUCT> GetMovieByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<NewProductVMdropdown> GetNewMovieDropdownsValuesAsync()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateMovieAsync(NewProductVM data)
        {
            var dbmovie = await _context.PRODUCTS.FirstOrDefaultAsync(n => n.ID == data.ID);
            if (dbmovie != null)
            {

                dbmovie.CostumerFullName = data.CostumerFullName;
                dbmovie.CotumerCity = data.CotumerCity;
                dbmovie.CostumerPhoneNumber = data.CostumerPhoneNumber;
                dbmovie.PNumber = data.PNumber;
                dbmovie.NameFR = data.NameFR;
                dbmovie.NameAR = data.NameAR;
                dbmovie.Benefit = data.Benefit;
                dbmovie.Price = data.Price;
                dbmovie.Description = data.Description;
                dbmovie.Destination = data.Destination;
                dbmovie.Date = data.Date;
                dbmovie.ShippingPayment = data.ShippingPayment;
                dbmovie.Statu = data.Statu;
                await _context.SaveChangesAsync();
            }
        }
    }
}
