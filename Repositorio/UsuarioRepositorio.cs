using Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Repositorio
{
    public class UsuarioRepositorio
    {
        private AppDbContext context;

        public UsuarioRepositorio(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Criar(Usuario usuario)
        {
            await context.Usuarios.AddAsync(usuario);
            await context.SaveChangesAsync();
        }

        public async Task<Usuario?> ObterPorId(string id)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
            return usuario;
        }

        public async Task<Usuario?> ObterPorEmail(string email)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
            return usuario;
        }

        public async Task<Usuario?> ObterPorCPF(string cpf)
        {
            var usuario = await context.Usuarios.FirstOrDefaultAsync(x => x.CPF == cpf);
            return usuario;
        }
    }
}