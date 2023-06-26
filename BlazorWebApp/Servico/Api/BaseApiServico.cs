using BlazorWebApp.Servico.LocalStorage;

namespace BlazorWebApp.Servico.Api
{
    public class BaseApiServico
    {
        protected HttpClient http;
        protected LocalStorageServico localStorageServico;
        
        public BaseApiServico(HttpClient http, LocalStorageServico localStorageServico)
        {
            this.http = http;
            this.localStorageServico = localStorageServico;
        }

        public async Task<string?> ObterToken()
        {
            return await localStorageServico.ObterItem<string>("token");
        }
    }
}