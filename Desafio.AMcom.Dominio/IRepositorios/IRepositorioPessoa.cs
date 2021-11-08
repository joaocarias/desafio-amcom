using Desafio.AMcom.Dominio.DTO;
using Desafio.AMcom.Dominio.Entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.AMcom.Dominio.IRepositorios
{
    public interface IRepositorioPessoa
    {
        Task<IList<Pessoa>> ObterTodas();
        Task<IList<Pessoa>> ObterPorEmail(string email);
        Task<IList<Pessoa>> ObterPorNome(string nome);

        Task<UsersDTO> ObterDadosAPI();
    }
}
