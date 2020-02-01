using System;
using Newtonsoft.Json;

namespace AnimeOnex.EnvelopeJson.Logic
{
    public class EpisodioEnvelopeJson
    {
        [JsonProperty(PropertyName = "episodioID")]
        public int episodioID { get; set; }

        [JsonProperty(PropertyName = "animeID")]
        public int animeID { get; set; }

        [JsonProperty(PropertyName = "titulo")]
        public string titulo { get; set; }

        [JsonProperty(PropertyName = "vizualizacoes ")]
        public int vizualizacoes { get; set; }

        [JsonProperty(PropertyName = "duracaoMin")]
        public int duracaoMin { get; set; }

        [JsonProperty(PropertyName = "numeroDoEpisodio")]
        public int numeroDoEpisodio { get; set; }

        [JsonProperty(PropertyName = "caminhoDoArquivo")]
        public string caminhoDoArquivo { get; set; }


    }
}