using ABDALLAH.Data.Base;
using ABDALLAH.Data.ViewModels;
using ABDALLAH.Models;

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

        public Task UpdateMovieAsync(NewProductVM data)
        {
            throw new NotImplementedException();
        }
    }
}
