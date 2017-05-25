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
    public class TurmaController : Controller
    {
        private ContextoEF db = new ContextoEF();

        // GET: Turma
        public ActionResult Index(int? pagina)
        {
            try
            {
                int tamanhopagina = 5;
                int numeroPagina = pagina ?? 1;

            var turmas = db.Turmas.Include(t => t.Curso).Include(t => t.Disciplina).Include(t => t.Professor);

                return View(turmas.OrderBy(p => p.Descricao).ToPagedList(numeroPagina, tamanhopagina));
            }
            catch(Exception err)
            {
                ViewBag.DetalheErros = err.Message.ToString();
                return View("Error");
            }
        }

        // GET: Turma/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // GET: Turma/Create
        public ActionResult Create()
        {
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome");
            ViewBag.DisciplinaId = new SelectList(db.Disciplinas, "Id", "Nome");
            ViewBag.ProfessorId = new SelectList(db.Professores, "ProfessorId", "Nome");
            return View();
        }

        // POST: Turma/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,ValorMensal,HorarioInicial,HorarioFinal,SegundaQuarta,SegundaQuartaSexta,TercaQuinta,TercaQuintaSexta,ProfessorId,CursoId,DisciplinaId")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Turmas.Add(turma);
                db.SaveChanges();
                TempData["Mensagem"] = "Turma Cadastrado com sucesso! ";
                return RedirectToAction("Index");
            }

            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome", turma.CursoId);
            ViewBag.DisciplinaId = new SelectList(db.Disciplinas, "Id", "Nome", turma.DisciplinaId);
            ViewBag.ProfessorId = new SelectList(db.Professores, "ProfessorId", "Nome", turma.ProfessorId);
            return View(turma);
        }

        // GET: Turma/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome", turma.CursoId);
            ViewBag.DisciplinaId = new SelectList(db.Disciplinas, "Id", "Nome", turma.DisciplinaId);
            ViewBag.ProfessorId = new SelectList(db.Professores, "ProfessorId", "Nome", turma.ProfessorId);
            return View(turma);
        }

        // POST: Turma/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,ValorMensal,HorarioInicial,HorarioFinal,SegundaQuarta,SegundaQuartaSexta,TercaQuinta,TercaQuintaSexta,ProfessorId,CursoId,DisciplinaId")] Turma turma)
        {
            if (ModelState.IsValid)
            {
                db.Entry(turma).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Turma atualizada com sucesso! ";
                return RedirectToAction("Index");
            }
            ViewBag.CursoId = new SelectList(db.Cursos, "Id", "Nome", turma.CursoId);
            ViewBag.DisciplinaId = new SelectList(db.Disciplinas, "Id", "Nome", turma.DisciplinaId);
            ViewBag.ProfessorId = new SelectList(db.Professores, "ProfessorId", "Nome", turma.ProfessorId);
            return View(turma);
        }

        // GET: Turma/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Turma turma = db.Turmas.Find(id);
            if (turma == null)
            {
                return HttpNotFound();
            }
            return View(turma);
        }

        // POST: Turma/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Turma turma = db.Turmas.Find(id);
            db.Turmas.Remove(turma);
            db.SaveChanges();
            TempData["Mensagem"] = "Turma excluida com sucesso! ";
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
