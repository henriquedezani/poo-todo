namespace TodoList.Models
{
    // POCO = Plain Old Object C#

    public class Tarefa
    {
        // propriedades:
        public int Id { get; set; }
        public string Texto { get; set; }
        public bool Concluida { get; set; }
        public int IdUsuario { get; set; }
        public string TextoConcluida => Concluida ? "Concluída" : "Não Concluída";

        #region Foreign Key
        public Usuario Usuario { get; set; }
        #endregion
    }
}

// Tarefa objeto = new Tarefa();
// objeto.Id = 1;
// objeto.Texto = "Passear com  cachorro";
// objeto.Concluida = false;

/*
--Exemplo de código no SQL:
CREATE TABLE Tarefa
(
    Id          int             primary key     identity,
    Texto       varchar(200)    not null,
    Concluida   bit             not null        default 0
)
*/

/*
Id      Texto        Concluida
1       Passear      0
2       Lavar carro  1
*/