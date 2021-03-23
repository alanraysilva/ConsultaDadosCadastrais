using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConsultaDadosCadastrais.Models
{
    public class ClaimsModel
    {
        public string AudApp { get; set; }
        public string RealmAccess { get; set; }
        public string ResourceAccess { get; set; }
        public string UserName { get; set; }        
        public List<Roles> Roles = new List<Roles>();

    }
    public class Roles
    {
        public string Nome { get; set; }

    }
}