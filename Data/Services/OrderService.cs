using ABDALLAH.Models;
using Microsoft.EntityFrameworkCore;

namespace ABDALLAH.Data.Services
{
    public class OrderService:IOrderService
    {
        private readonly AppDbContext _context;
        public OrderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersByUserIDAndRolAsync(string UserID, string userRol)
        {
            var orders = await _context.Orders.Include(n => n.PRODUCTS).ToListAsync();
            if (userRol != "admin")
            {
                orders = orders.Where(n => n.UserID == UserID).ToList();
            }
            return orders;
        }
    }
}
