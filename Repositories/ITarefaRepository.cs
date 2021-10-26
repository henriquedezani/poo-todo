using System;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Repositories
{
    // "Contrato" ("Abstrato")
    public interface ITarefaRepository
    {
        void Create(Tarefa model);
        List<Tarefa> ReadAll(int id);
        Tarefa Read(int id);
        void Update(int id, Tarefa model);
        void Delete(int id);
    }
}