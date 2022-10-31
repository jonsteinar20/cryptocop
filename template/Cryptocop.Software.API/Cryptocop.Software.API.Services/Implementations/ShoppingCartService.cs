using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Repositories.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cryptocop.Software.API.Services.Implementations
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCartService(IShoppingCartRepository shoppingCartRepository)
        {
            _shoppingCartRepository = shoppingCartRepository;
        }
        public IEnumerable<ShoppingCartItemDto> GetCartItems(string email)
        {
            _shoppingCartRepository.GetCartItems(email);
            throw new System.NotImplementedException();
        }

        public Task AddCartItem(string email, ShoppingCartItemInputModel shoppingCartItemItem)
        {
            float priceInUsd = 1;
            _shoppingCartRepository.AddCartItem(email, shoppingCartItemItem, priceInUsd);
            throw new System.NotImplementedException();
        }

        public void RemoveCartItem(string email, int id)
        {
            _shoppingCartRepository.RemoveCartItem(email, id);
            throw new System.NotImplementedException();
        }

        public void UpdateCartItemQuantity(string email, int id, float quantity)
        {
            _shoppingCartRepository.UpdateCartItemQuantity(email, id, quantity);
            throw new System.NotImplementedException();
        }

        public void ClearCart(string email)
        {
            _shoppingCartRepository.ClearCart(email);
            throw new System.NotImplementedException();
        }
    }
}
