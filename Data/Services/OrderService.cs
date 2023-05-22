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
    }
}
