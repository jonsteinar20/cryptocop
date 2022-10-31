using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/cart")]
    [ApiController]
    public class ShoppingCartController : ControllerBase
    {
        // TODO: Setup routes
        private IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        // Gets all items within the shopping cart
        [HttpGet]
        [Route("")]
        public IActionResult getCartItems()
        {
            return Ok(_shoppingCartService.GetCartItems(User.Identity.Name));
        }

        // Adds an item to the shopping cart
        [HttpPost]
        [Route("")]
        public IActionResult addCartItem([FromBody] ShoppingCartItemInputModel item)
        {
            if(ModelState.IsValid)
            {
                var newItemId =_shoppingCartService.AddCartItem(User.Identity.Name, item);
                // return CreatedAtRoute("getItemById", new {id = newItemId}, null)
            }
            return BadRequest(ModelState);
        }

        // Deletes an item from the shopping cart
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult deleteItem(int id)
        {
            _shoppingCartService.RemoveCartItem(User.Identity.Name, id);
            return NoContent();
        }

        // Updates the quantity for a shopping cart item
        [HttpPatch]
        [Route("{id:int}")]
        public IActionResult updateItem(int id)
        {
            if(ModelState.IsValid)
            {
                float quantity = 1;
                _shoppingCartService.UpdateCartItemQuantity(User.Identity.Name, id, quantity);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // Clears the cart
        [HttpDelete]
        [Route("")]
        public IActionResult deleteAllItems()
        {
            _shoppingCartService.ClearCart(User.Identity.Name);
            return NoContent();
        }
    }
}