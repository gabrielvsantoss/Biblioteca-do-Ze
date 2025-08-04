//Gabriel Velho dos Santos


using System.ComponentModel.DataAnnotations;

namespace AcademiaDoZe.Dominio.Enums
{
    public enum VinculoColaboradorEnum
    {
        [Display(Name = "CLT")]
        CLT = 0,
        [Display(Name = "Estagiário")]
        Estagio = 1
    }
}