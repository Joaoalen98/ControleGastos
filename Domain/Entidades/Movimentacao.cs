using Domain.Enums;

namespace Domain.Entidades
{
    public class Movimentacao
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public double Valor { get; set; }
        public DateTime DataEntrada { get; set; }
        public CategoriaEnum Categoria { get; set; }
        public string CategoriaString { get; set; }

        public Movimentacao()
        {
            CategoriaString = Categoria.GetDisplayName();
        }
    }
}
