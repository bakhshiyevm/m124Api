using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Abstract;
using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO;

namespace Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _UserRoleService;

        public UserRoleController(IUserRoleService UserRoleService)
        {
            _UserRoleService = UserRoleService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get( [FromRoute] int id) 
        {
            try
            {
                var res = _UserRoleService.Get(id);

                if (res == null)
                {
                    return NotFound();
                }

                return Ok(res);
            }

            catch (Exception e)
            {
                return Problem(e.Message);
            }

        }

        [HttpGet]
        [Route("get")]
        public IEnumerable<UserRoleDTO> Get()
        {

           return _UserRoleService.Get();
        }


        [HttpPost]
        [Route("create")]
        public UserRoleDTO Create([FromBody] UserRoleDTO UserRole)
        {

            return _UserRoleService.Create(UserRole);
        }

        [HttpPut]
        [Route("update")]
        public UserRoleDTO Update([FromBody] UserRoleDTO UserRole)
        {

            return _UserRoleService.Update(UserRole);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromBody] int id)
        {

             _UserRoleService.Delete(id);

            return NoContent();
        }
    }
}
