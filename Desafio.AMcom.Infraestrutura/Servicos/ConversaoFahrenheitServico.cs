
namespace Desafio.AMcom.Infraestrutura.Servicos
{
    public static class ConversaoFahrenheitServico
    {
        public static double ValorCelsius(double temperatura)
        {
            return (temperatura - 32.0) / 1.8;
        }

        public static double ValorKelvin(double temperatura)
        {
            return ValorCelsius(temperatura) + 273.15;
        }
    }
}
