using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum CategoriaDespesaEnum
    {
        [Display(Name = "Aluguel")]
        ALUGUEL,

        [Display(Name = "Internet")]
        INTERNET,

        [Display(Name = "Transporte")]
        TRANSPORTE,

        [Display(Name = "Saúde")]
        SAUDE,

        [Display(Name = "Alimentação")]
        ALIMENTACAO,

        [Display(Name = "Assinaturas")]
        ASSINATURAS,

        [Display(Name = "Mensalidades")]
        MENSALIDADES,
    }
}
