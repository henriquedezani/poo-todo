using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using TodoList.Models;

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
            tarefas.Add(tarefa);
            return RedirectToAction("Index"); // HTTP 300
        }
    }
}

