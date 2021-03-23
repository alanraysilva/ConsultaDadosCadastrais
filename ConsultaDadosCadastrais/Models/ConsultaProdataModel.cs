using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaDadosCadastrais.Models
{
    public class ConsultaProdataModel
    {
        [JsonProperty(PropertyName = "codigo", Order = 1)]
        public int Codigo { get; set; }

        [JsonProperty(PropertyName = "nome", Order = 2)]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "mae", Order = 3)]
        public string Mae { get; set; }

        [JsonProperty(PropertyName = "nascimento", Order = 4)]
        public DateTime Nascimento { get; set; }

        [JsonProperty(PropertyName = "rn", Order = 5)]
        public int rn { get; set; }


    }
}