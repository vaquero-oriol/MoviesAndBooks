using App;
using Microsoft.AspNetCore.Mvc;

namespace WeRead.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : Controller
    {


        private readonly TmbdService _tmbdService;

        public MovieController(TmbdService tmbdService)
        {
            _tmbdService = tmbdService;
        }

        [HttpGet("GetMovieById/{id:int}")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var pelicula = await _tmbdService.ObtenerPelicula(id);

            if (pelicula.IsFailure)
            {
                return NotFound(pelicula.Error);
            }

            return Ok(pelicula.Value);
        }
    }
}
