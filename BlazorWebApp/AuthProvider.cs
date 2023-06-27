using BlazorWebApp.Servico.Api;
using BlazorWebApp.Servico.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorWebApp
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private LocalStorageServico localStorageServico;
        private UsuarioApiServico usuarioApiServico;


        public AuthProvider(LocalStorageServico localStorageServico, UsuarioApiServico usuarioApiServico)
        {
            this.localStorageServico = localStorageServico;
            this.usuarioApiServico = usuarioApiServico;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            
            var token = await localStorageServico.ObterItem<string>("token");
            if (token != null)
            {
                try
                {
                    var usuario = await usuarioApiServico.ValidaToken(token);
                    var claims = new Claim[]
                    {
                        new Claim("Id", usuario.Id),
                        new Claim(ClaimTypes.Name, usuario.Nome),
                        new Claim("CPF", usuario.CPF),
                    };
                    identity = new ClaimsIdentity(claims, "jwt");
                }
                catch (ApplicationException ex)
                {
                    
                }    
            }

            var principal = new ClaimsPrincipal(identity);
            var state = new AuthenticationState(principal);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
