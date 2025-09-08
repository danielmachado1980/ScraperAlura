using Microsoft.AspNetCore.Mvc;
using ScraperAlura.Domain.Entities;
using ScraperAlura.Domain.Interfaces;

namespace ScraperAlura.Api.Controllers
{
    /// <summary>
    /// Controlador para gerenciar cursos da Alura.
    /// </summary>
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
        /// <summary>
        /// Endpoint para buscar cursos com base em um termo de pesquisa e registro em memória.
        /// </summary>
        /// <param name="termo"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> Get([FromQuery] string termo)
        {
            var cursos = await _cursoService.ExecutarAsync(termo);
            return Ok(cursos);
        }

        // GET api/cursos/all
        /// <summary>
        /// Endpoint para retornar todos os cursos registrados em memória.
        /// </summary>
        /// <returns></returns>
        [HttpGet("all")]
        public async Task<ActionResult<IEnumerable<Curso>>> GetAll()
        {
            var cursos = await _cursoService.RetornarAsync();
            return Ok(cursos);
        }
    }
}
