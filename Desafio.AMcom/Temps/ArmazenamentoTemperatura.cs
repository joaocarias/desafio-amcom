using Desafio.AMcom.Controllers;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.AMcom.Temps
{
    public static class ArmazenamentoTemperatura
    {
        private static IList<Temperatura> temperaturas;
        
        public static void Adicionar(Temperatura temperatura)
        {
            if(temperaturas == null || !temperaturas.Any())
            {
                temperaturas = new List<Temperatura>();
            }

            temperaturas.Add(temperatura);
        }
    }

}
