using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiCED.Models
{
    public class Turma
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public decimal ValorMensal { get; set; }
        public string HorarioInicial { get; set; }
        public string HorarioFinal { get; set; }

        [Display(Name = "Escolha o dia da Turma - Segunda e Quarta")]
        public bool SegundaQuarta { get; set; }

        [Display(Name = "Escolha o dia da Turma - Segunda,Quarta e Sexta")]
        public bool SegundaQuartaSexta { get; set; }

        [Display(Name = "Escolha o dia da Turma - Terça e Quinta")]
        public bool TercaQuinta { get; set; }

        [Display(Name = "Escolha o dia da Turma - Terça, Quinta e Sexta")]
        public bool TercaQuintaSexta { get; set; }

        public virtual ICollection<Matricula> Matriculas { get; set; }
        public int ProfessorId { get; set; }
        public virtual Professor Professor { get; set; }
        public int CursoId { get; set; }
        public virtual Curso Curso { get; set; }
        public virtual Disciplina Disciplina { get; set; }
        public int DisciplinaId { get; set; }
        

        //public virtual Matricula Matricula { get; set; }
        //public virtual ICollection<Professor> Professor { get; set; }
        //public virtual ICollection<Curso> Curso { get; set; }

    }
}