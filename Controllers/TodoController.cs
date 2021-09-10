using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using TodoList.Models;

namespace TodoList.Controllers
{    
    public class TodoController : Controller
    {
        // http://localhost/Todo/Index = return new TodoController().Index()
        public ActionResult Index()
        {
            List<Tarefa> tarefas = new List<Tarefa>();

            Tarefa t1 = new Tarefa();
            t1.Id = 1;
            t1.Texto = "Passear com o cachorro";
            t1.Concluida = false;

            Tarefa t2 = new Tarefa();
            t2.Id = 2;
            t2.Texto = "Lavar o carro";
            t2.Concluida = true;

            Tarefa t3 = new Tarefa();
            t3.Id = 3;
            t3.Texto = "Estudar para prova";
            t3.Concluida = true;

            tarefas.Add(t1);
            tarefas.Add(t2);
            tarefas.Add(t3);

            return View(tarefas);
            // return View();
            // return View("Index");
            // return View("Index", tarefas);
        }
    }
}

