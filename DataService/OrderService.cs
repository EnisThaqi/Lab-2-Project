using Lab2.Controllers;
using Lab2.Models;

namespace Lab2.DataService
{
    public class OrderService
    {
        private readonly OrderRepository _orderRepository;

        public OrderService(OrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Orders>> GetOrdersBySubjectId(int subjectId)
        {
            return await _orderRepository.GetOrdersBySubjectId(subjectId);
        }
    }

}
