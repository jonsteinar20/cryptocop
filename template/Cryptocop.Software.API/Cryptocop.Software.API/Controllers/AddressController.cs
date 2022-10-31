using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/addresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            _addressService = addressService;
        }

        // TODO: Setup routes

        // Gets all addresses associated with authenticated user
        [HttpGet]
        [Route("")]
        public IActionResult getAllAddresses()
        {
            return Ok(_addressService.GetAllAddresses(User.Identity.Name));
        }

        // Adds a new address associated with authenticated user
        [HttpPost]
        [Route("")]
        public IActionResult createAddress([FromBody] AddressInputModel address)
        {
            _addressService.AddAddress(User.Identity.Name, address);
            return Ok(200);
        }

        // Deletes an address by id
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteAddress()
        {
            var addressId = 1;
            _addressService.DeleteAddress(User.Identity.Name, addressId);
            return NoContent();
        }
    }
}