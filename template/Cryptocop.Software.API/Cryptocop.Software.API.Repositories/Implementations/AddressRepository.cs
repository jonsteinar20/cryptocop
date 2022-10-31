using System.Collections.Generic;
using System.Linq;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Contexts;
using Cryptocop.Software.API.Repositories.Entities;
using Cryptocop.Software.API.Repositories.Interfaces;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class AddressRepository : IAddressRepository
    {
        private readonly CryptocopDbContext _dbContext;

        public AddressRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddAddress(string email, AddressInputModel address)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Email == email);
            if (user == null) { throw new System.Exception("User with email " + email + " not found."); }
            var entity = new Address
            {
                UserId = user.Id,
                StreetName = address.StreetName,
                HouseNumber = address.HouseNumber,
                ZipCode = address.ZipCode,
                Country = address.Country,
                City = address.City
            };
            _dbContext.Addresses.Add(entity);
            _dbContext.SaveChanges();
            throw new System.NotImplementedException();
        }

        public IEnumerable<AddressDto> GetAllAddresses(string email)
        {
            _dbContext.Addresses.Where(i => i.StreetName == email).Select(i => new AddressDto {
                Id = i.Id,
                StreetName = i.StreetName,
                HouseNumber = i.HouseNumber,
                ZipCode = i.ZipCode,
                Country = i.Country,
                City = i.City
            });
            throw new System.NotImplementedException();
        }

        public void DeleteAddress(string email, int addressId)
        {
            throw new System.NotImplementedException();
        }
    }
}