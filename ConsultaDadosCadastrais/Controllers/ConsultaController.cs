using ConsultaDadosCadastrais.Classes;
using ConsultaDadosCadastrais.Models;
using ConsultaDadosCadastrais.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PagedList;
using System.Web.UI.HtmlControls;

namespace ConsultaDadosCadastrais.Controllers
{
    public class ConsultaController : Controller
    {


        public ActionResult Index()
        {
            ViewBag.Filtro = CriaListaMenu();
            ClaimsModel claimsModel = new ClaimsModel();
            claimsModel = Session["Claims"] as ClaimsModel;
            Session["nomeUsuario"] = claimsModel.UserName;
            return View();
                        
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Pesquisar(VmConsulta mdl)
        {
            if (ModelState.IsValid)
            {
                LimparVarTemporarias();

                if (mdl != null)
                {
                    if (mdl.Filtro.Dado != null)
                    {
                        mdl.Filtro.Pagina = 1;
                        mdl.Filtro.QuantidadeLinhas = 10;
                        mdl.Filtro.Paginacao = true;
                        //Preciso Chamar a classe Consulta 
                        Pesquisa pq = new Pesquisa();
                        List<ConsultaProdataModel> lst = new List<ConsultaProdataModel>();
                        lst = pq.ConsultaDados(mdl.Filtro);


                        if (lst.Count > 0)
                        {
                            TempData["ListaResultado"] = lst;
                            Session["FiltroConsulta"] = mdl.Filtro;

                        }
                    }                   
                }

            }
            ViewBag.Filtro = CriaListaMenu();
            return View("Index");
        }

        private void LimparVarTemporarias()
        {
            TempData["ListaResultado"] = null;
            Session["FiltroConsulta"] = null;
            Session["Pagina"] = null;
            Session["Linhas"] = null;
            Session["PaginaRequisitaca"] = null;            
        }

        [HttpGet]
        public PartialViewResult GetResultadoPesquisa()
        {

            List<ConsultaProdataModel> consulta = new List<ConsultaProdataModel>();
            consulta = TempData["ListaResultado"] as List<ConsultaProdataModel>;

            if (consulta != null)
            {
                Pesquisa pq = new Pesquisa();
                ConsultaQtdeProdataModel qtde = new ConsultaQtdeProdataModel();
                qtde = pq.ConsultaQtdeDados(Session["FiltroConsulta"] as DadosConsultaProdataModel);

                int pagina = Convert.ToInt32(Session["Pagina"]);
                int Linhas = Convert.ToInt32(Session["Linhas"]);
                if (pagina == 0) { pagina = 1; }
                if (Linhas == 0) { Linhas = 10; }


                if (qtde.Registros > 0) 
                {
                    ViewBag.Encontradas = qtde.Registros / Linhas;
                }

                return PartialView("_PartConsulta", consulta.ToPagedList(1, Linhas));
            }
            else
            {
                return PartialView("_PartConsulta");
            }
            //return PartialView(consulta);
        }

        [HttpGet]
        public ActionResult SelecionarPagina(int? pagina)
        {

            DadosConsultaProdataModel dados = new DadosConsultaProdataModel();
            dados = Session["FiltroConsulta"] as DadosConsultaProdataModel;
            dados.Pagina = (int)pagina;
            Pesquisa pq = new Pesquisa();
            List<ConsultaProdataModel> lst = new List<ConsultaProdataModel>();
            lst = pq.ConsultaDados(dados);
            if (lst.Count > 0)
            {
                TempData["ListaResultado"] = lst;
                Session["Pagina"] = pagina;
                Session["Linhas"] = 10;
                Session["PaginaRequisitaca"] = pagina;
            }
            ViewBag.Filtro = CriaListaMenu();
            return View("Index");
        }

        [HttpGet]
        public ActionResult CarregarDados(int idUsuario, int pagina = 1)
        {
            CadastroProdataModel cadastroProdata = null;
            if (ModelState.IsValid)
            {
                if (Session["AccessToken"] != null)
                {
                    if (idUsuario > 0)
                    {
                        //Preciso Chamar a classe Consulta 
                        Pesquisa pq = new Pesquisa();
                        cadastroProdata = new CadastroProdataModel();
                        cadastroProdata = pq.GetDadosUsuario(idUsuario);
                        // Formatando Dados
                        cadastroProdata.Cpf = RotinasFormatacao.FormataCpf(cadastroProdata.Cpf);
                        if (cadastroProdata.Endereco != null)
                        {
                            cadastroProdata.Endereco.Cep = RotinasFormatacao.FormataCep(cadastroProdata.Endereco.Cep);
                        }
                        cadastroProdata.Telefone = RotinasFormatacao.FormataTelefone(cadastroProdata.Telefone);
                        cadastroProdata.Celular = RotinasFormatacao.FormataTelefone(cadastroProdata.Celular);
                        cadastroProdata.Recado = RotinasFormatacao.FormataTelefone(cadastroProdata.Recado);
                        Session["PaginaRequisitaca"] = pagina;
                    }

                }
                else
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            ViewBag.Pagina = pagina;
            return View("DadosCadastrais", cadastroProdata);
        }



        private SelectList CriaListaMenu()
        {
            ItemFiltro it1 = new ItemFiltro();
            it1.Id = 1;
            it1.Descricao = "CPF";

            ItemFiltro it2 = new ItemFiltro();
            it2.Id = 2;
            it2.Descricao = "NOME";

            ItemFiltro it3 = new ItemFiltro();
            it3.Id = 3;
            it3.Descricao = "NOME DA MÃE";


            List<ItemFiltro> lst = new List<ItemFiltro>();
            lst.Add(it1);
            lst.Add(it2);
            lst.Add(it3);


            return new SelectList(lst, "Id", "Descricao");

        }
    }
}