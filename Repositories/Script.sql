-- Data Source = localhost
-- Integrated Security = True
-- Initial Catalog = BDTodo

create database BDTodo
go

use BDTodo
GO

CREATE TABLE Tarefa
(
    Id          int             primary key     identity,
    Texto       varchar(200)    not null,
    Concluida   bit             not null        default 0
)