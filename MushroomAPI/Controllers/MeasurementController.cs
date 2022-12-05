using Microsoft.AspNetCore.Mvc;
using Model;
using Model.Contactss.Interfaces;

namespace MushroomAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class MeasurementController:ControllerBase
{
    private readonly IMeasurement measurementService;

    public MeasurementController(IMeasurement measurementService)
    {
        this.measurementService = measurementService;
    }
    
    
    [HttpPost]
    
    public async Task<ActionResult<MeasurementType>> PostPlantAsync([FromBody] Measurement mushroom)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest("Bad request");
        }
        try
        {
            var added = await measurementService.AddMeasurementAsync(mushroom);
            return Created($"/{added.MeasurementTypes}", added);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
 
    
    
    [HttpGet]
    public async Task<ActionResult<Measurement>> GetLastMeasurement([FromQuery] string eui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var t = await measurementService.GetMeasurementAsync(eui);
            return Ok(t);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            return e.Message.Equals("MeasurementNotFound") ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
    }
    
    [HttpGet]
    [Route("history")]
    public async Task<ActionResult<IList<Measurement>>> GetListOfMeasurements([FromQuery] string eui)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        try
        {
            var t = await measurementService.GetMeasurementHistoryAsync(eui);
            return Ok(t);
        }
        catch (Exception e)
        {
            return e.Message.Equals("MeasurementNotFound") ? NotFound(e.Message) : StatusCode(500, e.Message);
        }
    }
}