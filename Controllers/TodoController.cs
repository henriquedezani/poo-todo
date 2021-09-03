using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    
    public class TodoController : Controller
    {
        // https://localhost:5001/todo/index
        // https://localhost:5001/[NOME DO CONTROLLER (SEM O TEXTO "CONTROLLER")]/[NOME DO MÉTODO]
        public ActionResult Index()
        {
            // retornará o HTML definido no arquivo Index da pasta Views/Todo
            // return Views/Todo/Index.cshtml
            return View();
        }

        // https://localhost:5001/todo/hello
        public ActionResult Hello()
        {
            // Views/Todo/Oi.cshtml
            return View("Oi");
        }
    }
}


// -> View ('Hello World')


// http://localhost/todo/index = new TodoController().Index()

// http://localhost/todo/index -> /Views/Todo/Index.cshtml