using ConsultaDadosCadastrais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;

namespace ConsultaDadosCadastrais.Models.ViewModels
{
    public class VmConsulta
    {

        public DadosConsultaProdataModel Filtro { get; set; }
        public List<ConsultaProdataModel> Resultado { get; set; }
        public ClaimsModel Claims { get; set; }


    }
}