using Domain.Enums;

namespace Domain.Entidades
{
    public class Entrada
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public double Valor { get; set; }
        public DateTime DataEntrada { get; set; }
        public CategoriaEntradaEnum Categoria { get; set; }
        public string CategoriaString { get; set; }

        public Entrada()
        {
            CategoriaString = Categoria.GetDisplayName();
        }
    }
}
