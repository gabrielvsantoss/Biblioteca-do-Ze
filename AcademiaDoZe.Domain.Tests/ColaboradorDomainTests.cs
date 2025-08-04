using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.ValueObjects;
using AcademiaDoZe.Dominio.Enums;
using AcademiaDoZe.Dominio.Exceptions;
namespace AcademiaDoZe.Domain.Tests
{
    public class ColaboradorDomainTests
    {
        //Gustavo Velho dos Santos

        private Logradouro GetValidLogradouro() => Logradouro.Criar("12345678", "Rua A", "Centro", "Cidade", "SP", "Brasil");
        private Arquivo GetValidArquivo() => Arquivo.Criar(new byte[1], ".jpg");
        [Fact]
        public void CriarColaborador_ComDadosValidos_DeveCriarObjeto()
        {
            var nome = "João da Silva"; var cpf = "12345678901"; var dataNascimento = DateOnly.FromDateTime(DateTime.Today.AddYears(-20)); var telefone = "11999999999";
            var email = "joao@email.com"; var logradouro = GetValidLogradouro(); var numero = "123"; var complemento = "Apto 1"; var senha = "Senha@112"; var foto = GetValidArquivo();  DateOnly dataAdmissao = new DateOnly(2023, 10, 27); var tipo = TipoAdmissaoColaboradorEnum.Atendente; var vinculo = VinculoColaboradorEnum.Estagio;
            var aluno = Colaborador.Criar(nome, cpf, dataNascimento, telefone, email, logradouro, numero, complemento, senha, foto, dataAdmissao, tipo, vinculo);
            Assert.NotNull(aluno);
        }
        [Fact]
        public void CriarColaborador_ComNomeVazio_DeveLancarExcecao()
        {
            var cpf = "12345678901"; var dataNascimento = DateOnly.FromDateTime(DateTime.Today.AddYears(-20)); var telefone = "11999999999";
            var email = "joao@email.com"; var logradouro = GetValidLogradouro(); var numero = "123"; var complemento = "Apto 1"; var senha = "Senha@123"; var foto = GetValidArquivo(); DateOnly dataAdmissao = new DateOnly(2023, 10, 27); var tipo = TipoAdmissaoColaboradorEnum.Atendente; var vinculo = VinculoColaboradorEnum.Estagio;
            var ex = Assert.Throws<DomainException>(() =>
            Colaborador.Criar(
            "",
            cpf,
            dataNascimento,
            telefone,
            email,
            logradouro,
            numero,
            complemento,
            senha,
            foto,
            dataAdmissao,
            tipo,
            vinculo
            ));
            Assert.Equal("NOME_OBRIGATORIO", ex.Message);
        }
    }
}