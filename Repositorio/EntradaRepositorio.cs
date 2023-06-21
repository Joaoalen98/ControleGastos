using Domain.Entidades;
using Domain.Enums;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class EntradaRepositorio
    {
        private AppDbContext context;

        public EntradaRepositorio(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Criar(Entrada entrada)
        {
            await context.Entradas.AddAsync(entrada);
            await context.SaveChangesAsync();
        }

        public async Task Editar(Entrada entrada)
        {
            context.Update(entrada);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Entrada>> ObterTodos(
            string usuarioId, DateTime? dataInicial, DateTime? dataFinal, CategoriaEntradaEnum? categoria)
        {
            var query = context.Entradas.Where(x => x.UsuarioId == usuarioId);

            if (dataInicial != null && dataFinal != null)
            {
                query = query.Where(x => x.DataEntrada >= dataInicial && x.DataEntrada <= dataFinal);
            }
            if (categoria != null)
            {
                query = query.Where(x => x.Categoria == categoria);
            }

            return await query.ToListAsync();
        }

        public async Task<Entrada?> ObterPorId(string id)
        {
            return await context.Entradas
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task Deletar(Entrada entrada)
        {
            context.Entradas.Remove(entrada);
            await context.SaveChangesAsync();
        }
    }
}