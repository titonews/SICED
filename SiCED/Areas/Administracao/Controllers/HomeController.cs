using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Areas.Administracao.Controllers
{   //Nesse controller apenas o Perfil Administrador tem acesso
    //[Authorize(Roles = "Administrador")]
    public class HomeController : Controller
    {
        [Authorize(Roles = "Administrador")]
        public ActionResult Index()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult Detalhes()
        {
            return View();
        }
        [Authorize(Roles = "Usuário")]
        public ActionResult Usuarios()
        {
            return View();
        }
    }
}