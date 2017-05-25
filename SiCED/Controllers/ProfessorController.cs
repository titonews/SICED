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
    public class ProfessorController : Controller
    {
        private ContextoEF db = new ContextoEF();

        public ActionResult ConsultarProfessor(int? pagina, string nomeProfessor = null)
        {
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;
            var professor = new Object();

            if (!String.IsNullOrEmpty(nomeProfessor))
            {
                professor = db.Professores
                    .Where(c => c.Nome.ToUpper().Contains(nomeProfessor.ToUpper()))
                    .OrderBy(c => c.Nome)
                    .ToPagedList(numeroPagina, tamanhoPagina);
            }
            else
            {
                professor = db.Professores.OrderBy(p => p.Nome).ToPagedList(numeroPagina, tamanhoPagina);
            }
            return View("Index", professor);
        }

        // GET: Professor
        public ActionResult Index(string ordenacao, int? pagina)
        {
            try
            {
                ViewBag.OrdenacaoAtual = ordenacao;
                ViewBag.NomeParam = String.IsNullOrEmpty(ordenacao) ? "Nome_desc" : "";
                ViewBag.CpfParam = ordenacao == "CPF" ? "CPF_desc" : "CPF";

                int tamanhoPagina = 5;
                int numeroPagina = pagina ?? 1;

                var professor = from c in db.Professores select c;

                switch (ordenacao)
                {
                    case "Nome_desc":
                        professor = professor.OrderByDescending(s => s.Nome);
                        break;
                    case "CPF":
                        professor = professor.OrderBy(s => s.CPF);
                        break;
                    case "CPF_desc":
                        professor = professor.OrderByDescending(s => s.CPF);
                        break;
                    default:
                        professor = professor.OrderBy(s => s.Nome);
                        break;
                }

                // return View(db.Professores.OrderBy(p => p.Nome).ToPagedList(numeroPagina, tamanhoPagina));
                return View(professor.ToPagedList(numeroPagina, tamanhoPagina));

            }
            catch (Exception err)
            {
                ViewBag.DetalheErros = err.Message.ToString();
                return View("Error");
            }
        }

        // GET: Professor/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professores.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professor/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professor/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProfessorId,Nome,CPF,DataNascimento,Endereco,Bairro,CEP,Celular,TelefoneFixo")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professores.Add(professor);
                db.SaveChanges();
                TempData["Mensagem"] = "Professor Cadastrado com sucesso! ";
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        // GET: Professor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professores.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professor/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProfessorId,Nome,CPF,DataNascimento,Endereco,Bairro,CEP,Celular,TelefoneFixo")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Professor atualizado com sucesso! ";
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        // GET: Professor/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professores.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Professor professor = db.Professores.Find(id);
            db.Professores.Remove(professor);
            db.SaveChanges();
            TempData["Mensagem"] = "Professor excluido com sucesso! ";
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
