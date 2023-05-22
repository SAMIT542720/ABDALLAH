using ABDALLAH.Data.Base;
using ABDALLAH.Data.ViewModels;
using ABDALLAH.Models;

namespace ABDALLAH.Data.Services
{
    public interface IProductService:IEntityBaseReprository<PRODUCT>
    {
        Task<PRODUCT> GetMovieByIdAsync(int id);
        Task<NewProductVMdropdown> GetNewMovieDropdownsValuesAsync();
        Task AddNewMovieAsync(NewProductVM data);
        Task UpdateMovieAsync(NewProductVM data);
    }
}
