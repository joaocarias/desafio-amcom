using System.Text.Json.Serialization;

namespace Desafio.AMcom.Dominio.Entidades
{
    public class Pessoa
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string First_name { get; set; }

        [JsonPropertyName("last_name")]
        public string Last_name { get; set; }

        [JsonPropertyName("avatar")]
        public string Avatar { get; set; }
    }
}
