using ConsultaDadosCadastrais.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

namespace ConsultaDadosCadastrais.Classes
{
    public class Pesquisa
    {
        public List<ConsultaProdataModel> ConsultaDados(DadosConsultaProdataModel dadosConsulta)
        {
            var requisicaoWeb = WebRequest.CreateHttp("https://api.transurc.com.br/Consultas/Gerais/GetUsuarios");
            requisicaoWeb.Method = "POST";
            requisicaoWeb.ContentType = "application/json; charset=utf-8";
            requisicaoWeb.Headers.Add("Authorization", "Basic Y29uc3VsdGFzOldENUw0JGtIR2NLZnIlJCE=");

            using (var streamWriter = new StreamWriter(requisicaoWeb.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(dadosConsulta);
                Debug.Write(json);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                List<ConsultaProdataModel> dados = JsonConvert.DeserializeObject<List<ConsultaProdataModel>>(objResponse.ToString());
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


        public ConsultaQtdeProdataModel ConsultaQtdeDados(DadosConsultaProdataModel dadosConsulta)
        {
            var requisicaoWeb = WebRequest.CreateHttp("https://api.transurc.com.br/Consultas/Gerais/GetQtdetUsuarios");
            requisicaoWeb.Method = "POST";
            requisicaoWeb.ContentType = "application/json; charset=utf-8";
            requisicaoWeb.Headers.Add("Authorization", "Basic Y29uc3VsdGFzOldENUw0JGtIR2NLZnIlJCE=");

            using (var streamWriter = new StreamWriter(requisicaoWeb.GetRequestStream()))
            {
                string json = JsonConvert.SerializeObject(dadosConsulta);
                Debug.Write(json);
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }

            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                ConsultaQtdeProdataModel dados = JsonConvert.DeserializeObject<ConsultaQtdeProdataModel>(objResponse.ToString());
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


        public CadastroProdataModel GetDadosUsuario(int id) 
        {
            var requisicaoWeb = WebRequest.CreateHttp("https://api.transurc.com.br/Consultas/Gerais/Dados/" + id.ToString());
            requisicaoWeb.Method = "GET";
            requisicaoWeb.Headers.Add("Authorization", "Basic Y29uc3VsdGFzOldENUw0JGtIR2NLZnIlJCE=");
            using (var resposta = requisicaoWeb.GetResponse())
            {
                var streamDados = resposta.GetResponseStream();
                StreamReader reader = new StreamReader(streamDados);
                object objResponse = reader.ReadToEnd();
                CadastroProdataModel dados = JsonConvert.DeserializeObject<CadastroProdataModel>(objResponse.ToString());
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