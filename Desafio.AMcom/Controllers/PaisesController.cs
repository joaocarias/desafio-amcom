using Desafio.AMcom.Dominio.IRepositorios;
using Microsoft.AspNetCore.Mvc;

namespace Desafio.AMcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaisesController : ControllerBase
    {
        private readonly IRepositorioPais _repositorioPais;

        public PaisesController(IRepositorioPais repositorioPais)
        {
            _repositorioPais = repositorioPais;
        }

        // GET paises
        /// <summary>
        /// Retorna a lista de todos os países salvos em paises.json
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /paises
        /// 
        /// </remarks> 
        /// <returns>Lista com informações sobre os países</returns>
        /// <response code="200">Retorna a listagem</response>
        [HttpGet("paises")]
        public ActionResult RetornaPaises()
        {
            var paises = _repositorioPais.ObterTodos();

            return Ok(paises);
        }

        // GET pais-por-sigla
        /// <summary>
        /// Retorna a lista a partir do filtro por países por filtro salvos em paises.json
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /pais-por-sigla/AL
        /// 
        /// </remarks>
        /// <param name="sigla">String referente a sigla</param>
        /// <returns>Lista com informações sobre os países a partir do filtro da sigla.</returns>
        /// <response code="200">Retorna a listagem resultado do filtro</response>
        [HttpGet("pais-por-sigla")]
        public ActionResult RetornaPaisPorSigla(string sigla)
        {
            var paises = _repositorioPais.ObterPorSigla(sigla);
            return Ok(paises);
        }

        // GET pais-por-nome
        /// <summary>
        /// Retorna a lista a partir do filtro por países por filtro salvos em paises.json
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /pais-por-sigla/Brasil
        /// 
        /// </remarks>
        /// <param name="nome">String referente ao nome do pais</param>
        /// <returns>Lista com informações sobre os países a partir do filtro do nome.</returns>
        /// <response code="200">Retorna a listagem resultado do filtro</response>
        [HttpGet("pais-por-nome")]
        public ActionResult RetornaPaisPorNome(string nome)
        {
            var paises = _repositorioPais.ObterPorSigla(nome);
            return Ok(paises);
        }
    }
}
