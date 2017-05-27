using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SiCED.Models;
using PagedList;

namespace Areas.Administracao.Controllers
{
    public class ResponsavelController : Controller
    {
        private ContextoEF db = new ContextoEF();

        public ActionResult ConsultarResponsavel(int? pagina, string nomeResponsavel = null)
        {
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            var responsavel = new Object();

            if (!String.IsNullOrEmpty(nomeResponsavel))
            {
                responsavel = db.Responsaveis
                    .Where(c => c.Nome.ToUpper().Contains(nomeResponsavel.ToUpper()))
                    .OrderBy(c => c.Nome)
                    .ToPagedList(numeroPagina, tamanhoPagina);
            }
            else
            {
                responsavel = db.Responsaveis.OrderBy(p => p.Nome).ToPagedList(numeroPagina, tamanhoPagina);
            }
            return View("Index", responsavel);
        }

        // GET: Responsavel
        public ActionResult Index(string ordenacao, int? pagina)
        {
            try
            {
                ViewBag.OrdenacaoAtual = ordenacao;
                ViewBag.NomeParam = String.IsNullOrEmpty(ordenacao) ? "Nome_desc" : "";
                ViewBag.CpfParam = ordenacao == "CPF" ? "CPF_desc" : "CPF";

                var responsavel = from c in db.Responsaveis select c;

                int tamanhoPagina = 5;
                int numeroPagina = pagina ?? 1;

                switch (ordenacao)
                {
                    case "Nome_desc":
                        responsavel = responsavel.OrderByDescending(s => s.Nome);
                        break;
                    case "CPF":
                        responsavel = responsavel.OrderBy(s => s.CPF);
                        break;
                    case "CPF_desc":
                        responsavel = responsavel.OrderByDescending(s => s.CPF);
                        break;
                    default:
                        responsavel = responsavel.OrderBy(s => s.Nome);
                        break;
                }

                // return View(db.Responsaveis.OrderBy(p => p.Nome).ToPagedList(numeroPagina, tamanhoPagina));
                return View(responsavel.ToPagedList(numeroPagina, tamanhoPagina));
            }

            catch (Exception err)
            {
                ViewBag.DetalheErros = err.Message.ToString();
                return View("Error");
            }
        }

        // GET: Responsavel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = db.Responsaveis.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // GET: Responsavel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Responsavel/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ResponsavelId,Nome,CPF,Endereco,CEP,Bairro,Cidade,Celular,TelefoneFixo")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                db.Responsaveis.Add(responsavel);
                db.SaveChanges();
                TempData["Mensagem"] = "Responsavel Cadastrado com sucesso! ";
                return RedirectToAction("Index");
            }

            return View(responsavel);
        }

        // GET: Responsavel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = db.Responsaveis.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // POST: Responsavel/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ResponsavelId,Nome,CPF,Endereco,CEP,Bairro,Cidade,Celular,TelefoneFixo")] Responsavel responsavel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(responsavel).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Responsavel atualizado com sucesso! ";
                return RedirectToAction("Index");
            }
            return View(responsavel);
        }

        // GET: Responsavel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Responsavel responsavel = db.Responsaveis.Find(id);
            if (responsavel == null)
            {
                return HttpNotFound();
            }
            return View(responsavel);
        }

        // POST: Responsavel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Responsavel responsavel = db.Responsaveis.Find(id);
            db.Responsaveis.Remove(responsavel);
            db.SaveChanges();
            TempData["Mensagem"] = "Responsavel excluido com sucesso! ";
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
