//Gabriel Velho dos Santos

using AcademiaDoZe.Domain.Entities;
namespace AcademiaDoZe.Dominio.Entities
{
    public class Saida : Entity
    {
        public Aluno? Aluno { get; set; }
        public Colaborador? Colaborador { get; set; }
        public TimeSpan HoraSaida { get; set; }


        public Saida(Aluno aluno, Colaborador colaborador, TimeSpan horaSaida)
        {
            Aluno = aluno;
            Colaborador = colaborador;
            HoraSaida = horaSaida;
        }

        public static Saida Criar(Aluno aluno, Colaborador colaborador, TimeSpan horaSaida)
        {
            if (aluno == null || colaborador == null)
            {
                throw new ArgumentNullException("Aluno e Colaborador não podem ser nulos.");
            }
            return new Saida(aluno, colaborador, horaSaida);
        }
    }
}