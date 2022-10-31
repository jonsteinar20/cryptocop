using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Cryptocop.Software.API.Services.Interfaces;
using Cryptocop.Software.API.Models.InputModels;

namespace Cryptocop.Software.API.Controllers
{
    [Authorize]
    [Route("api/account")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ITokenService _tokenService;

        public AccountController(IAccountService accountService, ITokenService tokenService)
        {
            _accountService = accountService;
            _tokenService = tokenService;
        }

        // TODO: Setup routes

        // Registers a new user within the application
        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public IActionResult createUser([FromBody] RegisterInputModel user)
        {
            if (ModelState.IsValid)
            {
                _accountService.CreateUser(user);
                return NoContent();
            }
            return BadRequest(ModelState);
        }

        // Signs the user in by checking the credentials provided and issuing a JWT token in return
        [AllowAnonymous]
        [HttpPost]
        [Route("signin")]
        public IActionResult signUserIn([FromBody] LoginInputModel login)
        {
            var user = _accountService.AuthenticateUser(login);
            if (user == null) { return Unauthorized(); }
            return Ok(_tokenService.GenerateJwtToken(user));
        }

        // Logs the user out by voiding the provided JWT token using the id found within the claim
        [HttpGet]
        [Route("signout")]
        public IActionResult signUserOut()
        {
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "tokenId").Value, out var tokenId);
            _accountService.Logout(tokenId);
            return NoContent();
        }
    }
}