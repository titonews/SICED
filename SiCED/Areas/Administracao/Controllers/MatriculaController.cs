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
using Rotativa;

namespace Areas.Administracao.Controllers
{

    public class MatriculaController : Controller
    {
        private ContextoEF db = new ContextoEF();

        public ActionResult GerarPDF(int id)
        {
            var modelo = db.Matriculas.Find(id);

            var pdf = new ViewAsPdf
            {
                ViewName = "DetailsParaImpressao",
                Model = modelo
            };

            return pdf;
        }


        public ActionResult ConsultarTurma(int? pagina, string NomeTurma = null)
        {
            int tamanhoPagina = 5;
            int numeroPagina = pagina ?? 1;

            var matricula = (from a in db.Alunos
                             join m in db.Matriculas
                             on a.AlunoId equals m.AlunoId
                             join t in db.Turmas
                             on m.TurmaId equals t.Id
                              select m).ToList();


            if (!String.IsNullOrEmpty(NomeTurma))
            {
                matricula = matricula
                    .Where(x => 
                            x.Turma.Descricao.ToUpper()
                            .Contains(NomeTurma.ToUpper())).ToList();

            }

              return View("Index" , matricula.OrderBy(p => p.Turma.Descricao).ToPagedList(numeroPagina, tamanhoPagina));
        }



        // GET: Matricula
        public ActionResult Index(int? pagina)
        {
            try
            {
                int tamanhoPagina = 5;
                int numeroPagina = pagina ?? 1; 

            //var matriculas = db.Matriculas.Include(m => m.Aluno).Include(m => m.Turma);
            return View(db.Matriculas.OrderBy(p => p.DataDeMatricula).ToPagedList(numeroPagina, tamanhoPagina));
            }
            catch(Exception err)
            {
                ViewBag.DetalheErros = err.Message.ToString();
                return View("Error");
            }
        }

        // GET: Matricula/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // GET: Matricula/Create
        public ActionResult Create()
        {
            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome");
            ViewBag.TurmaId = new SelectList(db.Turmas, "Id", "Descricao");
            return View();
        }

        // POST: Matricula/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,AlunoId,TurmaId,DataDeMatricula")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Matriculas.Add(matricula);
                db.SaveChanges();
                TempData["Mensagem"] = "Matricula cadastrada com sucesso! ";
                return RedirectToAction("Index");
            }

            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome", matricula.AlunoId);
            ViewBag.TurmaId = new SelectList(db.Turmas, "Id", "Descricao", matricula.TurmaId);
            return View(matricula);
        }

        // GET: Matricula/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome", matricula.AlunoId);
            ViewBag.TurmaId = new SelectList(db.Turmas, "Id", "Descricao", matricula.TurmaId);
            return View(matricula);
        }

        // POST: Matricula/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,AlunoId,TurmaId,DataDeMatricula")] Matricula matricula)
        {
            if (ModelState.IsValid)
            {
                db.Entry(matricula).State = EntityState.Modified;
                db.SaveChanges();
                TempData["Mensagem"] = "Matricula atualizada com sucesso! ";
                return RedirectToAction("Index");
            }
            ViewBag.AlunoId = new SelectList(db.Alunos, "AlunoId", "Nome", matricula.AlunoId);
            ViewBag.TurmaId = new SelectList(db.Turmas, "Id", "Descricao", matricula.TurmaId);
            return View(matricula);
        }

        // GET: Matricula/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Matricula matricula = db.Matriculas.Find(id);
            if (matricula == null)
            {
                return HttpNotFound();
            }
            return View(matricula);
        }

        // POST: Matricula/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Matricula matricula = db.Matriculas.Find(id);
            db.Matriculas.Remove(matricula);
            db.SaveChanges();
            TempData["Mensagem"] = "Matricula excluida com sucesso! ";
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
