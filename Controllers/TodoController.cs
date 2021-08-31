using Microsoft.AspNetCore.Mvc;

namespace TodoList.Controllers
{
    public class TodoController : Controller
    {
        public ActionResult Index()
        {
            // retornará o HTML definido no arquivo Index da pasta Views/Todo
            return View();
        }

        // http://localhost/todo/hello
        public ActionResult Hello()
        {
            return View();
        }
    }
}


// -> View ('Hello World')


// http://localhost/todo/index = new TodoController().Index()

// http://localhost/todo/index -> /Views/Todo/Index.cshtml