namespace TodoList.Models
{
    public class Tarefa
    {
        // propriedades:
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool Concluida { get; set; }
    }
}


/*
--Exemplo de código no SQL:
CREATE TABLE Tarefa
(
    Id          int             primary key     identity,
    Texto       varchar(200)    not null,
    Concluida   bit             not null        default 0
)
*/