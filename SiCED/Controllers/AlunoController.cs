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

namespace SiCED.Controllers
{
    public class AlunoController : Controller
    {
        private ContextoEF db = new ContextoEF();

        public ActionResult ConsultarAluno(int? pagina, string nomeAluno = null)
        {
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            var aluno = new Object();

            if (!String.IsNullOrEmpty(nomeAluno))
            {
                aluno = db.Alunos
                    .Where(c => c.Nome.ToUpper().Contains(nomeAluno.ToUpper()))
                    .OrderBy(c => c.Nome)
                    .ToPagedList(numeroPagina, tamanhoPagina);
            }
            else
            {
                aluno = db.Alunos.OrderBy(p => p.Nome).ToPagedList(numeroPagina, tamanhoPagina);
            }
            return View("Index", aluno);
        }

        // GET: Aluno
        public ActionResult Index(string ordenacao, int? pagina)
        {
            try
            {
                ViewBag.OrdenacaoAtual = ordenacao;
                ViewBag.NomeParam = String.IsNullOrEmpty(ordenacao) ? "Nome_desc" : "";
                ViewBag.CpfParam = ordenacao == "CPF" ? "CPF_desc" : "CPF";

                var alunos = from c in db.Alunos select c;

                int tamnahoPagina = 5;
                int numeroPagina = pagina ?? 1;

                switch (ordenacao)
                {
                    case "Nome_desc":
                        alunos = alunos.OrderByDescending(s => s.Nome);
                        break;
                    case "CPF":
                        alunos = alunos.OrderBy(s => s.CPF);
                        break;
                    case "CPF_desc":
                        alunos = alunos.OrderByDescending(s => s.CPF);
                        break;
                    default:
                        alunos = alunos.OrderBy(s => s.Nome);
                        break;
                }

                //var alunos = db.Alunos.Include(a => a.Responsaveis);
                // return View(db.Alunos.OrderBy(p => p.Nome).ToPagedList(numeroPagina, tamnahoPagina));
                return View(alunos.ToPagedList(numeroPagina, tamnahoPagina));
            }

            catch(Exception err)
            {
                ViewBag.DetalheErros = err.Message.ToString();
                return View("Error");
            }
        }

        // GET: Aluno/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // GET: Aluno/Create
        public ActionResult Create()
        {
            ViewBag.ResponsavelId = new SelectList(db.Responsaveis, "ResponsavelId", "Nome");
            return View();
        }

        // POST: Aluno/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AlunoId,ResponsavelId,Nome,CPF,Celular,DataNascimento")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Alunos.Add(aluno);
                db.SaveChanges();
                TempData["Mensagem"] = "Aluno cadastrado com sucesso! ";
                return RedirectToAction("Index");
            }

            ViewBag.ResponsavelId = new SelectList(db.Responsaveis, "ResponsavelId", "Nome", aluno.ResponsavelId);
            return View(aluno);
        }

        // GET: Aluno/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            ViewBag.ResponsavelId = new SelectList(db.Responsaveis, "ResponsavelId", "Nome", aluno.ResponsavelId);
            return View(aluno);
        }

        // POST: Aluno/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AlunoId,ResponsavelId,Nome,CPF,Celular,DataNascimento")] Aluno aluno)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Aluno atualizado com sucesso! ";
                return RedirectToAction("Index");
            }
            ViewBag.ResponsavelId = new SelectList(db.Responsaveis, "ResponsavelId", "Nome", aluno.ResponsavelId);
            return View(aluno);
        }

        // GET: Aluno/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aluno aluno = db.Alunos.Find(id);
            if (aluno == null)
            {
                return HttpNotFound();
            }
            return View(aluno);
        }

        // POST: Aluno/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aluno aluno = db.Alunos.Find(id);
            db.Alunos.Remove(aluno);
            db.SaveChanges();
            TempData["Mensagem"] = "Aluno excluido com sucesso! ";
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
