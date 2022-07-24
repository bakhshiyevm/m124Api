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
    public class RoleController : ControllerBase
    {
        private readonly IRoleService _RoleService;

        public RoleController(IRoleService RoleService)
        {
            _RoleService = RoleService;
        }

        [HttpGet]
        [Route("get/{id}")]
        public async Task<IActionResult> Get( [FromRoute] int id) 
        {
            try
            {
                var res = _RoleService.Get(id);

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
        public IEnumerable<RoleDTO> Get()
        {

           return _RoleService.Get();
        }


        [HttpPost]
        [Route("create")]
        public RoleDTO Create([FromBody] RoleDTO Role)
        {

            return _RoleService.Create(Role);
        }

        [HttpPut]
        [Route("update")]
        public RoleDTO Update([FromBody] RoleDTO Role)
        {

            return _RoleService.Update(Role);
        }

        [HttpDelete]
        [Route("delete")]
        public IActionResult Delete([FromBody] int id)
        {

             _RoleService.Delete(id);

            return NoContent();
        }
    }
}
