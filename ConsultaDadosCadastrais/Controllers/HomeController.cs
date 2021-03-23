using ConsultaDadosCadastrais.Classes;
using ConsultaDadosCadastrais.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace ConsultaDadosCadastrais.Controllers
{    
    public class HomeController : Controller
    {
        

        [Authorize]
        public ActionResult Index()
        {           
            Session["Claims"] = ObtemDadosLogin();
            return RedirectToAction("Index", "Consulta");
        }

        public ActionResult Consulta() 
        {            
            return RedirectToAction("Index", "Consulta");
        }

        public ClaimsModel ObtemDadosLogin() 
        {
            var userPrinciple = User as ClaimsPrincipal;
            Session["AccessToken"] = userPrinciple.Claims.First(claim => claim.Type == "access_token").Value;
            Session["nomeUsuario"] = userPrinciple.Identity.Name;

            //var jwt = userPrinciple.Claims.First(claim => claim.Type == "access_token").Value;
            //var handler = new JwtSecurityTokenHandler();
            //var token = handler.ReadJwtToken(jwt);

            var stream = userPrinciple.Claims.First(claim => claim.Type == "access_token").Value;
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;
            ClaimsModel mdl = new ClaimsModel();
            Roles roles = new Roles();
            foreach (var item in tokenS.Claims)
            {
                if (item.Type == "azp")
                    mdl.AudApp = item.Value;
                if (item.Type == "realm_access")
                    mdl.RealmAccess = item.Value;
                if (item.Type == "resource_access")
                    mdl.ResourceAccess = item.Value;
                if (item.Type == "preferred_username")
                    mdl.UserName = item.Value;
                if (item.Type == "user_roles")
                {
                    roles.Nome = item.Value;
                    mdl.Roles.Add(roles);
                }

            }
            return mdl;
        }

        public ActionResult Sair()
        {
            HttpContext.GetOwinContext().Authentication.SignOut();

            return RedirectToAction("Consulta");
        }
    }
}