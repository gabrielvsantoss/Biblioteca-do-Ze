using System.ComponentModel.DataAnnotations;
namespace AcademiaDoZe.Domain.Enums
{
    //Gabriel Velho dos Santos

    public enum EMatriculaPlano
    {
        [Display(Name = "Mensal")]
        Mensal = 0,
        [Display(Name = "Trimestral")]
        Trimestral = 1,
        [Display(Name = "Semestral")]
        Semestral = 2,
        [Display(Name = "Anual")]
        Anual = 3
    }
}