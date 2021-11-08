using Desafio.AMcom.Dominio.Entidades;
using Desafio.AMcom.Dominio.IRepositorios;
using Desafio.AMcom.Infraestrutura.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Desafio.AMcom.Infraestrutura.Repositorios
{
    public class RepositorioPais : IRepositorioPais
    {
        private IList<Pais> _paises;

        public IList<Pais> ObterPorSigla(string sigla)
        {
            return _paises.Where(x => x.Sigla.ToUpper().Equals(sigla.ToUpper())).ToList();
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
