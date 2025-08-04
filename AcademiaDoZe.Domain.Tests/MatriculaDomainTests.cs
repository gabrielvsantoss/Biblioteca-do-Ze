using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.Enums;
using AcademiaDoZe.Domain.ValueObjects;
using AcademiaDoZe.Dominio.Exceptions;
namespace AcademiaDoZe.Domain.Tests
{
    public class MatriculaDomainTests
    {
        //Gustavo Velho dos Santos

        private Logradouro GetValidLogradouro() => Logradouro.Criar("12345678", "Rua A", "Centro", "Cidade", "SP", "Brasil");
        private Aluno GetValidAluno() => Aluno.Criar("aaaaaa", "07590484954", DateOnly.FromDateTime(DateTime.Today.AddYears(-20)), "49988451630", "gabriel@gmail.com", GetValidLogradouro(), "2222", "Nao sei", "A!sjjjjs", GetValidArquivo());
        private Arquivo GetValidArquivo() => Arquivo.Criar(new byte[1], ".jpg");
        [Fact]
        public void CriarM_ComDadosValidos_DeveCriarObjeto()
        {
            var aluno = GetValidAluno();
            var Plano = EMatriculaPlano.Anual;   
            var DataInicio = DateOnly.FromDateTime(DateTime.Today);
            var DataFim = DateOnly.FromDateTime(DateTime.Today.AddYears(1));
            var Objetivo = "Emagrecimento";
            var RestricoesMedicas = EMatriculaRestricoes.Labirintite;
            var LaudoMedico = GetValidArquivo();
            var ObservacoesRestricoes = "Nenhuma observação";
            var matricula = Matricula.Criar(aluno, Plano, DataInicio, DataFim, Objetivo, RestricoesMedicas, LaudoMedico, ObservacoesRestricoes);
            Assert.NotNull(matricula);
        }
        [Fact]
        public void CriarColaborador_ComNomeVazio_DeveLancarExcecao()
        {
            var aluno = GetValidAluno();
            var Plano = EMatriculaPlano.Anual;
            var DataFim = DateOnly.FromDateTime(DateTime.Today.AddYears(1));
            var Objetivo = "Emagrecimento";
            var RestricoesMedicas = EMatriculaRestricoes.Labirintite;
            var LaudoMedico = GetValidArquivo();
            var ObservacoesRestricoes = "Nenhuma observação";
            var ex = Assert.Throws<DomainException>(() =>
            Matricula.Criar(aluno, Plano, default, DataFim, Objetivo, RestricoesMedicas, LaudoMedico, ObservacoesRestricoes
            ));
            Assert.Equal("DATA_INICIO_OBRIGATORIO", ex.Message);
        }
    }
}