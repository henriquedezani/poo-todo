using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TodoList.Models;
using System.Linq;

namespace TodoList.Controllers
{    
    public class TodoController : Controller
    {
        private static List<Tarefa> tarefas = new List<Tarefa>();

        // http://localhost/Todo/Index = return new TodoController().Index()
        public ActionResult Index()
        {
            return View(tarefas);
        }

        // http://localhost:5000/todo/create
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        // http://localhost:5000/todo/create
        [HttpPost] // <form method="POST" ...
        public ActionResult Create(Tarefa tarefa)
        {
            tarefa.Id = Guid.NewGuid(); // uuid4 (no npm)
            tarefas.Add(tarefa);
            return RedirectToAction("Index"); // HTTP 300
        }

        // https://localhost:5001/todo/delete/0942b2f0-e059-41ef-ac6e-4bea56173139
        [HttpGet]
        public ActionResult Delete(Guid id)
        {
            // DELETE FROM Tabelas WHERE id = id...

            // 1. Programação Imperativa
            // foreach(var tarefa in tarefas) {
            //     if(tarefa.Id == id) {
            //         tarefas.Remove(tarefa);
            //         break;
            //     }
            // }
            
            // 2. Programação Funcional
            //var tarefa = tarefas.Where(tarefa => tarefa.Id == id).Single();

            // 3. LinQ SQL
            // SELECT  * FROM Tarefas t WHERE Id = id;
            // var tarefa = (from t in tarefas 
            //                 where t.Id == id
            //                 select t).Single();

            var tarefa = tarefas.Single(tarefa => tarefa.Id == id);
            tarefas.Remove(tarefa);


            // SELECT Texto as tarefa FROM Tarefas;
            // var x = from t in tarefas 
            //                 where t.Id == id
            //                 select new {Tarefa = t.Texto};


            return RedirectToAction("Index"); // HTTP 300 para o navegador.
        }
    }
}

