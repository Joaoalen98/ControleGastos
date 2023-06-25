using Domain.DTOs;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace BlazorWebApp.Servico.Api
{
    public class UsuarioApiServico
    {
        private HttpClient http;

        public UsuarioApiServico(HttpClient http)
        {
            this.http = http;
        }

        public async Task<dynamic> Login(LoginDTO model)
        {
            var req = await http.PostAsJsonAsync("api/v1/usuario/login", model);
            var res = await req.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(res);

            if (req.IsSuccessStatusCode)
            {
                return obj;
            }
            else
            {
                throw new ServicoException("Erro", obj);
            }
        }

        public async Task<dynamic> Cadastro(NovoUsuarioDTO model)
        {
            var req = await http.PostAsJsonAsync("api/v1/usuario/cadastro", model);
            var res = await req.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(res);

            if (req.IsSuccessStatusCode)
            {
                return obj;
            }
            else
            {
                throw new ServicoException("Erro", obj);
            }
        }

        public async Task<dynamic> ValidaToken(string token)
        {
            var req = await http.GetAsync("api/v1/usuario/valida-token");
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

            var res = await req.Content.ReadAsStringAsync();

            if (req.IsSuccessStatusCode)
            {
                var obj = JsonConvert.DeserializeObject<dynamic>(res);
                return obj;
            }
            else
            {
                throw new ApplicationException(res);
            }
        }
    }
}
