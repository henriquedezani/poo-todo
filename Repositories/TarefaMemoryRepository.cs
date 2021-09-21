using System;
using System.Collections.Generic;
using System.Linq;
using TodoList.Models;

namespace TodoList.Repositories
{
    // implementação do contrato ("Concreto")
    public class TarefaMemoryRepository : ITarefaRepository
    {
        private static List<Tarefa> tarefas = new List<Tarefa>();

        public void Create(Tarefa model)
        {
            model.Id = Guid.NewGuid(); // uuid4 (no npm)
            tarefas.Add(model);
        }        

        public List<Tarefa> Read()
        {
            return tarefas;
        }

        public Tarefa Read(Guid id)
        {
            return tarefas.Single(tarefa => tarefa.Id == id);
        }

        public void Update(Guid id, Tarefa model)
        {
            var tarefa = tarefas.Single(x => x.Id == id);
            tarefa.Texto = model.Texto;
            tarefa.Concluida = model.Concluida;
        }

        public void Delete(Guid id)
        {
            var tarefa = tarefas.Single(tarefa => tarefa.Id == id);
            tarefas.Remove(tarefa);
        }
    }
}