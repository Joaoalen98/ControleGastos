using Blazored.LocalStorage;

namespace BlazorWebApp.Servico.LocalStorage
{
    public class LocalStorageServico
    {
        private ILocalStorageService localStorageService;

        public LocalStorageServico(ILocalStorageService localStorageService)
        {
            this.localStorageService = localStorageService;   
        }
        
        public async Task<T?> ObterItem<T>(string chave)
        {
            return await localStorageService.GetItemAsync<T>(chave);
        }

        public async Task SalvarItem<T>(string chave, T objeto)
        {
            await localStorageService.SetItemAsync<T>(chave, objeto);
        }

        public async Task RemoverItem(string chave)
        {
            await localStorageService.RemoveItemAsync(chave);
        }
    }
}
