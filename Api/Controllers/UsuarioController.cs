using Domain.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Servico;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/v1/usuario")]
    public class UsuarioController : ControladorBase
    {
        private UsuarioServico usuarioServico;

        public UsuarioController(UsuarioServico usuarioServico)
        {
            this.usuarioServico = usuarioServico;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var autenticar = await usuarioServico.Autenticar(dto);
                    return Ok(autenticar);                    
                }
                catch (ApplicationException ex)
                {
                    return EnviarErro(400, ex.Message, null);
                }
                catch (System.Exception)
                {
                    return EnviarErro(500, "Erro interno", null);
                }
            }

            return EnviarErro(400, null, ModelState);
        }

        [HttpPost("cadastro")]
        public async Task<IActionResult> Cadastro([FromBody] NovoUsuarioDTO dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await usuarioServico.Criar(dto);
                    return StatusCode(201);
                }
                catch (ApplicationException ex)
                {
                    return EnviarErro(400, ex.Message, null);
                }
                catch (System.Exception ex)
                {
                    return EnviarErro(500, "Erro interno", null);
                }
            }

            return EnviarErro(400, null, ModelState);
        }

        [Authorize]
        [HttpGet("valida-token")]
        public async Task<IActionResult> ValidaToken()
        {
            var usuarioId = User.FindFirst("Id").Value;
            var usuario = await usuarioServico.ObterPorId(usuarioId);
            usuario.Senha = null;
            return Ok(usuario);
        }
    }
}