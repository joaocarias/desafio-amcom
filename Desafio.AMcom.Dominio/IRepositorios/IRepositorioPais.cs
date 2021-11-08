using Desafio.AMcom.Dominio.Entidades;
using System.Collections.Generic;

namespace Desafio.AMcom.Dominio.IRepositorios
{
    public interface IRepositorioPais
    {
        public IList<Pais> ObterTodos();
        public IList<Pais> ObterPorSigla(string sigla);
    }
}
