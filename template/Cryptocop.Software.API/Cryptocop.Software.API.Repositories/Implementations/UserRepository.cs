using System;
using Cryptocop.Software.API.Models.Dtos;
using Cryptocop.Software.API.Models.InputModels;
using Cryptocop.Software.API.Repositories.Interfaces;
using Cryptocop.Software.API.Repositories.Contexts;
using System.Linq;
using Cryptocop.Software.API.Repositories.Entities;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System.Text;

namespace Cryptocop.Software.API.Repositories.Implementations
{
    public class UserRepository : IUserRepository
    {
        private readonly CryptocopDbContext _dbContext;
        private string _salt = "00209b47-08d7-475d-a0fb-20abf0872ba0";

        public UserRepository(CryptocopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserDto CreateUser(RegisterInputModel inputModel)
        {
            int id = _dbContext.Users.DefaultIfEmpty().Max(p => p == null ? 0 : p.Id) + 1;
            var token = new JwtToken();
            _dbContext.Add(token);
            _dbContext.SaveChanges();
            var user = new User
            {
                Id = id,
                FullName = inputModel.FullName,
                Email = inputModel.Email,
                HashedPassword = HashPassword(inputModel.Password)
            };
            _dbContext.Add(user);
            _dbContext.SaveChanges();
            return new UserDto
            {
                Id = user.Id,
                FullName = user.FullName,
                Email = user.Email
            };
        }

        public UserDto AuthenticateUser(LoginInputModel loginInputModel)
        {
            var user = _dbContext.Users.FirstOrDefault(u =>
            u.Email == loginInputModel.Email &&
            u.HashedPassword == HashPassword(loginInputModel.Password));
            if (user == null) { return null; }
            return new UserDto
            {
                Id = user.Id,
                Email = user.Email,
                FullName = user.FullName
            };
        }

        private string HashPassword(string password)
        {
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(
            password: password,
            salt: CreateSalt(),
            prf: KeyDerivationPrf.HMACSHA1,
            iterationCount: 10000,
            numBytesRequested: 256 / 8));
        }

        private byte[] CreateSalt() =>
            Convert.FromBase64String(Convert.ToBase64String(Encoding.UTF8.GetBytes(_salt)));
    }
}