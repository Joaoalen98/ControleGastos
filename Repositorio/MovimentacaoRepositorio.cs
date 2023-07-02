using Domain.Entidades;
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
            string? categoria)
        {
            var query = context.Movimentacoes.Where(x => x.UsuarioId == usuarioId);

            if (dataInicial != null && dataFinal != null)
            {
                query = query.Where(x => x.DataEntrada >= dataInicial && x.DataEntrada <= dataFinal);
            }

            if (!string.IsNullOrEmpty(categoria))
            {
                query = query.Where(x => x.Categoria == categoria);
            }

            return await query.ToListAsync();
        }

        public async Task<IEnumerable<Movimentacao>> ObterPorMesAno(
            string usuarioId, int mes, int ano, string? tipoMovimentacao)
        {
            var movs = context.Movimentacoes
                .Where(x => x.UsuarioId == usuarioId
                && x.DataEntrada.Year == ano
                && x.DataEntrada.Month == mes);
            
            if(!string.IsNullOrEmpty(tipoMovimentacao))
            {
                movs = movs.Where(x => x.Tipo == tipoMovimentacao);
            }

            return await movs.ToListAsync();
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