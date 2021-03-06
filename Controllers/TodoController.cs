using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TodoList.Models;
using System.Linq;
using TodoList.Repositories;

namespace TodoList.Controllers
{    
    public class TodoController : Controller
    {
        private ITarefaRepository repository;

        public TodoController(ITarefaRepository repository) 
        {
            this.repository = repository;
        }
        
        // http://localhost/Todo/Index = return new TodoController().Index()
        public ActionResult Index()
        {
            var id = HttpContext.Session.GetInt32("id");
            
            if(id == null)
                return RedirectToAction("Login", "Usuario");

            List<Tarefa> tarefas = repository.ReadAll((int)id);
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
        public ActionResult Create(Tarefa model)
        {
            repository.Create(model);
            return RedirectToAction("Index"); // HTTP 300
        }

        // https://localhost:5001/todo/delete/0942b2f0-e059-41ef-ac6e-4bea56173139
        [HttpGet]
        public ActionResult Delete(int id)
        {
            repository.Delete(id);
            return RedirectToAction("Index"); // HTTP 300 para o navegador.
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            var tarefa = repository.Read(id);
            return View(tarefa);
        }

        [HttpPost]
        public ActionResult Update(int id, Tarefa model)
        {            
            repository.Update(id, model);
            return RedirectToAction("Index");
        }
    }
}

