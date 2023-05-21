using ABDALLAH.Models;

namespace ABDALLAH.Data.Services
{
    public interface IOrderService
    {
        Task<List<Order>> GetOrdersByUserIDAndRolAsync(string UserID, string userRol);
    }
}
