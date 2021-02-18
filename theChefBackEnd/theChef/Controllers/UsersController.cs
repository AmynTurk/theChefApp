using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using theChef.Entities;
using theChef.Models;
using theChef.Services;

namespace theChef.Controllers
{
    //[Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<string>> Test()
        {
            return new string[] { "result1", "result2" };
        }
        
        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateModel authenticateModel)
        {
            var user = _userService.Authenticate(authenticateModel.username, authenticateModel.password);

            if (user==null)
            {
                user = new User();

                return Ok(user);
            }

            return Ok(user);
        }

        [Authorize(Roles = Role.Chef)]
        [HttpGet]
        public ActionResult<string> testAuth()
        {
            return Ok("the chef is ready");
        }
    }
}
