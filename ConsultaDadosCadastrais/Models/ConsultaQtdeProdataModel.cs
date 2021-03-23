using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaDadosCadastrais.Models
{
    public class ConsultaQtdeProdataModel
    {
        [JsonProperty(PropertyName = "registros", Order = 3)]
        public int Registros { get; set; }
    }
}