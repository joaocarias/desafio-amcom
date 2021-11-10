using Desafio.AMcom.Infraestrutura.Repositorios;
using Xunit;

namespace Desafio.AMcom.Testes
{
    public class TesteRepositorioPais
    {
        [Fact]
        public void TestarObterPorSigla()
        {
            RepositorioPais repositorio = new RepositorioPais();
            var resultado = repositorio.ObterPorSigla("KW");

            Assert.All(resultado, t => Assert.Contains("KW", t.Sigla));
        }

        [Fact]
        public void TestarObterTodos()
        {
            RepositorioPais repositorio = new RepositorioPais();
            var resultado = repositorio.ObterTodos();

            Assert.NotEmpty(resultado);
        }

        [Fact]
        public void TestarObterPorNome()
        {
            RepositorioPais repositorio = new RepositorioPais();
            var resultado = repositorio.ObterPorNome("Brasil");

            Assert.All(resultado, t => Assert.Contains("Brasil", t.NomePais));
        }
    }
}
