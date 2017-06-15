using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiCED.Models
{
    public class Aluno
    {
        public int AlunoId { get; set; }
        public int ResponsavelId { get; set; }

        [Required(ErrorMessage = "Obrigado informar o Nome")]
        [StringLength(200, ErrorMessage = "O nome deve possuir no máximo 200 caracteres")]
        [Display(Name = "Nome do Aluno")]
        public string Nome { get; set; }
        public string CPF { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatorio [ formato: (00) 00000-0000 ]")]
        [RegularExpression(@"^\(\d{2}\)\d{5}-\d{4}$", ErrorMessage = " Telefone inválido")]
        [Display(Name = " Celular [ formato (00) 00000-0000 ]")]
        public string Celular { get; set; }

        [Required]
        //[DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Display(Name = "Data de Nascimento")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataNascimento { get; set; }

        public virtual Responsavel Responsaveis { get; set; }
        public virtual ICollection<Matricula> Matricula { get; set; }
    }
}