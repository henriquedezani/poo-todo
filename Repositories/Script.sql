-- Data Source = localhost
-- Integrated Security = True
-- Initial Catalog = BDTodo

create database BDTodo
go

use BDTodo
GO

-- CRIAÇÃO DAS TABELAS:
CREATE TABLE Tarefa
(
    Id          int             primary key     identity,
    Texto       varchar(200)    not null,
    Concluida   bit             not null        default 0
)

CREATE TABLE Usuario
(
    Id          int             primary KEY     identity,
    Nome        varchar(100)    not null,
    Email       varchar(100)    not null        unique,
    Senha       varchar(100)    not null
    
)

ALTER TABLE Tarefa ADD IdUsuario int references Usuario (Id) -- ON DELETE SET NULL

-- INSERÇÃO DOS DADOS INICIAIS:
INSERT INTO Tarefa VALUES ('Estudar para a prova', 0, 1)
INSERT INTO Tarefa VALUES ('Passear com o cachorro', 1, 2)

INSERT INTO Usuario VALUES ('Diego Aparecido Armindo', 'diego@fatec.br', '123456')
INSERT INTO Usuario VALUES ('Thamiris Sayuri Higashiharaguti', 'thamiris@fatec.br', '123456')
INSERT INTO Usuario VALUES ('Andre Luis da Silva', 'andre@fatec.br', '123456')

-- CONSULTAS DIVERSAS:
SELECT * FROM Tarefa

SELECT * FROM Usuario

CREATE VIEW ViewTarefa AS
    SELECT Tarefa.Id, Tarefa.Texto, Tarefa.Concluida, Usuario.Nome as Usuario
        FROM Tarefa, Usuario
        WHERE Tarefa.IdUsuario = Usuario.Id

SELECT * FROM ViewTarefa

CREATE PROCEDURE CREATE_TAREFA (
    @texto varchar(200),
    @idusuario int
) AS BEGIN
    INSERT INTO Tarefa VALUES (@texto, 0, @idusuario)
END

