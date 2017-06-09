Create View NomeAlex2 as
select 
a.Nome,
t.Descricao
from
Aluno a
join Matricula m on a.AlunoId = m.AlunoId
join Turma t on m.TurmaId = t.Id;

select * from NomeAlex2