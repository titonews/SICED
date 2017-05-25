using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SiCED.Models
{
    public class Professor
    {
        public int ProfessorId { get; set; }

        [Required(ErrorMessage = "Obrigado informar o Nome")]
        [StringLength(200, ErrorMessage = "O nome deve possuir no máximo 200 caracteres")]
        [Display(Name = "Nome Completo")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo e obrigatótio")]
        [MinLength(14, ErrorMessage = "O tamanho mínimo são 11 caracteres.")]
        [StringLength(14, ErrorMessage = "Limite de 11 caracteres")]
        [Display(Name = "CPF")]
        public string CPF { get; set; }

        [Required]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        [Display(Name = "Data de Nascimento")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Obrigatório informar o Endereço")]
        [StringLength(300, ErrorMessage = " O nome deve possuir no máximo 200 caracteres")]
        [Display(Name = " Endereço")]
        public string Endereco { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "CEP é obrigatório[ formato: 00000-000]")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido")]
        [Display(Name = "CEP [ formato: 00000-000]")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "Telefone é obrigatorio [ formato: (00) 00000-0000 ]")]
        [RegularExpression(@"^\(\d{2}\)\d{5}-\d{4}$", ErrorMessage = " Telefone inválido")]
        [Display(Name = " Celular [ formato (00) 00000-0000 ]")]
        public string Celular { get; set; }

        [RegularExpression(@"^\(\d{2}\)\d{4}-\d{4}$", ErrorMessage = " Telefone inválido")]
        [Display(Name = " Telefone Fixo [ formato (00) 0000-0000 ]")]
        public string TelefoneFixo { get; set; }

        public virtual ICollection<Turma> Turmas { get; set; }

    }
}