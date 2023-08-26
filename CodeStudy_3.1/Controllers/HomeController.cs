using CodeStudy_3._1.DataRepositories;
using Microsoft.AspNetCore.Mvc;
using CodeStudy_3._1.Model;


namespace CodeStudy_3._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        //使用构造函数注入的方法注入IStudentRepository
        public HomeController(IStudentRepository studentRepository) {
            _studentRepository = studentRepository;
            //也可以直接更改控制器(下行代码)，但是不建议，因为每更改一次，就需要修改所有代码，维护比较困难，还是建议使用Startup.cs里使用依赖注入比较好
            //_studentRepository = new MockStudentRepository();
        }
        public string Index()
        {
            return _studentRepository.GetStudent(1).Name;
        }

        //返回json数据
        public JsonResult Detailsjson() {
            Student model = _studentRepository.GetStudent(1);
            return Json(model);
        }
        public ViewResult Detailsview()
        {
            Student model = _studentRepository.GetStudent(1);
            ViewData["PageTile"] = "Student Details";
            ViewData["Student"] = model;
            return View(model);
        }
        //自定义视图
        public IActionResult Details()
        {
            //返回指定的视图文件
            return View("Detailsview");

            //返回指定路径的视图，使用绝对路径，要注意要加上.cshtml扩展名，推荐使用/就或者~/
            //return View("MyViews/Test.cshtml");

            //使用相对路径时，不用指定扩展名.cshtml，如果返回值在文件夹结构中超过了两个深度，要使用两次../
            //return View("../Test/Update");
        }
    }
}
