using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Controllers
{    
    public class TodoController : Controller
    {
        // /Todo/Index
        public ActionResult Index()
        {
            List<Tarefa> tarefas = new List<Tarefa>();
            
            Tarefa tarefa1 = new Tarefa() { Id = 1, Texto = "Estudar prova", Concluida = false};
            Tarefa tarefa2 = new Tarefa() { Id = 2, Texto = "Tomar vacina", Concluida = false};
            Tarefa tarefa3 = new Tarefa() { Id = 3, Texto = "Tomar banho", Concluida = false};

            tarefas.Add(tarefa1);
            tarefas.Add(tarefa2);
            tarefas.Add(tarefa3);

            return View(tarefas);
        }
    }
}