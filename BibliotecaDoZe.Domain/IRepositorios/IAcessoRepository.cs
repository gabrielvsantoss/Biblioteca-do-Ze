using AcademiaDoZe.Domain.Entities;
namespace AcademiaDoZe.Domain.Repositories
{
    public interface IAcessoRepository : IRepository<Acesso>
    {
        Task<IEnumerable<Acesso>> GetAcessosPorAlunoPeriodo(int? alunoId = null, DateOnly? inicio = null, DateOnly? fim = null);
        Task<IEnumerable<Acesso>> GetAcessosPorColaboradorPeriodo(int? colaboradorId = null, DateOnly? inicio = null, DateOnly? fim = null);
        Task<Dictionary<TimeOnly, int>> GetHorarioMaisProcuradoPorMes(int mes);
        Task<Dictionary<int, TimeSpan>> GetPermanenciaMediaPorMes(int mes);
        Task<IEnumerable<Aluno>> GetAlunosSemAcessoNosUltimosDias(int dias);
    }
}