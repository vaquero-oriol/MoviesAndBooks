using App;
using Microsoft.AspNetCore.Mvc;

namespace WeRead.Server.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BookController : Controller
{
    private readonly ObtainBookService _obtainBookService;
    
    public BookController(ObtainBookService obtainBookService)
    {
        _obtainBookService = obtainBookService;
    }


    [HttpGet("GetBookByName/{name}")]
    public async Task<IActionResult> SearchbookByName(string name)
    {
        var libro= await _obtainBookService.ObtenerLibro(name);
        
        if (libro.IsFailure)
            return NotFound(libro.Error);
        
        
        return Ok(libro.Value);
    }
    
  
}