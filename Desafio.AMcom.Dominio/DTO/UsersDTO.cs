using Desafio.AMcom.Dominio.Entidades;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Desafio.AMcom.Dominio.DTO
{
    public class UsersDTO
    {
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int Per_page { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("total_pages")]
        public int Total_pages { get; set; }

        [JsonPropertyName("data")]
        public IList<Pessoa> Data { get; set; }

        public UsersDTO()
        {
            Data = new List<Pessoa>();
        }
    }
}
