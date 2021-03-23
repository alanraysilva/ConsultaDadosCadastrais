using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaDadosCadastrais.Models
{
    public class OperadorProdataModel
    {
        [JsonProperty(PropertyName = "codigo", Order = 1)]
        public int Codigo { get; set; }

        [JsonProperty(PropertyName = "login", Order = 2)]
        public string Login { get; set; }

        [JsonProperty(PropertyName = "senha", Order = 3)]
        public string Senha { get; set; }
    }
}