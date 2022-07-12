using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstract;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get( [FromRoute] int id) 
        {
            try
            {
                var res = _userService.Get(id);

                if (res == null)
                {
                    return NotFound();
                }

                return Ok();
            }

            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<User> Get()
        {

           return _userService.Get();
        }

        [HttpPost]
        [Route("create")]
        public User Create([FromBody] User user)
        {

            return _userService.Create(user);
        }

        [HttpPut]
        [Route("update")]
        public User Update([FromBody] User user)
        {

            return _userService.Update(user);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromBody] int id)
        {

             _userService.Delete(id);

            return NoContent();
        }
    }
}
