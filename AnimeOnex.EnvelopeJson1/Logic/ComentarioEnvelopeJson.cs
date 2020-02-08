using System;
using Newtonsoft.Json;



namespace AnimeOnex.EnvelopeJson.Logic
{
    public class ComentarioEnvelopeJson
    {
        [JsonProperty(PropertyName = "comentarioID")]
        public int comentarioID { get; set; }

        [JsonProperty(PropertyName = "usuarioID")]
        public int usuarioID { get; set; }

        [JsonProperty(PropertyName = "episodioID")]
        public int episodioID { get; set; }

        [JsonProperty(PropertyName = "texto")]
        public string texto { get; set; }

        [JsonProperty(PropertyName = "dataComentario")]
        public DateTime? dataComentario { get; set; }

    }
}

