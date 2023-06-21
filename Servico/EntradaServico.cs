using Domain.DTOs;
using Domain.Entidades;
using Domain.Enums;
using Repositorio;

namespace Servico
{
    public class EntradaServico
    {
        private EntradaRepositorio entradaRepositorio;

        public EntradaServico(EntradaRepositorio entradaRepositorio)
        {
            this.entradaRepositorio = entradaRepositorio;
        }

        public async Task Criar(NovaEntradaDTO dto)
        {
            var entrada = new Entrada
            {
                Categoria = dto.Categoria,
                DataEntrada = dto.DataEntrada,
                UsuarioId = dto.UsuarioId,
                Valor = dto.Valor,
            };

            await entradaRepositorio.Criar(entrada);
        }

        public async Task Editar(Entrada entrada)
        {
            await entradaRepositorio.Editar(entrada);
        }

        public async Task<IEnumerable<Entrada>> ObterTodos(
            string usuarioId, DateTime? dataInicial, DateTime? dataFinal, CategoriaEntradaEnum? categoria)
        {
            return await entradaRepositorio.ObterTodos(usuarioId, dataInicial, dataFinal, categoria);
        }

        public async Task<Entrada?> ObterPorId(string id)
        {
            return await entradaRepositorio.ObterPorId(id);
        }

        public async Task Deletar(string id)
        {
            var entrada = await entradaRepositorio.ObterPorId(id);
            await entradaRepositorio.Deletar(entrada);
        }
    }
}