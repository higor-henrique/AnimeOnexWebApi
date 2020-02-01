using System;
using Newtonsoft.Json;

namespace AnimeOnex.EnvelopeJson.Logic
{
    public class AnimeEnvelopeJson
    {
        [JsonProperty(PropertyName = "animeID")]
        public int animeID { get; set; }

        [JsonProperty(PropertyName = "titulo")]
        public string titulo { get; set; }

        [JsonProperty(PropertyName = "dataEstreia")]
        public DateTime? dataEstreia { get; set; }

        [JsonProperty(PropertyName = "numeroDeTemporadas")]
        public int numeroDeTemporadas { get; set; }

        [JsonProperty(PropertyName = "quantidadeDeEpisodios")]
        public int quantidadeDeEpisodios { get; set; }

        [JsonProperty(PropertyName = "studio")]
        public string studio { get; set; }

        [JsonProperty(PropertyName = "studio")]
        public string sinopse { get; set; }

        [JsonProperty(PropertyName = "studio")]
        public string caminhoDaImagem { get; set; }

    }
}