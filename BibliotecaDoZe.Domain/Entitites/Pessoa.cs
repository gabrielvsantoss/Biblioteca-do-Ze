using AcademiaDoZe.Domain.Entities;
using AcademiaDoZe.Domain.ValueObjects;

public abstract class Pessoa : Entity
{
    public string Nome { get; protected set; } = string.Empty;
    public string Cpf { get; protected set; } = string.Empty;
    public DateOnly DataNascimento { get; protected set; }
    public string Telefone { get; protected set; } = string.Empty;
    public string Email { get; protected set; } = string.Empty;
    public Logradouro Endereco { get; protected set; } = null!;
    public string Numero { get; protected set; } = string.Empty;
    public string Complemento { get; protected set; } = string.Empty;
    public string Senha { get; protected set; } = string.Empty;
    public Arquivo Foto { get; protected set; } = null!;

    protected Pessoa() { }

    protected Pessoa(
        string nome,
        string cpf,
        DateOnly dataNascimento,
        string telefone,
        string email,
        Logradouro endereco,
        string numero,
        string complemento,
        string senha,
        Arquivo foto
    ) : base()
    {
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Telefone = telefone;
        Email = email;
        Endereco = endereco;
        Numero = numero;
        Complemento = complemento;
        Senha = senha;
        Foto = foto;
    }

    protected Pessoa(string cpf, string nome, string email)
    {
        ArgumentNullException.ThrowIfNull(cpf);
        ArgumentNullException.ThrowIfNull(nome);
        ArgumentNullException.ThrowIfNull(email);

        Cpf = cpf;
        Nome = nome;
        Email = email;
    }
}
}