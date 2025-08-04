using AcademiaDoZe.Domain.ValueObjects;
using AcademiaDoZe.Dominio.Enums;
using AcademiaDoZe.Dominio.Exceptions;
using AcademiaDoZe.Dominio.Services;
namespace AcademiaDoZe.Domain.Entities
{
    public class Colaborador : Pessoa
    {

        //Gabriel Velho dos Santos
        public DateOnly DataAdmissao { get; private set; }
        public TipoAdmissaoColaboradorEnum Tipo { get; private set; }
        public VinculoColaboradorEnum Vinculo { get; private set; }
        private Colaborador(string nome, string cpf, DateOnly dataNascimento, string telefone, string email, Logradouro endereco, string numero, string complemento, string senha, Arquivo foto, DateOnly dataAdmissao, TipoAdmissaoColaboradorEnum tipo, VinculoColaboradorEnum
        vinculo)
        : base(nome, cpf, dataNascimento, telefone, email, endereco, numero, complemento, senha, foto)
        {
            DataAdmissao = dataAdmissao;
            Tipo = tipo;
            Vinculo = vinculo;
        }
        public static Colaborador Criar(string nome, string cpf, DateOnly dataNascimento, string telefone, string email, Logradouro endereco, string numero, string complemento, string senha, Arquivo foto, DateOnly dataAdmissao, TipoAdmissaoColaboradorEnum tipo,
        VinculoColaboradorEnum vinculo)
        {
            nome = NormalizadoService.LimparEspacos(nome);
            if (NormalizadoService.TextoVazioOuNulo(nome))
                throw new DomainException("NOME_OBRIGATORIO");
            if (NormalizadoService.TextoVazioOuNulo(cpf)) throw new DomainException("CPF_OBRIGATORIO");
            cpf = NormalizadoService.LimparEDigitos(cpf);
            if (cpf.Length != 11) throw new DomainException("CPF_DIGITOS");
            if (dataNascimento == default) throw new DomainException("DATA_NASCIMENTO_OBRIGATORIO");
            if (dataNascimento > DateOnly.FromDateTime(DateTime.Today.AddYears(-12))) throw new DomainException("DATA_NASCIMENTO_MINIMA_INVALIDA");
            if (NormalizadoService.TextoVazioOuNulo(telefone)) throw new DomainException("TELEFONE_OBRIGATORIO");
            telefone = NormalizadoService.LimparEDigitos(telefone);
            if (telefone.Length != 11) throw new DomainException("TELEFONE_DIGITOS");
            email = NormalizadoService.LimparEspacos(email);
            if (!NormalizadoService.ValidarEmail(email)) throw new DomainException("EMAIL_FORMATO");
            if (NormalizadoService.TextoVazioOuNulo(senha)) throw new DomainException("SENHA_OBRIGATORIO");
            senha = NormalizadoService.LimparEspacos(senha);
            if (!NormalizadoService.ValidarSenha(senha)) throw new DomainException("SENHA_FORMATO");
            if (endereco == null) throw new DomainException("LOGRADOURO_OBRIGATORIO");
            if (NormalizadoService.TextoVazioOuNulo(numero)) throw new DomainException("NUMERO_OBRIGATORIO");
            numero = NormalizadoService.LimparEspacos(numero);
            complemento = NormalizadoService.LimparEspacos(complemento);
            if (dataAdmissao == default) throw new DomainException("DATA_ADMISSAO_OBRIGATORIO");
            if (dataAdmissao > DateOnly.FromDateTime(DateTime.Today)) throw new DomainException("DATA_ADMISSAO_MAIOR_ATUAL");
            if (!Enum.IsDefined(tipo)) throw new DomainException("TIPO_COLABORADOR_INVALIDO");
            if (!Enum.IsDefined(vinculo)) throw new DomainException("VINCULO_COLABORADOR_INVALIDO");
            return new Colaborador(nome, cpf, dataNascimento, telefone, email, endereco, numero, complemento, senha, foto, dataAdmissao, tipo, vinculo);
        }
    }
}