using ScraperAlura.Domain.Entities;
using ScraperAlura.Domain.Interfaces;

namespace ScraperAlura.Domain.Services
{
    public class CursoService : ICursoService
    {
        private readonly ICursoScraper _scraper;
        private readonly ICursoRepository _repo;

        public CursoService(ICursoScraper scraper, ICursoRepository repo)
        {
            _scraper = scraper;
            _repo = repo;
        }

        public async Task<IReadOnlyList<string>> ExecutarAsync(string termo)
        {
            var cursos = await _scraper.BuscarAsync(termo);
            foreach (var c in cursos)
                await _repo.SalvarAsync(c);

            return cursos.Select(c => $"{c.Titulo} - {c.Descricao}").ToArray();
        }

        public async Task<IList<Curso>> RetornarAsync()
        {
            return await _repo.RetornarAsync();
        }
    }
}
