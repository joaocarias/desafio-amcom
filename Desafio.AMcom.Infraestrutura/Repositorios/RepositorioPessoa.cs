using Desafio.AMcom.Dominio.DTO;
using Desafio.AMcom.Dominio.Entidades;
using Desafio.AMcom.Dominio.IRepositorios;
using Newtonsoft.Json;
using Polly;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Desafio.AMcom.Infraestrutura.Repositorios
{
    public class RepositorioPessoa : IRepositorioPessoa
    {
        private UsersDTO _usersDTO;
        private HttpClient _httpClient;

        public RepositorioPessoa()
        {
            _httpClient = new HttpClient();
            _usersDTO = new UsersDTO();
        }

        public async Task<UsersDTO> ObterDadosAPI()
        {
            await ConsumirAPi();
            return _usersDTO;
        }

        public async Task<IList<Pessoa>> ObterPorEmail(string email)
        {
            await ConsumirAPi();
            return _usersDTO.Data.Where(x => x.Email.ToLower().Contains(email.ToLower())).ToList();
        }

        public async Task<IList<Pessoa>> ObterPorNome(string nome)
        {
            await ConsumirAPi();
            return _usersDTO.Data.Where(x => x.First_name.ToUpper().Contains(nome.ToUpper()) || x.Last_name.ToUpper().Contains(nome.ToUpper())).ToList();
        }

        public async Task<IList<Pessoa>> ObterTodas()
        {
            await ConsumirAPi();
            return _usersDTO.Data.ToList();
        }

        private async Task ConsumirAPi()
        {
            var timeoutPolicy = Policy.TimeoutAsync(30);
            var response = await timeoutPolicy
                .ExecuteAsync(
                  async ct => await _httpClient.GetAsync("https://reqres.in/api/users?page=2"), 
                  CancellationToken.None 
                  );
       
            var jsonString = await response.Content.ReadAsStringAsync();
            _usersDTO = JsonConvert.DeserializeObject<UsersDTO>(jsonString);
        }
    }
}
