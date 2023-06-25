using BlazorWebApp.Servico.LocalStorage;
using Microsoft.AspNetCore.Components.Authorization;
using System.Security.Claims;

namespace BlazorWebApp
{
    public class AuthProvider : AuthenticationStateProvider
    {
        private LocalStorageServico localStorageServico;

        public AuthProvider(LocalStorageServico localStorageServico)
        {
            this.localStorageServico = localStorageServico;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var identity = new ClaimsIdentity();
            
            var token = await localStorageServico.ObterItem<string>("token");
            if (token != null)
            {
                identity = new ClaimsIdentity(new Claim[] { }, "jwt");    
            }

            var principal = new ClaimsPrincipal(identity);

            var state = new AuthenticationState(principal);

            NotifyAuthenticationStateChanged(Task.FromResult(state));

            return state;
        }
    }
}
