using ScraperAlura.Domain.Entities;

namespace ScraperAlura.Domain.Interfaces
{
    public interface ICursoService
    {
        Task<IReadOnlyList<string>> ExecutarAsync(string termo);
        Task<IList<Curso>> RetornarAsync();
    }
}
