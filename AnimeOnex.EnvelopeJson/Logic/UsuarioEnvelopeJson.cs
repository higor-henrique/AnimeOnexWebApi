using System;
using Newtonsoft.Json;

namespace AnimeOnex.EnvelopeJson.Logic
{
    public class UsuarioEnvelopeJson
    {
        
        [JsonProperty(PropertyName = "usuarioID")]
        public int ususarioID { get; set; }

        [JsonProperty(PropertyName = "nickname")]
        public string nicknameId { get; set; }

        [JsonProperty(PropertyName = "email")]
        public string email { get; set; }

        [JsonProperty(PropertyName = "senha")]
        public string senha { get; set; }

         
        

    }
}