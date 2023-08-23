using Microsoft.AspNetCore.Mvc;

namespace CodeStudy_3._1.Controllers
{

    public class HomeController 
    {
        public string Index() 
        {
            return "Hellow from MVC";
        }
    }
    //public class HomeController : Controller
    //{
    //    public IActionResult Index()
    //    {
    //        return View();
    //    }
    //}
}
