using Domain.Enums;

namespace Domain.DTOs
{
    public class NovaMovimentacaoDTO
    {
        public double Valor { get; set; }
        public DateTime DataEntrada { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public string UsuarioId { get; set; }
    }
}