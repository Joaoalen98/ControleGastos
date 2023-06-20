using System.ComponentModel.DataAnnotations;

namespace Domain.Enums
{
    public enum CategoriaSaidaEnum
    {
        [Display(Name = "Aluguel")]
        ALUGUEL = 1,

        [Display(Name = "Internet")]
        INTERNET = 2,

        [Display(Name = "Transporte")]
        TRANSPORTE = 3,

        [Display(Name = "Saúde")]
        SAUDE = 4,

        [Display(Name = "Alimentação")]
        ALIMENTACAO = 4,

        [Display(Name = "Assinaturas")]
        ASSINATURAS = 5,

        [Display(Name = "Mensalidades")]
        MENSALIDADES = 6,
    }
}
