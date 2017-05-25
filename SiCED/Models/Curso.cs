using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SiCED.Models
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public virtual ICollection<Disciplina> Disciplinas { get; set; }
    }
}