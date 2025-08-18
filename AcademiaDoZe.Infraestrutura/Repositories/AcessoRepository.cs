using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.Repositories;
using AcademiaDoZe.Infrastructure.Data;
using AcademiaDoZe.Infrastructure.Exceptions;
using Google.Protobuf.WellKnownTypes;
using System.Data;
using System.Data.Common;

namespace AcademiaDoZe.Infrastructure.Repositories
{
    public class AcessoRepository : BaseRepository<Acesso>, IAcessoRepository
    {
        //Gabriel Velho dos Santos

        private readonly string _connectionString;
        private readonly DatabaseType _databaseType;

        public AcessoRepository(string connectionString, DatabaseType databaseType) : base(connectionString, databaseType)
        {
            _connectionString = connectionString;
            _databaseType = databaseType;
        }

        public async Task<IEnumerable<Acesso>> GetAcessosPorAlunoPeriodo(int? alunoId = null, DateOnly? inicio = null, DateOnly? fim = null)
        {
            var acessos = new List<Acesso>();

            using var connection = DbProvider.CreateConnection(_connectionString, _databaseType);
            await connection.OpenAsync();

            var query = @"SELECT * FROM Acessos 
                          WHERE (@AlunoId IS NULL OR AlunoId = @AlunoId)
                          AND (@Inicio IS NULL OR Data >= @Inicio)
                          AND (@Fim IS NULL OR Data <= @Fim)";

            using var command = DbProvider.CreateCommand(query, connection, CommandType.Text);
            command.Parameters.Add(DbProvider.CreateParameter("@AlunoId", alunoId, DbType.Int32, _databaseType));
            command.Parameters.Add(DbProvider.CreateParameter("@Inicio", inicio?.ToDateTime(TimeOnly.MinValue), DbType.DateTime, _databaseType));
            command.Parameters.Add(DbProvider.CreateParameter("@Fim", fim?.ToDateTime(TimeOnly.MaxValue), DbType.DateTime, _databaseType));

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                acessos.Add(Map(reader));
            }

            return acessos;
        }

        public async Task<IEnumerable<Acesso>> GetAcessosPorColaboradorPeriodo(int? colaboradorId = null, DateOnly? inicio = null, DateOnly? fim = null)
        {
            var acessos = new List<Acesso>();

            using var connection = DbProvider.CreateConnection(_connectionString, _databaseType);
            await connection.OpenAsync();

            var query = @"SELECT * FROM Acessos 
                          WHERE (@ColaboradorId IS NULL OR ColaboradorId = @ColaboradorId)
                          AND (@Inicio IS NULL OR Data >= @Inicio)
                          AND (@Fim IS NULL OR Data <= @Fim)";

            using var command = DbProvider.CreateCommand(query, connection, CommandType.Text);
            command.Parameters.Add(DbProvider.CreateParameter("@ColaboradorId", colaboradorId, DbType.Int32, _databaseType));
            command.Parameters.Add(DbProvider.CreateParameter("@Inicio", inicio?.ToDateTime(TimeOnly.MinValue), DbType.DateTime, _databaseType));
            command.Parameters.Add(DbProvider.CreateParameter("@Fim", fim?.ToDateTime(TimeOnly.MaxValue), DbType.DateTime, _databaseType));

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                acessos.Add(Map(reader));
            }

            return acessos;
        }

        public async Task<Dictionary<TimeOnly, int>> GetHorarioMaisProcuradoPorMes(int mes)
        {
            var result = new Dictionary<TimeOnly, int>();

            using var connection = DbProvider.CreateConnection(_connectionString, _databaseType);
            await connection.OpenAsync();

            var query = @"SELECT CAST(FORMAT(Data, 'HH:mm') AS TIME) as Horario, COUNT(*) as Qtde
                          FROM Acessos
                          WHERE MONTH(Data) = @Mes
                          GROUP BY CAST(FORMAT(Data, 'HH:mm') AS TIME)
                          ORDER BY Qtde DESC";

            using var command = DbProvider.CreateCommand(query, connection, CommandType.Text);
            command.Parameters.Add(DbProvider.CreateParameter("@Mes", mes, DbType.Int32, _databaseType));

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var horario = (DateTime.Now);
                var quantidade = reader.GetInt32(1);
                result[horario] = quantidade;
            }

            return result;
        }

        public async Task<Dictionary<int, TimeSpan>> GetPermanenciaMediaPorMes(int mes)
        {
            var result = new Dictionary<int, TimeSpan>();

            using var connection = DbProvider.CreateConnection(_connectionString, _databaseType);
            await connection.OpenAsync();

            var query = @"SELECT MONTH(DataEntrada) as Mes, 
                                 AVG(DATEDIFF(SECOND, DataEntrada, DataSaida)) as MediaSegundos
                          FROM Acessos
                          WHERE MONTH(DataEntrada) = @Mes
                          GROUP BY MONTH(DataEntrada)";

            using var command = DbProvider.CreateCommand(query, connection, CommandType.Text);
            command.Parameters.Add(DbProvider.CreateParameter("@Mes", mes, DbType.Int32, _databaseType));

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                var mesDb = reader.GetInt32(0);
                var mediaSegundos = reader.GetDouble(1);
                result[mesDb] = TimeSpan.FromSeconds(mediaSegundos);
            }

            return result;
        }

        public async Task<IEnumerable<Aluno>> GetAlunosSemAcessoNosUltimosDias(int dias)
        {
            var alunos = new List<Aluno>();

            using var connection = DbProvider.CreateConnection(_connectionString, _databaseType);
            await connection.OpenAsync();

            var query = @"SELECT a.* FROM Alunos a
                          WHERE NOT EXISTS (
                              SELECT 1 FROM Acessos ac
                              WHERE ac.AlunoId = a.Id 
                              AND ac.Data >= DATEADD(DAY, -@Dias, GETDATE())
                          )";

            using var command = DbProvider.CreateCommand(query, connection, CommandType.Text);
            command.Parameters.Add(DbProvider.CreateParameter("@Dias", dias, DbType.Int32, _databaseType));

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                alunos.Add(MapAluno(reader));
            }

            return alunos;
        }

        private Acesso Map(DbDataReader reader)
        {
            return new Acesso
            {
            };
        }

        private Aluno MapAluno(DbDataReader reader)
        {
            return new Aluno
            {
            };
        }

        public override Task<Acesso> Adicionar(Acesso entity)
        {
            throw new NotImplementedException();
        }

        public override Task<Acesso> Atualizar(Acesso entity)
        {
            throw new NotImplementedException();
        }

        protected override Task<Acesso> MapAsync(DbDataReader reader)
        {
            throw new NotImplementedException();
        }
    }
}
