using Desafio.AMcom.Dominio.IRepositorios;
using Desafio.AMcom.Temps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace Desafio.AMcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturasController : ControllerBase
    {
        private ILogger<TemperaturasController> _logger;
        private readonly IRepositorioPais _repositorioPais;
        private readonly IRepositorioPessoa _repositorioPessoa;
        private StreamWriter _file;
        private static IList<Temperatura> Temperaturas;

        public TemperaturasController(ILogger<TemperaturasController> logger, IRepositorioPais repositorioPais, IRepositorioPessoa repositorioPessoa)
        {
            _logger = logger;
            _repositorioPais = repositorioPais;
            _repositorioPessoa = repositorioPessoa;  
            
        }

        // GET fahrenheit
        /// <summary>
        /// Obter valores de temperaturas a partir de Fahrenheit
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /fahrenheit/32
        /// 
        /// </remarks>
        /// <param name="temperatura">Valor em Fahrenheit</param>
        /// <returns>Retorno informações de temperatura em Fahrenheit, em Celsius e Kelvin</returns>
        /// <response code="200">Retorna as temperaturas</response>
        [HttpGet("fahrenheit/{temperatura}")]
        public object GetConversaoFahrenheit(int temperatura)
        {
            Temperatura dados = new Temperatura();

            try
            {
                _logger.LogInformation($"Recebida temperatura para conversão: {temperatura}");

                dados.ValorFahrenheit = temperatura;
                dados.ValorCelsius = (temperatura - 32.0) / 1.8;
                dados.ValorKelvin = dados.ValorCelsius + 273.15;
            }
            catch (Exception err)
            {
                _logger.LogInformation("Ocorreu um problema ao converter");
            }

            _logger.LogInformation($"Resultado concluído: {dados.ValorCelsius}");
            _logger.LogInformation($"Resultado concluído: {dados.ValorFahrenheit}");
            _logger.LogInformation($"Resultado concluído: {dados.ValorKelvin}");

            ArmazenamentoTemperatura.Adicionar(dados);

            return dados;
        }

        // POST txt
        /// <summary>
        /// Registra temperaturasa
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST 
        ///     {
        ///          "valorFahrenheit": 32,
        ///          "valorCelsius": 0,
        ///          "valorKelvin": 273.15
        ///    }
        /// 
        /// </remarks>
        /// <param name="temperatura">Valor em Fahrenheit</param>
        /// <returns>Retorno informações de temperatura em Fahrenheit, em Celsius e Kelvin</returns>
        /// <response code="200">Retorna as temperaturas</response>
        [HttpPost("txt")]
        public ActionResult SalvaTemperaturatxt(Temperatura temperatura)
        {
            _file = new("temperatura.txt");

            _file.WriteLine(temperatura.ValorKelvin);
            _file.WriteLine(temperatura.ValorCelsius);
            _file.WriteLine(temperatura.ValorFahrenheit);

            _file.Close();

            return Ok();
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
        /// <returns>Lista com informações sobre os países a partir do filtro da silga.</returns>
        /// <response code="200">Retorna a listagem resultado do filtro</response>
        [HttpGet("pais-por-sigla")]
        public ActionResult RetornaPaisPorSigla(string sigla)
        {
            var paises = _repositorioPais.ObterPorSigla(sigla);
            return Ok(paises);
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
    }
}
