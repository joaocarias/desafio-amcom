using Desafio.AMcom.Infraestrutura.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.AMcom.Testes
{
    public class TesteTemperaturaServico
    {
        [Fact]
        public void TestarValorCelsius()
        {
            var fahrenheit = 32.0;

            var resultado = ConversaoFahrenheitServico.ValorCelsius(fahrenheit);
            Assert.Equal(0, resultado);
        }

        [Fact]
        public void TestarValorKelvin()
        {
            var fahrenheit = 32.0;

            var resultado = ConversaoFahrenheitServico.ValorKelvin(fahrenheit);
            Assert.Equal(273.15, resultado);
        }
    }
}
