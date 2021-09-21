using System;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Repositories
{
    // "Contrato" ("Abstrato")
    public interface ITarefaRepository
    {
        void Create(Tarefa model);
        List<Tarefa> Read();
        Tarefa Read(Guid id);
        void Update(Guid id, Tarefa model);
        void Delete(Guid id);
    }
}