using Desafio.AMcom.Infraestrutura.Repositorios;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.AMcom.Testes
{
    public class TesteRepositorioPessoas
    {
        [Fact]
        public async Task TestarObterDadosAPI()
        {
            RepositorioPessoa repositorio = new RepositorioPessoa();
            var resultado = await repositorio.ObterDadosAPI();

            Assert.NotNull(resultado);
        }

        [Fact]
        public async Task TestarObterPorEmail()
        {
            RepositorioPessoa repositorio = new RepositorioPessoa();
            var resultado = await repositorio.ObterPorEmail("lindsay.ferguson@reqres.in");

            Assert.All(resultado, t => Assert.Contains("lindsay.ferguson@reqres.in", t.Email));
        }

        [Fact]
        public async Task TestarObterPorNome()
        {
            RepositorioPessoa repositorio = new RepositorioPessoa();
            var resultado = await repositorio.ObterPorNome("George");

            Assert.NotNull(resultado);
        }

        [Fact]
        public async Task TestarObterTodas()
        {
            RepositorioPessoa repositorio = new RepositorioPessoa();
            var resultado = await repositorio.ObterTodas();
            
            Assert.NotNull(resultado);
        }
    }
}
