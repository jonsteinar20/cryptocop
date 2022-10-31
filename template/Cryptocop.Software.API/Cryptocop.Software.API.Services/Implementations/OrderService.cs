using System.Collections.Generic;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Services.Interfaces;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class OrderService : IOrderService
    {

        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public IEnumerable<OrderDto> GetOrders(string email)
        {
            _orderRepository.GetOrders(email);
            throw new System.NotImplementedException();
        }

        public void CreateNewOrder(string email, OrderInputModel order)
        {
            _orderRepository.CreateNewOrder(email, order);
            throw new System.NotImplementedException();
        }
    }
}