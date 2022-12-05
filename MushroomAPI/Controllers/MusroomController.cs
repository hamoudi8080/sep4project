using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contactss.Interfaces;

namespace MushroomAPI.Controllers;


[ApiController]
[Route("[controller]")]
public class MusroomController:ControllerBase
{
    private readonly IMusroomFarm mushroomService;

    public MusroomController(IMusroomFarm mushroomService)
    {
        this.mushroomService = mushroomService;
    }
    
    [HttpPost]
    
    public async Task<ActionResult<MushroomFarm>> PostPlantAsync([FromBody] MushroomFarm mushroom)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Bad request");
        }
        try
        {
            var added = await mushroomService.PostMushroomAsync(mushroom);
            return Created($"/{added.Name}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    public async Task<ActionResult<MushroomFarm>> GetPlantByDeviceAsync([FromQuery] string mui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Bad Request");
        }
        try
        {
            var plant = await mushroomService.GetPlantMushroomAsync(mui);
            return Ok(plant);
        }
        catch (Exception e)
        {
            return e.Message == "Status not Found" ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
    }
    
    [HttpDelete]
    public async Task<ActionResult<MushroomFarm>> DeletePlantAsync([FromQuery] string eui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("BadRequest");
        }
        try
        {
            var plant = await mushroomService.DeleteMushroomAsync(eui);
            return Ok(plant);
        }
        catch (Exception e)
        {
            return e.Message == "DeviceNotFound" ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
    }
    
    
}