using Desafio.AMcom.Dominio.DTO;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace Desafio.AMcom.Infraestrutura.Servicos
{
    public class UserAPIServico
    {
        public static async Task<UsersDTO> Consumir()
        {
            HttpClient httpClient = new HttpClient();
            var response = await httpClient.GetAsync("https://reqres.in/api/users?page=2");

            return JsonConvert.DeserializeObject<UsersDTO>(await response.Content.ReadAsStringAsync());
        }
    }
}
