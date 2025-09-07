namespace ScraperAlura.Domain.Interfaces
{
    public interface ICursoService
    {
        Task<IReadOnlyList<string>> ExecutarAsync(string termo);
    }
}
