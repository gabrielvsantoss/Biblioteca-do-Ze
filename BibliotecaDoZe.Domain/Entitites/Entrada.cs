using AcademiaDoZe.Domain.Entities;

namespace AcademiaDoZe.Dominio.Entities
//Gabriel Velho dos Santos

{
    public class Entrada : Entity
    {
        public Aluno? Aluno { get; set; }
        public Colaborador? Colaborador { get; set; }
        public TimeSpan HoraChegada { get; set; }

        public Entrada(Aluno aluno, Colaborador colaborador, TimeSpan horaChegada)
        {
            Aluno = aluno;
            Colaborador = colaborador;
            HoraChegada = horaChegada;
        }
        public static Entrada Criar(Aluno aluno, Colaborador colaborador, TimeSpan horaChegada)
        {
            if (aluno == null || colaborador == null)
            {
                throw new ArgumentNullException("Aluno e Colaborador não podem ser nulos.");
            }
            return new Entrada(aluno, colaborador, horaChegada);
        }
    }


}