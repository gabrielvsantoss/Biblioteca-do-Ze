using AcademiaDoZe.Domain.ValueObjects;
using AcademiaDoZe.Dominio.Exceptions;
using AcademiaDoZe.Dominio.Services;
using System.Text.RegularExpressions;
namespace AcademiaDoZe.Domain.Entities
{
    public class Aluno : Pessoa
    {
        //Gabriel Velho dos Santos
        private Aluno(string nome, string cpf, DateOnly dataNascimento, string telefone, string email, Logradouro endereco, string numero, string complemento, string senha, Arquivo foto)
        : base(nome, cpf, dataNascimento, telefone, email, endereco, numero, complemento, senha, foto)
        { }
        public static Aluno Criar(string nome, string cpf, DateOnly dataNascimento, string telefone, string email, Logradouro endereco, string numero, string complemento, string senha, Arquivo foto)
        {

            if (NormalizadoService.TextoVazioOuNulo(nome)) throw new DomainException("NOME_OBRIGATORIO");

            nome = NormalizadoService.LimparEspacos(nome);
            if (NormalizadoService.TextoVazioOuNulo(cpf)) throw new DomainException("CPF_OBRIGATORIO");
            cpf = NormalizadoService.LimparEDigitos(cpf);
            if (cpf.Length != 11) throw new DomainException("CPF_DIGITOS");
            if (dataNascimento == default) throw new DomainException("DATA_NASCIMENTO_OBRIGATORIO");
            if (dataNascimento > DateOnly.FromDateTime(DateTime.Today.AddYears(-12))) throw new DomainException("DATA_NASCIMENTO_MINIMA_INVALIDA");
            if (NormalizadoService.TextoVazioOuNulo(telefone)) throw new DomainException("TELEFONE_OBRIGATORIO");
            telefone = NormalizadoService.LimparEDigitos(telefone);
            if (telefone.Length != 11) throw new DomainException("TELEFONE_DIGITOS");
            email = NormalizadoService.LimparEspacos(email);
         
            if (NormalizadoService.TextoVazioOuNulo(senha)) throw new DomainException("SENHA_OBRIGATORIO");
            senha = NormalizadoService.LimparEspacos(senha);
            if (NormalizadoService.ValidarSenha(senha)) throw new DomainException("SENHA_FORMATO");
            if (endereco == null) throw new DomainException("LOGRADOURO_OBRIGATORIO");

            if (NormalizadoService.TextoVazioOuNulo(numero)) throw new DomainException("NUMERO_OBRIGATORIO");
            numero = NormalizadoService.LimparEspacos(numero);
            complemento = NormalizadoService.LimparEspacos(complemento);

            return new Aluno(nome, cpf, dataNascimento, telefone, email, endereco, numero, complemento, senha, foto);

        }
    }
}