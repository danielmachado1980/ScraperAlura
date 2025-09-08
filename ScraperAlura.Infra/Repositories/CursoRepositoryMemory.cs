using ScraperAlura.Domain.Entities;
using ScraperAlura.Domain.Interfaces;

namespace ScraperAlura.Infra.Repositories
{
    public class CursoRepositoryMemoria : ICursoRepository
    {
        private readonly List<Curso> _cursos = new();

        public Task SalvarAsync(Curso curso)
        {
            _cursos.Add(curso);
            return Task.CompletedTask;
        }

        public Task<List<Curso>> RetornarAsync()
        {
            return Task.FromResult(_cursos);
        }
    }
}
