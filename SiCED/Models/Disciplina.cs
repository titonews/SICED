using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiCED.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Turma> Turmas { get; set; }
        //public virtual Matricula Matricula { get; set; }

    }
}