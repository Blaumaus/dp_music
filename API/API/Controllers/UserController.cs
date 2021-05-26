using BLL.DTO;
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
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        public ActionResult<RestResponse<UserDTO>> Get()
        {
            try
            {
                string auntificatedUserId = User.Identity.Name;
                UserDTO user = _userService.GetCurrentUser(auntificatedUserId);
                if (user == null)
                    return NotFound();
                return  RestResponse<UserDTO>.Success(user);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
