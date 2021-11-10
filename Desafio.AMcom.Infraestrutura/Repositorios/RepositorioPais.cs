using Desafio.AMcom.Dominio.Entidades;
using Desafio.AMcom.Dominio.IRepositorios;
using Desafio.AMcom.Infraestrutura.Servicos;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Desafio.AMcom.Infraestrutura.Repositorios
{
    public class RepositorioPais : IRepositorioPais
    {
        private IList<Pais> _paises;

        public RepositorioPais()
        {
            _paises = new List<Pais>();
        }

        public IList<Pais> ObterPorNome(string nome)
        {
            AtualizarListagem();
            return _paises.Where(x => x.NomePais.ToUpper().Contains(nome.ToUpper())).ToList();
        }

        public IList<Pais> ObterPorSigla(string sigla)
        {
            AtualizarListagem();
            return _paises.Where(x => x.Sigla.ToUpper().Contains(sigla.ToUpper())).ToList();
        }

        public IList<Pais> ObterTodos()
        {
            AtualizarListagem();
            return _paises.ToList();
        }

        private void AtualizarListagem()
        {
            _paises = JsonSerializer.Deserialize<IList<Pais>>(LeitorJsonServico.Ler("paises.json"));
        }
    }
}
