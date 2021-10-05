using Microsoft.AspNetCore.Mvc;
using TodoList.Models;
using TodoList.Repositories;

namespace TodoList.Controllers
{
    // localhost:5000/usuario/
    public class UsuarioController: Controller
    {
        private IUsuarioRepository repository;

        // // injeção de dependência.
        // public UsuarioController(IUsuarioRepository repository)
        // {
        //     this.repository = repository;
        // }

        // localhost:5000/usuario/login
        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UsuarioLoginViewModel model)
        {
            if(!ModelState.IsValid)
                return View(model);

            Usuario usuario = repository.Read(model.Email, model.Senha);

            if(usuario == null)
            {
                ViewBag.Message = "Usuário não encontrado.";
                return View(model);
            }

            // Cria-se uma sessão para o usuário e,

            return RedirectToAction("Index", "Todo");
        }
    }
}