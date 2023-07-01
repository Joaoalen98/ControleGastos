using Domain.DTOs;
using Domain.Entidades;
using Domain.Enums;
using Repositorio;

namespace Servico
{
    public class MovimentacaoServico
    {
        private MovimentacaoRepositorio movimentacaoRepositorio;

        public MovimentacaoServico(MovimentacaoRepositorio entradaRepositorio)
        {
            this.movimentacaoRepositorio = entradaRepositorio;
        }

        public async Task Criar(NovaMovimentacaoDTO dto)
        {
            var entrada = new Movimentacao
            {
                Categoria = dto.Categoria,
                DataEntrada = dto.DataEntrada,
                UsuarioId = dto.UsuarioId,
                Valor = dto.Valor,
                Descricao = dto.Descricao,
            };

            await movimentacaoRepositorio.Criar(entrada);
        }

        public async Task Editar(Movimentacao entrada)
        {
            await movimentacaoRepositorio.Editar(entrada);
        }

        public async Task<IEnumerable<Movimentacao>> ObterTodos(
            string usuarioId, 
            DateTime? dataInicial, 
            DateTime? dataFinal,
            string? categoria)
        {
            return await movimentacaoRepositorio.ObterTodos(
                usuarioId, 
                dataInicial, 
                dataFinal, 
                categoria);
        }

        public async Task<IEnumerable<Movimentacao>> ObterPorMesAno(string usuarioId, int mes, int ano)
        {
            return await movimentacaoRepositorio.ObterPorMesAno(usuarioId, mes, ano);
        }

        public async Task<Movimentacao?> ObterPorId(string id)
        {
            return await movimentacaoRepositorio.ObterPorId(id);
        }

        public async Task Deletar(string id)
        {
            var entrada = await movimentacaoRepositorio.ObterPorId(id);
            await movimentacaoRepositorio.Deletar(entrada);
        }

        public async Task ValoresPorCategoria(
            string usuarioId, int mes, int ano, TipoMovimentacaoEnum tipoMovimentacao)
        {
            var movs = await movimentacaoRepositorio.ObterPorMesAno(usuarioId, mes, ano);
        }

        public dynamic ObterCategorias()
        {
            var receita = new List<string>();
            foreach (var categoria in Enum.GetValues<CategoriaReceitaEnum>())
            {
                receita.Add(categoria.GetDisplayName());
            }

            var despesa = new List<dynamic>();
            foreach (var categoria in Enum.GetValues<CategoriaDespesaEnum>())
            {
                despesa.Add(categoria.GetDisplayName());
            }

            return new
            {
                Receita = receita,
                Despesa = despesa
            };
        }
    }
}