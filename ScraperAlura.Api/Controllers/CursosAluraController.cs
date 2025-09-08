using Microsoft.AspNetCore.Mvc;
using ScraperAlura.Domain.Entities;
using ScraperAlura.Domain.Interfaces;

namespace ScraperAlura.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CursosAluraController : ControllerBase
    {
        private readonly ICursoService _cursoService;

        public CursosAluraController(ICursoService cursoService)
        {
            _cursoService = cursoService;
        }

        // GET api/cursos?termo=csharp
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> Get([FromQuery] string termo)
        {
            var cursos = await _cursoService.ExecutarAsync(termo);
            return Ok(cursos);
        }

        // GET api/cursos/all
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Curso>>> GetAll()
        {
            var cursos = await _cursoService.RetornarAsync();
            return Ok(cursos);
        }
    }
}
