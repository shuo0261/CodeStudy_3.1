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
            return View(model);
        }
        public IActionResult Details()
        {
            return View();
        }
    }
}
