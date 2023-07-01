namespace Domain.Entidades
{
    public class Movimentacao
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrada { get; set; }
        public string Categoria { get; set; }
        public string Tipo { get; set; }

        public Movimentacao()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
