using SiCED.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SiCED.Areas.Administracao.Controllers
{
    public class RelatorioController : Controller
    {
        ContextoEF contexto = new ContextoEF();

        public ActionResult TotalDeAlunoPorCurso()
        {

            return View();
        }


    }
}