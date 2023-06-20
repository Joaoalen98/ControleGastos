using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum CategoriaEntradaEnum
    {
        [Display(Name = "Salário")]
        SALARIO = 1,

        [Display(Name = "Bonificações")]
        BONIFICACOES = 2,

        [Display(Name = "13° Salário")]
        DECIMO_TERCEIRO_SALARIO = 3,

        [Display(Name = "Férias")]
        FERIAS = 4,

        [Display(Name = "Auxílio Desemprego")]
        AUXILIO_DESEMPREGO = 5,

        [Display(Name = "Freelas")]
        FREELAS = 6,

        [Display(Name = "Outro")]
        OUTRO = 7
    }
}
