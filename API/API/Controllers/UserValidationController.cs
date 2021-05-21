using BLL.Interfaces;
using BLL.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserValidationController : Controller
    {
        private readonly IUserValidationService _userDataValidationService;
        public UserValidationController(IUserValidationService userDataValidationService)
        {
            _userDataValidationService = userDataValidationService;
        }

        [HttpGet]
        [Route("ValidateUserName/{userName}")]
        public ActionResult<RestResponse<bool>> ValidateUserName(string userName)
        {
            try
            {
                return _userDataValidationService.ValidateUserName(userName);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("ValidateEmail/{email}")]
        public ActionResult<RestResponse<bool>> ValidateEmail(string email)
        {
            try
            {
                return _userDataValidationService.ValidateEmail(email);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
