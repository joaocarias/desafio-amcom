using Desafio.AMcom.Dominio.Entidades;
using Desafio.AMcom.Dominio.IRepositorios;
using Desafio.AMcom.Infraestrutura.Servicos;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<RepositorioPais> _logger;
        private IList<Pais> _paises;

        public RepositorioPais(ILogger<RepositorioPais> logger)
        {
            _logger = logger;
            _paises = new List<Pais>();

            _logger.LogInformation("Iniciando RepositorioPais");
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
            _logger.LogInformation("Atualizando Listagem de Paises");
            _paises = JsonSerializer.Deserialize<IList<Pais>>(LeitorJsonServico.Ler("paises.json"));
        }
    }
}
