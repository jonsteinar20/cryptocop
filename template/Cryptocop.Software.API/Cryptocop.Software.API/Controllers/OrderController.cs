using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/orders")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        // TODO: Setup routes

        // Gets all orders associated with the authenticated user
        [HttpGet]
        [Route("")]
        public IActionResult getAllOrders()
        {
            return Ok(_orderService.GetOrders(User.Identity.Name));
        }

        // Adds a new order associated with the authenticated user
        [HttpPost]
        [Route("")]
        public IActionResult createOrder([FromBody] OrderInputModel order)
        {
            if (ModelState.IsValid)
            {
                _orderService.CreateNewOrder(User.Identity.Name, order);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
    }
}