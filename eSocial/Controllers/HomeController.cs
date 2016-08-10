using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Portal.Business.Repositories;
using System.Text;
using Portal.Business.Models;

namespace eSocial.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            return View();
        }

        public void Export()
        {
            StringBuilder sb = new StringBuilder();
            
            var lst = (List<ValidateUsuario>)Session["VALIDAR"];

            sb.AppendFormat("Funcionario;Campo;Erro{0}", Environment.NewLine);

            foreach (var item in lst)
                sb.AppendFormat("{0};{1};{2};{3}", item.nome_usuario, item.campo, item.erro, Environment.NewLine);

            Response.Clear();
            Response.AddHeader("Content-Disposition", "attachment; filename=eSocial.csv");
            Response.ContentType = "text/csv";
            Response.Write(sb.ToString());
            Response.End();
        }

        public ActionResult About()
        {

            var userRep = EFUnitOfWork.GetRepository<UsuarioRepository>();

            var validar = userRep.Validar();

            this.ViewData.Model = validar;

            Session["VALIDAR"] = validar;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}