using Domain.DTOs;
using Domain.Entidades;
using Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servico;

namespace Api.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/v1/movimentacao")]
    public class MovimentacaoController : ControladorBase
    {
        private EntradaServico entradaServico;

        public MovimentacaoController(EntradaServico entradaServico)
        {
            this.entradaServico = entradaServico;
        }


        [HttpGet("entradas")]
        public async Task<IActionResult> ObterEntradas(
            [FromQuery] DateTime? dataInicial,
            [FromQuery] DateTime? dataFinal,
            [FromQuery] CategoriaEntradaEnum? categoria
        )
        {
            try
            {
                var usuarioId = User.FindFirst("Id").Value;
                var entradas = await entradaServico.ObterTodos(usuarioId, dataInicial, dataFinal, categoria);
                return Ok();
            }
            catch (System.Exception ex)
            {
                return EnviarErro(500, "Erro interno");
            }
        }

        [HttpPost("entradas")]
        public async Task<IActionResult> Criar(NovaEntradaDTO model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await entradaServico.Criar(model);
                    return StatusCode(201);
                }
                catch (ApplicationException ex)
                {
                    return EnviarErro(400, ex.Message);
                }
                catch (System.Exception ex)
                {
                    return EnviarErro(500, "Erro interno");
                }
            }

            return EnviarErro(400, "Erro", ModelState);
        }

        [HttpPut("entradas")]
        public async Task<IActionResult> Editar(Entrada model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await entradaServico.Editar(model);
                    return Ok();
                }
                catch (ApplicationException ex)
                {
                    return EnviarErro(400, ex.Message);
                }
                catch (System.Exception ex)
                {
                    return EnviarErro(500, "Erro interno");
                }
            }

            return EnviarErro(400, "Erro", ModelState);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(string id)
        {
            try
            {
                await entradaServico.Deletar(id);
                return Ok();
            }
            catch (ApplicationException ex)
            {
                return EnviarErro(400, ex.Message);
            }
            catch (System.Exception)
            {
                return EnviarErro(500, "Erro Interno");
            }
        }
    }
}