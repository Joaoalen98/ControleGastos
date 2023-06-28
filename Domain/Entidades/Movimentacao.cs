using Domain.Enums;

namespace Domain.Entidades
{
    public class Movimentacao
    {
        public string Id { get; set; }
        public string UsuarioId { get; set; }
        public double Valor { get; set; }
        public string Descricao { get; set; }
        public DateTime DataEntrada { get; set; }
        public CategoriaReceitaEnum? CategoriaReceita { get; set; }
        public CategoriaDespesaEnum? CategoriaDespesa { get; set; }
        
        public string? CategoriaReceitaString
        {
            get => CategoriaReceita?.GetDisplayName();
        }

        public string? CategoriaDespesaString
        {
            get => CategoriaDespesa?.GetDisplayName();
        }

        public Movimentacao()
        {
            Id = Guid.NewGuid().ToString();
        }
    }
}
