using Desafio.AMcom.Dominio.IRepositorios;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;

namespace Desafio.AMcom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemperaturasController : ControllerBase
    {
        private ILogger<TemperaturasController> _logger;
        private readonly IRepositorioPais _repositorioPais;
        private readonly IRepositorioPessoa _repositorioPessoa;

        public TemperaturasController(ILogger<TemperaturasController> logger, IRepositorioPais repositorioPais, IRepositorioPessoa repositorioPessoa)
        {
            _logger = logger;
            _repositorioPais = repositorioPais;
            _repositorioPessoa = repositorioPessoa;
        }

        [HttpGet("Fahrenheit/{temperatura}")]
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

            return dados;
        }

        [HttpPost("txt")]
        public ActionResult SalvaTemperaturatxt(Temperatura temperatura)
        {
            StreamWriter file = new("temperatura.txt");
            
            file.WriteLine(temperatura.ValorKelvin);
            file.WriteLine(temperatura.ValorCelsius);
            file.WriteLine(temperatura.ValorFahrenheit);

            return Ok();
        }

        [HttpGet("paises")]
        public ActionResult RetornaPaises()
        {
            var paises = _repositorioPais.ObterTodos();

            return Ok(paises);
        }

        [HttpGet("pais-por-sigla")]
        public ActionResult RetornaPaisPorSigla(string sigla)
        {
            var paises = _repositorioPais.ObterPorSigla(sigla);
            return Ok(paises);
        }

        [HttpGet("dados-api-pessoa")]
        public ActionResult RetornaDadosApiUser()
        {
            var userDto = _repositorioPessoa.ObterDadosAPI();

            return Ok(userDto);
        }
    }
}
