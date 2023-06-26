using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum CategoriaReceitaEnum
    {
        [Display(Name = "Salário")]
        SALARIO,

        [Display(Name = "Bonificações")]
        BONIFICACOES,

        [Display(Name = "13° Salário")]
        DECIMO_TERCEIRO_SALARIO,

        [Display(Name = "Férias")]
        FERIAS,

        [Display(Name = "Auxílio Desemprego")]
        AUXILIO_DESEMPREGO,

        [Display(Name = "Freelas")]
        FREELAS,

        [Display(Name = "Outro")]
        OUTRO,
    }
}
