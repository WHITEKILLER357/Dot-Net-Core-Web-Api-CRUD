using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RESTfullAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RESTfullAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpPost("/Adduser")]
        public async Task<IActionResult> AdduserAsync(RequestUserModel requestUser)
        {
            var id = await _userRepository.AdduserAsync(requestUser);

            return Ok(new { message = "User Create Success fully"});
        }

        [HttpGet("Get All Users")]
        public async Task<IActionResult> GetAllUsersAsunc()
        {
            var results = await _userRepository.GetAllUsers();

            return Ok(results);
        }

    }
}
