using ConsultaDadosCadastrais.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ConsultaDadosCadastrais.Classes
{
    public class Login
    {
        public OperadorProdataModel ObterLoginApi(string login) 
        {
            var requisicaoWeb = WebRequest.CreateHttp("https://api.transurc.com.br/Consultas/Gerais/GetLogin/" + login.ToUpper());
            requisicaoWeb.Method = "GET";
            requisicaoWeb.Headers.Add("Authorization", "Basic Y29uc3VsdGFzOldENUw0JGtIR2NLZnIlJCE=");
            using (var resposta = requisicaoWeb.GetResponse()) 
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                OperadorProdataModel dados = JsonConvert.DeserializeObject<OperadorProdataModel>(objResponse.ToString());
                streamDados.Close();
                resposta.Close();
                if (dados != null)
                    return dados;
                else 
                {
                    return null;
                }
            }
            
        }
    }
}