using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PrashantApi.Application.Feature.Menu.GetMenu;
using PrashantApi.Application.Interfaces.Menu;
using PrashantEle.API.PrashantEle.Application.Common;

namespace PrashantApi.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // optional if menu requires auth
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly IMediator _mediator;
        public MenuController(IMenuService menuService, IMediator mediator)
        {
            _menuService = menuService;
            _mediator = mediator;
        }
        
        // GetRoleWise User Menu | taken Login Users RoleId from ClaimTypes
        [HttpGet("GetMenuByLoginUserRoleId")]
        public async Task<IActionResult> GetMenuByRoleId()
        {
            var result = await _mediator.Send(new GetMenuQuery());

            if (!result.IsSuccess) return BadRequest(result);
            return Ok(result.Output);
        }

    }
}
