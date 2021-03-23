using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ConsultaDadosCadastrais.Models
{
    public class DadosConsultaProdataModel
    {
        [JsonProperty(PropertyName = "tipo", Order = 1)]
        public int Tipo { get; set; }

        [JsonProperty(PropertyName = "dado", Order = 2)]
        public string Dado { get; set; }

        [JsonProperty(PropertyName = "pagina", Order = 3)]
        public int Pagina { get; set; }

        [JsonProperty(PropertyName = "linhas", Order = 4)]
        public int QuantidadeLinhas { get; set; }

        [JsonProperty(PropertyName = "paginacao", Order = 5)]
        public bool Paginacao { get; set; }
    }
}