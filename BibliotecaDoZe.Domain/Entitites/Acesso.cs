
using AcademiaDoZe.Domain.Enums;
using AcademiaDoZe.Dominio.Exceptions;

namespace AcademiaDoZe.Domain.Entities
{

    public class Acesso : Entity
    {
        public EPessoaTipo Tipo { get; private set; }
        public Pessoa AlunoColaborador { get; private set; }
        public DateTime DataHora { get; private set; }

        public Acesso() { }

        private Acesso(EPessoaTipo tipo, Pessoa pessoa, DateTime dataHora) : base()
        {
            Tipo = tipo;
            AlunoColaborador = pessoa;
            DataHora = dataHora;
        }

        public static Acesso Criar(EPessoaTipo tipo, Pessoa pessoa, DateTime dataHora)
        {
            if (!Enum.IsDefined(typeof(EPessoaTipo), tipo))
                throw new DomainException("TIPO_OBRIGATORIO");

            if (pessoa == null)
                throw new DomainException("PESSOA_OBRIGATORIA");

            if (dataHora < DateTime.Now)
                throw new DomainException("DATAHORA_INVALIDA");

            if (dataHora.TimeOfDay < new TimeSpan(6, 0, 0) || dataHora.TimeOfDay > new TimeSpan(22, 0, 0))
                throw new DomainException("DATAHORA_INTERVALO");

            return new Acesso(tipo, pessoa, dataHora);
        }
    }
}
