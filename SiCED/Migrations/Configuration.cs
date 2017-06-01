namespace SiCED.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<SiCED.Models.ContextoEF>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(SiCED.Models.ContextoEF context)
        //{
        //    context.Cursos.AddOrUpdate(
        //          p => p.Nome,
        //          new Curso { Nome = "Ballet" },
        //              new Curso { Nome = "Street Dance" },
        //              new Curso { Nome = "Sapateado" },
        //              new Curso { Nome = "Jazz" },
        //              new Curso { Nome = "Barra-Chão" }
        //        );

        //    context.Disciplinas.AddOrUpdate(
        //          p => p.Nome,
        //          new Disciplina { Nome = "Baby" },
        //          new Disciplina { Nome = "Pré-Primary" },
        //          new Disciplina { Nome = "Primary" },
        //          new Disciplina { Nome = "1°Grau" },
        //          new Disciplina { Nome = "2°Grau" },
        //          new Disciplina { Nome = "3°Grau" },
        //          new Disciplina { Nome = "4°Grau" },
        //          new Disciplina { Nome = "5°Grau" },
        //          new Disciplina { Nome = "6°Grau" },
        //          new Disciplina { Nome = "Básico I" },
        //          new Disciplina { Nome = "Básico II" },
        //          new Disciplina { Nome = "Pré-Elementary(Infantil)" },
        //          new Disciplina { Nome = "Pré-Elementary(Adulto)" },
        //          new Disciplina { Nome = "Elementary" },
        //          new Disciplina { Nome = "Sênior" },
        //          new Disciplina { Nome = "Master" },
        //          new Disciplina { Nome = "Advanced I" },
        //          new Disciplina { Nome = "Inter/Avançado" },
        //          new Disciplina { Nome = "Sênior" },
        //          new Disciplina { Nome = "Iniciante" },
        //          new Disciplina { Nome = "Master e Advanced" },
        //          new Disciplina { Nome = "Mesclado" },
        //          new Disciplina { Nome = "Intermediário" },
        //          new Disciplina { Nome = "Lírico" },
        //          new Disciplina { Nome = "Avançado" },
        //          new Disciplina { Nome = "StreetNivel II" },
        //          new Disciplina { Nome = "StreetNivel III" }

        //        );

            //context.Professores.AddOrUpdate(
            //      p => p.Nome,
            //new Professor { Nome = "Fabiana Souza Gomes", CPF = "98765432109", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78000-000", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-1981" },
            //new Professor { Nome = "Fernanda Souza", CPF = "89765432109", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78068-435", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-1010" },
            //new Professor { Nome = "Aline Gomes", CPF = "76543210998", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78068-435", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-2020" },
            //new Professor { Nome = "Nati Queiroz", CPF = "65432109987", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78068-435", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-3030" },
            //new Professor { Nome = "Juliana Assis", CPF = "54321099876", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78068-435", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-4040" },
            //new Professor { Nome = "Daniela Soares", CPF = "43210998765", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78068-435", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-5050" },
            //new Professor { Nome = "Thais Soares", CPF = "99876543210", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78068-435", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-6060" },
            //new Professor { Nome = "Janaina Prates", CPF = "43876521099", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78068-435", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-7070" },
            //new Professor { Nome = "Nick Strut", CPF = "43298765109", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78068-435", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-8080", },
            //new Professor { Nome = "Joana Daniela Soares", CPF = "43992108765", DataNascimento = DateTime.Parse("08-11-1978"), Endereco = "Rua 190, qda 118 N 125", Bairro = "Centro", CEP = "78068-435", Celular = "(65)99981-1981", TelefoneFixo = "(65)3644-9090" }

            //);

            //context.Responsaveis.AddOrUpdate(s => s.Nome,

            //new Responsavel { Nome = "Patricia Souza Gomes", CPF = "98765432109", Endereco = "Rua 10, qda 18 N 25", CEP = "78068-435", Bairro = "Centro", Cidade = "Cuiabá", Celular = "(65)99981-1981", TelefoneFixo = "(65)3042-1981" }
            //new Responsavel { Nome = "Marcia Freitas", CPF = "73912030497", Endereco = "Rua 3, qda 10 N 3", CEP = "78068-435",Bairro = "Bosque da Saude",  Cidade = "Cuiabá", Celular = "(65)99243-1234", TelefoneFixo = "(65)3032-2081", },
            //new Responsavel { Nome = "Alexsandro Moreira", CPF = "69098000100", Endereco = "Rua 125, qda 31 N 15", CEP = "78068-435", Bairro = "Bosque da Saude", Cidade = "Cuiabá", Celular = "(65)98404-1401", TelefoneFixo = "(65)3022-1990" },
            //new Responsavel { Nome = "Lidianne Samara", CPF = "91566088100", Endereco = "Rua Caceres, qda 1 N 12", CEP = "78068-435", Bairro = "Bosque da Saude", Cidade = "Cuiabá", Celular = "(65)99052-1405", TelefoneFixo = "(65)3012-2221"},
            //new Responsavel { Nome = "Rosidelma Barros", CPF = "78787891919", Endereco = "Rua 40, qda 7 N 24", CEP = "78068-435", Bairro = "Bosque da Saude", Cidade = "Cuiabá", Celular = "(65)99941-0765", TelefoneFixo = "(65)3641-1981", CEP = "78068-435" },
            //new Responsavel { Nome = "Carol Delbianco", CPF = "56564387290", Endereco = "Av Joenville, qda 18 N 10", CEP = "78068-435", Bairro = "Bosque da Saude", Cidade = "Cuiabá", Celular = "(65)98744-1018", TelefoneFixo = "(65)3052-1981"},
            //new Responsavel { Nome = "Eunice Ramos", CPF = "78120903458", Endereco = "Rua 90, qda 90 N 89", CEP = "78068-435", Bairro = "Bosque da Saude", Cidade = "Cuiabá", Celular = "(65)99921-9090", TelefoneFixo = "(65)3062-8119"}

            //);

            //context.Alunos.AddOrUpdate(s => s.AlunoId,
            //new Aluno() { AlunoId = 5, ResponsavelId = 2, Nome = "Julia Patricia Gomes", CPF = "", Celular = "(65)98700-0909", DataNascimento = DateTime.Parse("09-10-1979") },
            ////new Aluno { Nome = "Nathalia Souza", CPF = "76587845621", Celular = "(65)98800-0808", DataNascimento = DateTime.Parse("06-11-1980") }
            //);
        }
    }

}