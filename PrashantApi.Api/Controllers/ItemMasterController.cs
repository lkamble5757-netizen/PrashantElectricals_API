using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using PrashantApi.Application.DTOs.ItemMaster;
using PrashantApi.Application.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class ItemMasterController(IItemMasterService itemMasterService) : ControllerBase
{
    private readonly IItemMasterService _itemMasterService = itemMasterService;

    [HttpPost]
    public async Task<IActionResult> AddItem([FromBody] ItemMasterDto dto)
    {
        var id = await _itemMasterService.AddOrUpdateItemAsync(dto);
        return Ok(new { Id = id });
    }


    [HttpPut("UpdateItem")]
    public async Task<IActionResult> UpdateItem([FromBody] ItemMasterDto dto)
    {
        if (dto == null || dto.Id <= 0)
            return BadRequest("Invalid item data.");

        var idUpdated = await _itemMasterService.UpdateItemMaster(dto);

        if (idUpdated <= 0)
            return NotFound("Item not updated. Please check the item Id.");

        return Ok(new { Id = idUpdated });
    }


    [HttpGet]
    public async Task<ActionResult<List<ItemMasterDto>>> GetAllItems()
    {
        var items = await _itemMasterService.GetAllItemsAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ItemMasterDto>> GetItemById(int id)
    {
        var item = await _itemMasterService.GetItemByIdAsync(id);
        if (item == null)
            return NotFound();
        return Ok(item);
    }
}

