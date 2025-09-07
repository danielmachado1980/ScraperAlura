using ScraperAlura.Domain.Entities;

namespace ScraperAlura.Domain.Interfaces
{
    public interface ICursoRepository
    {
        Task SalvarAsync(Curso curso);
    }
}
