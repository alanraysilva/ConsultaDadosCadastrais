using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Web;

namespace ConsultaDadosCadastrais.Models
{
    public class CadastroProdataModel
    {
        [JsonProperty(PropertyName = "codigo", Order = 1)]
        public int Codigo { get; set; }

        [JsonProperty(PropertyName = "nome", Order = 2)]
        public string Nome { get; set; }

        [JsonProperty(PropertyName = "sexo", Order = 3)]
        public string Sexo { get; set; }


        [DisplayFormat(DataFormatString = "{0: dd/MM/yyyy}")]
        [JsonProperty(PropertyName = "nascimento", Order = 4)]
        public DateTime Nascimento { get; set; }

        [JsonProperty(PropertyName = "estadoCivil", Order = 5)]
        public string EstadoCivil { get; set; }

        [JsonProperty(PropertyName = "pai", Order = 6)]
        public string Pai { get; set; }

        [JsonProperty(PropertyName = "mae", Order = 7)]
        public string Mae { get; set; }

        [JsonProperty(PropertyName = "cpf", Order = 8)]
        public string Cpf { get; set; }

        [JsonProperty(PropertyName = "rg", Order = 9)]
        public string Rg { get; set; }

        [JsonProperty(PropertyName = "certidao", Order = 10)]
        public string Certidao { get; set; }

        [JsonProperty(PropertyName = "Endereco", Order = 11)]
        public EnderecoProdata Endereco { get; set; }

        [JsonProperty(PropertyName = "email", Order = 12)]
        public string Email { get; set; }

        [JsonProperty(PropertyName = "celular", Order = 13)]
        public string Celular { get; set; }

        [JsonProperty(PropertyName = "telefone", Order = 14)]
        public string Telefone { get; set; }

        [JsonProperty(PropertyName = "recado", Order = 15)]
        public string Recado { get; set; }


    }
    public class EnderecoProdata
    {
        [JsonProperty(PropertyName = "idEndereco", Order = 2)]
        public int IdEndereco { get; set; }

        [JsonProperty(PropertyName = "rua", Order = 2)]
        public string rua { get; set; }

        [JsonProperty(PropertyName = "numero", Order = 3)]
        public string Numero { get; set; }

        [JsonProperty(PropertyName = "complemento", Order = 4)]
        public string Complemento { get; set; }

        [JsonProperty(PropertyName = "bairro", Order = 5)]
        public string Bairro { get; set; }

        [JsonProperty(PropertyName = "cep", Order = 6)]
        public string Cep { get; set; }

        [JsonProperty(PropertyName = "cidade", Order = 7)]
        public string Cidade { get; set; }

    }
}