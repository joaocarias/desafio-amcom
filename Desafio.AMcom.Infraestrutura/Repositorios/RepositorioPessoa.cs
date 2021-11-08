using Desafio.AMcom.Dominio.DTO;
using Desafio.AMcom.Dominio.Entidades;
using Desafio.AMcom.Dominio.IRepositorios;
using Desafio.AMcom.Infraestrutura.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.AMcom.Infraestrutura.Repositorios
{
    public class RepositorioPessoa : IRepositorioPessoa
    {

        public async Task<UsersDTO> ObterDadosAPI()
        {
            return await UserAPIServico.Consumir();
        }

        public async Task<IList<Pessoa>> ObterPorEmail(string email)
        {
            var userAPI = await UserAPIServico.Consumir();

            return userAPI.Pessoas.Where(x => x.Email.Contains(email)).ToList();
        }

        public async Task<IList<Pessoa>> ObterPorNome(string nome)
        {
            var userAPI = await UserAPIServico.Consumir();

            return userAPI.Pessoas.Where(x => x.FirstName.Contains(nome) || x.LastName.Contains(nome)).ToList();
        }

        public async Task<IList<Pessoa>> ObterTodas()
        {
            var userAPI = await UserAPIServico.Consumir();

            return userAPI.Pessoas.ToList();
        }
    }
}
