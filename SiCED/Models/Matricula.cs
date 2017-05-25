using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiCED.Models
{
    public class Matricula
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }
        public int TurmaId { get; set; }
        //public int ProfessorId { get; set; }
        public DateTime DataDeMatricula { get; set; }
        public virtual Turma Turma { get; set; }
        public virtual Aluno Aluno { get; set; }

        //public virtual Professor Professor { get; set; }

        //public virtual ICollection<Aluno> Aluno { get; set; }
        //public virtual ICollection<Turma> Turma { get; set; }
        
        
        

    }
}