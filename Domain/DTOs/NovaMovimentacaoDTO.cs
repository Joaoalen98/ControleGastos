using Domain.Enums;

namespace Domain.DTOs
{
    public class NovaMovimentacaoDTO
    {
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrada { get; set; }
        public CategoriaReceitaEnum? CategoriaReceita { get; set; }
        public CategoriaDespesaEnum? CategoriaDespesa { get; set; }
        public string UsuarioId { get; set; }
    }
}