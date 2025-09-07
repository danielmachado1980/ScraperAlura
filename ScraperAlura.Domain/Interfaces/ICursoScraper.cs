using ScraperAlura.Domain.Entities;

namespace ScraperAlura.Domain.Interfaces
{
    public interface ICursoScraper
    {
        Task<IReadOnlyList<Curso>> BuscarAsync(string termo);
    }
}
