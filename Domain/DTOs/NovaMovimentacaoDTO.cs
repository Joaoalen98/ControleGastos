namespace Domain.DTOs
{
    public class NovaMovimentacaoDTO
    {
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrada { get; set; }
        public string Categoria { get; set; }
        public string Tipo { get; set; }
        public string UsuarioId { get; set; }
    }
}