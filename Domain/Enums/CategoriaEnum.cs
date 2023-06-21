using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum CategoriaEnum
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
        OUTRO = 7,

        [Display(Name = "Aluguel")]
        ALUGUEL = 8,

        [Display(Name = "Internet")]
        INTERNET = 9,

        [Display(Name = "Transporte")]
        TRANSPORTE = 10,

        [Display(Name = "Saúde")]
        SAUDE = 11,

        [Display(Name = "Alimentação")]
        ALIMENTACAO = 12,

        [Display(Name = "Assinaturas")]
        ASSINATURAS = 13,

        [Display(Name = "Mensalidades")]
        MENSALIDADES = 14,
    }
}
