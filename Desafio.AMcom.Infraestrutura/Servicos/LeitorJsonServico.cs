namespace Desafio.AMcom.Infraestrutura.Servicos
{
    public class LeitorJsonServico
    {
        public static string Ler(string url)
        {
            var conteudo = System.IO.File.ReadAllText(url);

            return conteudo;
        }
    }
}
