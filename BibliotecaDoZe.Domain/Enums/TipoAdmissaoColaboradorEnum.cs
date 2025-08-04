//Gabriel Velho dos Santos

using System.ComponentModel.DataAnnotations;

namespace AcademiaDoZe.Dominio.Enums
{
        public enum TipoAdmissaoColaboradorEnum
        {
            [Display(Name = "Administrador")]
            Administrador = 0,
            [Display(Name = "Atendente")]
            Atendente = 1,
            [Display(Name = "Instrutor")]
            Instrutor = 2
        }
}