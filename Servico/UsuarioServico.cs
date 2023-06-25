using Domain.DTOs;
using Domain.Entidades;
using Repositorio;

namespace Servico
{
    public class UsuarioServico
    {
        private UsuarioRepositorio usuarioRepositorio;
        private HashService hashService;
        private JwtService jwtService;

        public UsuarioServico(
            UsuarioRepositorio usuarioRepositorio, 
            HashService hashService,
            JwtService jwtService)
        {
            this.usuarioRepositorio = usuarioRepositorio;
            this.hashService = hashService;
            this.jwtService = jwtService;
        }

        public async Task Criar(NovoUsuarioDTO dto)
        {
            var obterporcpf = await usuarioRepositorio.ObterPorCPF(dto.CPF);
            if (obterporcpf != null)
            {
                throw new ApplicationException("CPF já cadastrado");
            }

            var obterporemail = await usuarioRepositorio.ObterPorEmail(dto.Email);
            if (obterporemail != null)
            {
                throw new ApplicationException("Email já cadastrado");
            }

            var usuario = new Usuario
            {
                Id = dto.CPF,
                Email = dto.Email,
                CPF = dto.CPF,
                Nome = dto.Nome,
                Senha = hashService.HashSenha(dto.Senha),
            };

            await usuarioRepositorio.Criar(usuario);
        }

        public async Task<Usuario?> ObterPorId(string id)
        {
            var usuario = await usuarioRepositorio.ObterPorId(id);
            if (usuario == null)
            {
                throw new ApplicationException("Usuario não encontrado");
            }

            return usuario;
        }

        public async Task<Usuario?> ObterPorEmail(string email)
        {
            var usuario = await usuarioRepositorio.ObterPorEmail(email);
            if (usuario == null)
            {
                throw new ApplicationException("Usuario não encontrado");
            }

            return usuario;
        }

        public async Task<dynamic> Autenticar(LoginDTO dto)
        {
            var usuario = await usuarioRepositorio.ObterPorEmail(dto.Email);
            if (usuario == null)
            {
                throw new ApplicationException("Email ou senha incorreta");
            }

            var senhaCorreta = hashService.ValidaSenha(dto.Senha, usuario.Senha);
            if (!senhaCorreta)
            {
                throw new ApplicationException("Email ou senha incorreta");
            }

            var token = jwtService.GerarTokenUsuario(usuario);

            usuario.Senha = null;
            return new { usuario, token };
        }
    }
}