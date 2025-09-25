using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.DTOs.ReferenceDataMaster;
using PrashantApi.Application.Interfaces;
using PrashantApi.Application.Interfaces.ReferenceDataMaster;
using System.Collections.Generic;
using System.Threading.Tasks;
using PrashantApi.Application.Feature.ReferenceDataMaster.Queries;

namespace PrashantApi.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReferenceDataMasterController(IMediator mediator) : ControllerBase
    {
        private readonly IMediator _mediator = mediator;

        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleDto>>> GetRoles()
        {
            var roles = await _mediator.Send(new GetRoleNamesQuery());
            return Ok(roles);
        }

        [HttpGet("menus")]
        public async Task<ActionResult<List<MenuDto>>> GetMenus()
        {
            var menus = await _mediator.Send(new GetMenuNamesQuery());
            return Ok(menus);
        }


        [HttpGet("usernames")]
        public async Task<ActionResult<List<UserDto>>> GetUserName()
        {
            var menus = await _mediator.Send(new GetUserNamesQuery());
            return Ok(menus);
        }
    }
}
