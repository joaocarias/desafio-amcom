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
        public int PerPage { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("total_pages")]
        public int TotalPages { get; set; }

        [JsonPropertyName("data")]
        public IList<Pessoa> Pessoas { get; set; }
    }
}
