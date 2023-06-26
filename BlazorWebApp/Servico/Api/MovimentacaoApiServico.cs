using System.Net.Http.Headers;
using System.Net.Http.Json;
using BlazorWebApp.Servico.LocalStorage;
using Domain.DTOs;
using Domain.Entidades;
using Domain.Enums;
using Newtonsoft.Json;

namespace BlazorWebApp.Servico.Api
{
    public class MovimentacaoApiServico : BaseApiServico
    {
        public MovimentacaoApiServico(
            HttpClient http, 
            LocalStorageServico localStorageServico) 
            : base(http, localStorageServico)
        {
        }

        public async Task<IEnumerable<Movimentacao>> ObterMovimentacoes(
            DateTime dataInicial,
            DateTime dataFinal,
            TipoMovimentacaoEnum tipoMovimentacaoEnum
        )
        {
            var querys = $"?dataInicial={dataInicial:yyyy-MM-dd}&dataFinal={dataFinal:yyyy-MM-dd}&tipoMovimentacao={tipoMovimentacaoEnum}";
            
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await ObterToken());
            var req = await http.GetAsync($"api/v1/movimentacao{querys}");

            var res = await req.Content.ReadAsStringAsync();
            

            if (req.IsSuccessStatusCode)
            {
                var obj = JsonConvert.DeserializeObject<List<Movimentacao>>(res);
                return obj;
            }
            else 
            {
                throw new ServicoException("Erro");
            }
        }

        public async Task Criar(NovaMovimentacaoDTO model)
        {
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await ObterToken());
            var req = await http.PostAsJsonAsync($"api/v1/movimentacao", model);

            var res = await req.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(res);

            if (req.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new ServicoException("Erro", obj);
            }
        }

        public async Task Editar(Movimentacao model)
        {
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await ObterToken());
            var req = await http.PutAsJsonAsync($"api/v1/movimentacao", model);

            var res = await req.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(res);

            if (req.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new ServicoException("Erro", obj);
            }
        }

        public async Task Deletar(string id)
        {
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await ObterToken());
            var req = await http.DeleteAsync($"api/v1/movimentacao/{id}");

            var res = await req.Content.ReadAsStringAsync();
            var obj = JsonConvert.DeserializeObject<dynamic>(res);

            if (req.IsSuccessStatusCode)
            {
                return;
            }
            else
            {
                throw new ServicoException("Erro", obj);
            }
        }
    }
}