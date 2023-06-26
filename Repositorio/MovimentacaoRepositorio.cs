using Domain.Entidades;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class MovimentacaoRepositorio
    {
        private AppDbContext context;

        public MovimentacaoRepositorio(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Criar(Movimentacao entrada)
        {
            await context.Movimentacoes.AddAsync(entrada);
            await context.SaveChangesAsync();
        }

        public async Task Editar(Movimentacao entrada)
        {
            context.Update(entrada);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Movimentacao>> ObterTodos(
            string usuarioId,
            DateTime? dataInicial,
            DateTime? dataFinal,
            CategoriaReceitaEnum? categoriaReceita,
            CategoriaDespesaEnum? categoriaDespesa,
            TipoMovimentacaoEnum? tipoMovimentacao)
        {
            var query = context.Movimentacoes.Where(x => x.UsuarioId == usuarioId);

            if (dataInicial != null && dataFinal != null)
            {
                query = query.Where(x => x.DataEntrada >= dataInicial && x.DataEntrada <= dataFinal);
            }

            if (tipoMovimentacao == TipoMovimentacaoEnum.RECEITA)
            {
                query = query.Where(x => x.Valor > 0);
            }
            else if (tipoMovimentacao == TipoMovimentacaoEnum.DESPESA)
            {
                query = query.Where(x => x.Valor < 0);
            }

            if (categoriaDespesa != null)
            {
                query = query.Where(x => x.CategoriaDespesa == categoriaDespesa);
            }
            if (categoriaReceita != null)
            {
                query = query.Where(x => x.CategoriaReceita == categoriaReceita);
            }

            return await query.ToListAsync();
        }

        public async Task<Movimentacao?> ObterPorId(string id)
        {
            return await context.Movimentacoes
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Deletar(Movimentacao entrada)
        {
            context.Movimentacoes.Remove(entrada);
            await context.SaveChangesAsync();
        }
    }
}