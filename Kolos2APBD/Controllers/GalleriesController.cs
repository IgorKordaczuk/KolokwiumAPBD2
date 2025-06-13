namespace Kolos2APBD.Controllers;
using Kolos2APBD.Exceptions;
using Kolos2APBD.Services;
using Microsoft.AspNetCore.Mvc;


[ApiController]
[Route("api/[controller]")]
public class GalleriesController : ControllerBase
{
    private readonly IDbService _dbService;

    public GalleriesController(IDbService dbService)
    {
        _dbService = dbService;
    }

    [HttpGet("{id}/exhibitions")]
    public async Task<IActionResult> GetOrderById(int id)
    {
        try
        {
            var galleryExhibitions = await _dbService.GetGalleryExhibitions(id);
            return Ok(galleryExhibitions);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }

    /*[HttpPut("{id}/fulfill")]
    public async Task<IActionResult> FulfillOrder(int id, [FromBody] FulfillOrderDTO fulfillOrderDTO)
    {
        try
        {
            var order = await _dbService.FulfillOrder(id, fulfillOrderDTO);
            return Ok(order);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }*/
}