using Domain.Enums;

namespace Domain.DTOs
{
    public class NovaEntradaDTO
    {
        public double Valor { get; set; }
        public DateTime DataEntrada { get; set; }
        public CategoriaEntradaEnum Categoria { get; set; }
        public string UsuarioId { get; set; }
    }
}