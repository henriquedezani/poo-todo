namespace TodoList.Models
{
    public class Usuario
    {
        public int? Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}

// CREATE TABLE Usuario
// (
//     Id          int             primary KEY     identity,
//     Nome        varchar(100)    not null,
//     Email       varchar(100)    not null        unique,
//     Senha       varchar(100)    not null
// )