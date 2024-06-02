using Lab2.DataService;
using Lab2.Models;
using Microsoft.EntityFrameworkCore;

namespace Lab2.Controllers
{
    public class OrderRepository
    {
        private readonly LabContext _context;

        public OrderRepository(LabContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Orders>> GetOrdersBySubjectId(int subjectId)
        {
            return await _context.orders
                                 .Where(order => order.SubjectID == subjectId)
                                 .ToListAsync();
        }
    }
}
