using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private IPaymentService _paymentService;

        public PaymentController(IPaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        // TODO: Setup routes

        // Gets all payment cards associated with the authenticated user
        [HttpGet]
        [Route("")]
        public IActionResult getAllCards()
        {
            return Ok(_paymentService.GetStoredPaymentCards(User.Identity.Name));
        }

        // Adds a new payment card associated with the authenticated user
        [HttpPost]
        [Route("")]
        public IActionResult createCard([FromBody] PaymentCardInputModel card)
        {
            if (ModelState.IsValid)
            {
                _paymentService.AddPaymentCard(User.Identity.Name, card);
                return NoContent();
            }
            return BadRequest(ModelState);
        }
    }
}