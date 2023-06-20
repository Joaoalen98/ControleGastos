using Domain.Enums;

namespace Domain.Entidades
{
    public class Saida
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public double Valor { get; set; }
        public DateTime DataSaida { get; set; }
        public CategoriaSaidaEnum Categoria { get; set; }
        public string CategoriaString { get; set; }

        public Saida()
        {
            CategoriaString = Categoria.GetDisplayName();
        }
    }
}
