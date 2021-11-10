using Polly;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.AMcom.Testes
{
    public class TesteApiPessoas
    {
        private HttpClient _httpClient;
     
        [Fact]
        public async Task TestarConexaoAPI()
        {
            _httpClient = new HttpClient();
            var timeoutPolicy = Policy.TimeoutAsync(30);
            var response = await timeoutPolicy
                .ExecuteAsync(
                  async ct => await _httpClient.GetAsync("https://reqres.in/api/users?page=2"),
                  CancellationToken.None
                  );

            Assert.Equal(200, ((int) response.StatusCode));
        }
    }
}
