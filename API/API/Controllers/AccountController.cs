using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Models;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;
        private readonly ILogInService _logInService;
        private readonly ILogOutService _logOutService;
        private readonly IAuthenticatedUser _isAuthorizedUserService;
        public AccountController(IAccountService accountService, ILogInService logInService, ILogOutService logOutService, IAuthenticatedUser isAuthorizedUserService)
        {
            _accountService = accountService;
            _logInService = logInService;
            _logOutService = logOutService;
            _isAuthorizedUserService = isAuthorizedUserService;
        }

        [HttpPost]
        [Route("Register")]
        public async Task<ActionResult<UserRegistrationDto>> Register(UserRegistrationDto signUpDto)
        {
            try
            {
                await _accountService.Register(signUpDto);
                return Ok();
            }
            catch
            {
                return BadRequest();
                throw new Exception("Sign up error!");
            }
        }

        [HttpPost]
        [Route("Login")]
        public ActionResult<RestResponse<bool>> LogIn(LogInDto logInDto)
        {
            try
            {
                return _logInService.LogIn(logInDto);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete]
        [Authorize]
        [Route("Logout")]
        public ActionResult LogOut()
        {
            try
            {
                _logOutService.LogOut();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("IsAuthorizedUser")]
        public ActionResult<RestResponse<bool>> IsAuthorizedUser()
        {
            var isAuthenticatedUser = User.Identity.IsAuthenticated;

            try
            {
                return _isAuthorizedUserService.IsAuthenticatedUser(isAuthenticatedUser);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
