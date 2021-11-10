using Desafio.AMcom.Infraestrutura.Servicos;
using Desafio.AMcom.Temps;
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
 
        public TemperaturasController(ILogger<TemperaturasController> logger)
        {
            _logger = logger;                          
        }

        // GET fahrenheit
        /// <summary>
        /// Obter valores de temperaturas a partir de Fahrenheit
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     GET /fahrenheit/32.0
        /// 
        /// </remarks>
        /// <param name="temperatura">Valor em Fahrenheit (é comum dar a temperatuda em decimal)</param>
        /// <returns>Retorno informações de temperatura em Fahrenheit, em Celsius e Kelvin</returns>
        /// <response code="200">Retorna as temperaturas</response>
        [HttpGet("fahrenheit/{temperatura}")]
        public object GetConversaoFahrenheit(double temperatura)
        {
            Temperatura dados = new Temperatura();

            try
            {
                _logger.LogInformation($"Recebida temperatura para conversão: {temperatura}");

                dados.ValorFahrenheit = temperatura;
                dados.ValorCelsius = ConversaoFahrenheitServico.ValorCelsius(temperatura);
                dados.ValorKelvin = ConversaoFahrenheitServico.ValorKelvin(temperatura);
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
        /// Registra temperaturas em um arquivo txt
        /// </summary>
        /// <remarks>
        /// Exemplo:
        ///
        ///     POST 
        ///     {
        ///          "valorFahrenheit": 32,
        ///          "valorCelsius": 0,
        ///          "valorKelvin": 273.15
        ///      }
        /// 
        /// </remarks>
        /// <param name="valorFahrenheit">Valor em Fahrenheit</param>
        /// <param name="valorCelsius">Valor em Celsius</param>
        /// <param name="valorKelvin">Valor em Kelvin</param>
        /// <returns>Sem retorno</returns>
        /// <response code="200">Retorno os valores cadastrados</response>
        [HttpPost("txt")]
        public ActionResult SalvaTemperaturatxt(Temperatura temperatura)
        {

            using (StreamWriter file = new StreamWriter("temperatura.txt", true))
            {
                file.WriteLine(temperatura.ValorKelvin);
                file.WriteLine(temperatura.ValorCelsius);
                file.WriteLine(temperatura.ValorFahrenheit);

                file.Close();
            }

            return Ok(temperatura);
        }
    }
}
