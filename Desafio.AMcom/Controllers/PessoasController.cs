using Desafio.AMcom.Dominio.IRepositorios;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Desafio.AMcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly IRepositorioPessoa _repositorioPessoa;

        public PessoasController(IRepositorioPessoa repositorioPessoa)
        {
            _repositorioPessoa = repositorioPessoa;
        }

        // GET dados-api-pessoa
        /// <summary>
        /// Retorna dados da API https://reqres.in/api/users?page=2 com informações de pessoas
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /dados-api-pessoa
        /// 
        /// </remarks> 
        /// <returns>Listagem de pessoas obtida da API https://reqres.in/api/users?page=2 .</returns>
        /// <response code="200">Retorna listagem de pessoas</response>
        [HttpGet("dados-api-pessoa")]
        public async Task<ActionResult> RetornaDadosApiUser()
        {
            var userDto = await _repositorioPessoa.ObterDadosAPI();

            return Ok(userDto);
        }

        // GET dados-api-pessoa-por-nome
        /// <summary>
        /// Retorna dados da API https://reqres.in/api/users?page=2 com informações de pessoas filtrando por nome
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /dados-api-pessoa-por-nome/joao
        /// 
        /// </remarks> 
        /// <param name="nome">String referente ao nome</param>
        /// <returns>Listagem de pessoas obtida da API https://reqres.in/api/users?page=2 .</returns>
        /// <response code="200">Retorna listagem de pessoas</response>
        [HttpGet("dados-api-pessoa-por-nome")]
        public async Task<ActionResult> RetornaDadosApiUserPorNome(string nome)
        {
            var userDto = await _repositorioPessoa.ObterPorNome(nome);

            return Ok(userDto);
        }

        // GET dados-api-pessoa-por-email
        /// <summary>
        /// Retorna dados da API https://reqres.in/api/users?page=2 com informações de pessoas filtrando por email
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /dados-api-pessoa-por-email/joao@email.com
        /// 
        /// </remarks> 
        /// <param name="email">String referente ao email</param>
        /// <returns>Listagem de pessoas obtida da API https://reqres.in/api/users?page=2 .</returns>
        /// <response code="200">Retorna listagem de pessoas</response>
        [HttpGet("dados-api-pessoa-por-email")]
        public async Task<ActionResult> RetornaDadosApiUserPorEmail(string email)
        {
            var userDto = await _repositorioPessoa.ObterPorEmail(email);

            return Ok(userDto);
        }
    }
}
