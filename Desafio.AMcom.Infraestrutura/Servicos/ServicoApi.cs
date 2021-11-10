using Desafio.AMcom.Dominio.DTO;
using Newtonsoft.Json;
using Polly;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.AMcom.Infraestrutura.Servicos
{
    public class ServicoApi
    {
        private readonly HttpClient _httpClient;

        public ServicoApi(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.BaseAddress = new System.Uri("https://reqres.in/api/");
        }

        public async Task<UsersDTO> ConsumirAsync()
        {
            var timeoutPolicy = Policy.TimeoutAsync(60);
            var response = await timeoutPolicy
                                    .ExecuteAsync(
                                          async ct => await _httpClient.GetAsync("users?page=2"),
                                          CancellationToken.None
                                     );

            var jsonString = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<UsersDTO>(jsonString);
        }
    }
}
