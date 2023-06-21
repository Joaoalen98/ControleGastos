using Domain.DTOs;
using Domain.Entidades;
using Domain.Enums;
using Repositorio;

namespace Servico
{
    public class MovimentacaoServico
    {
        private MovimentacaoRepositorio entradaRepositorio;

        public MovimentacaoServico(MovimentacaoRepositorio entradaRepositorio)
        {
            this.entradaRepositorio = entradaRepositorio;
        }

        public async Task Criar(NovaMovimentacaoDTO dto)
        {
            var entrada = new Movimentacao
            {
                Categoria = dto.Categoria,
                DataEntrada = dto.DataEntrada,
                UsuarioId = dto.UsuarioId,
                Valor = dto.Valor,
            };

            await entradaRepositorio.Criar(entrada);
        }

        public async Task Editar(Movimentacao entrada)
        {
            await entradaRepositorio.Editar(entrada);
        }

        public async Task<IEnumerable<Movimentacao>> ObterTodos(
            string usuarioId, DateTime? dataInicial, DateTime? dataFinal, CategoriaEnum? categoria)
        {
            return await entradaRepositorio.ObterTodos(usuarioId, dataInicial, dataFinal, categoria);
        }

        public async Task<Movimentacao?> ObterPorId(string id)
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