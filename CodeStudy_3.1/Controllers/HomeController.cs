using CodeStudy_3._1.DataRepositories;
using Microsoft.AspNetCore.Mvc;
using CodeStudy_3._1.Model;
using CodeStudy_3._1.ViewModel;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using System;

namespace CodeStudy_3._1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        private readonly IWebHostEnvironment webHostEnvironment;

        //使用构造函数注入的方法注入IStudentRepository
        public HomeController(IStudentRepository studentRepository,IWebHostEnvironment webHostEnvironment) {
            _studentRepository = studentRepository;
            //也可以直接更改控制器(下行代码)，但是不建议，因为每更改一次，就需要修改所有代码，维护比较困难，还是建议使用Startup.cs里使用依赖注入比较好
            //_studentRepository = new MockStudentRepository();
            this.webHostEnvironment = webHostEnvironment;
        }
        //[Route（"自定义内容"）]即为属性路由
        //[Route("")]
        //[Route("Home")]
        //[Route("Home/Index")]

        /*属性路由使用Route来定义；属性路由可以应用于控制器或者控制器中的操作方法上；使用属性路由时需要设置在实际使用的操作方法上方
          属性路由比传统路由更灵活；支持层级目录；如果操作上方的路由模板以'/'，'~/'开头，则控制器的路由模板不会与操作方法的路由模板组合在一起
          重命名控制器或者操作方法的名称不需要修改路由模板规则；通常情况下，传统路由服务于HTML页面的控制器，属性路由服务于RESTful API的控制器*/
        public IActionResult Index() {
            //查询所有学生信息
            var model = _studentRepository.GetAllStudent();
            //将学生列表传递到视图
            return View(model);
        }

        [HttpGet]
        public IActionResult Edit(int id) {
            Student student = _studentRepository.GetStudent(id);
            StudentEditViewModel studentEditViewModel = new StudentEditViewModel()
            {
                Id = student.Id,
                Name = student.Name,
                Calssroom = student.Calssroom,
                Major = student.Major,
                Email = student.Email,
                ExistringPhotoPath = student.PhotoPath
            };
            return View(studentEditViewModel);
        }

        //[HttpPost]
        public IActionResult Delte(int id) {
            Student student = _studentRepository.GetStudent(id);
            if (student != null)
            {
                 _studentRepository.Delete(id);
                //删除后刷新页面，可以使用return RedirectToAction("ActionName")方法来实现
                return RedirectToAction("Index");
            }
            else {
                ViewBag.ErrorMessage = $"未找到Id为{id}的学生";
                return View("Index");
            }
        }


        [HttpGet]
        public IActionResult Create() {
            return View();
        }
        [HttpPost]
        public IActionResult Create(StudentCreteViewModel model)
        {
            if (ModelState.IsValid) {
                string uniqueFileName = null;

                /*单文件上传*/
                if (model.PhotoPath != null) {
                    //必须将图片文件上传到wwwroot的images文件夹中，要获取wwwroot文件夹的路径，需要使用ASP.NET Core提供的webHostEnvironment服务
                    string uploadsFoldex = Path.Combine(webHostEnvironment.WebRootPath, "images");
                    //使用Guid可以确保文件名是唯一的
                    uniqueFileName = Guid.NewGuid().ToString() + "_" + model.PhotoPath.FileName;
                    string filePath = Path.Combine(uploadsFoldex, uniqueFileName);
                    model.PhotoPath.CopyTo(new FileStream(filePath, FileMode.Create));
                        }

                /*多文件上传*/
               /* if (model.PhotoPath != null && model.PhotoPath.Count > 0) {
                    //循环每个选定的文件
                    foreach (var photo in model.PhotoPath) {
                        string uploadsFoldex = Path.Combine(webHostEnvironment.WebRootPath, "images");
                        uniqueFileName = Guid.NewGuid().ToString() + "_" + photo.FileName;
                        string filePath = Path.Combine(uploadsFoldex, uniqueFileName);
                        photo.CopyTo(new FileStream(filePath, FileMode.Create));
                    }
                }*/

                Student newstudent = new Student
                {
                    Name = model.Name,
                    Calssroom = model.Calssroom,
                    Major = model.Major,
                    Email = model.Email,
                    //将文件名保存在Student对象的PhotoPath属性中，被保存在数据库Student表中
                    PhotoPath = uniqueFileName
                };
                _studentRepository.Add(newstudent);
                return RedirectToAction("Detailsview", new { id = newstudent.Id });
            }
            return View();
        }
            /*public IActionResult Create(Student student) {
                /*在属性里添加Required后会判断值，如果为空或者不存在，就会验证失败，ModelState.IsValid属性会检查验证是否成功*/
            /*if (ModelState.IsValid) {
                Student newstudent = _studentRepository.Add(student);
                return RedirectToAction("Detailsview", new { id = newstudent.Id });
            }
            return View();
        }*/

            //[Route("Home/Detailsview/{id?}")]
            public ViewResult Detailsview(int id)
        {
            //使用ViewModel将数据传递给视图
            //实例化HomeDetailsViewModel并存储Student详细信息和PageTiles
            HomeDetailsViewModel homeDetailsViewModel = new HomeDetailsViewModel()
            {
                student = _studentRepository.GetStudent(id),
                //student = _studentRepository.GetStudent(id??1),
                PageTiles = "学生详细信息"
            };
            //将ViewModel对象传递给View()方法
            return View(homeDetailsViewModel);
            //在某些情况下，Model对象可能无法包含View所需要的全部数据，这个时候就可以使用ViewModel
            //ViewModel会包含View所需要的所有数据;ViewModel类可以存在于ASP.NET Core MVC项目中的任何位置，但是为了方便管理，存于ViewModel文件夹里

            //强类型视图传值 提供编译时类型检查和智能提示，可以提高工作效率，减少拼写错误；强类型视图可以在编译时看到错误，而不用运行时看到；建议使用强类型视图将数据从控制器传到视图
            //Student model = _studentRepository.GetStudent(1);
            //ViewBag.PageTitle = "学生详情";
            //return View(model);

            //ViewBag视图传值
            //ViewBag.PageTitle = "学生详情";
            //ViewBag.Student = model;
            //return View();

            //使用ViewData将PageTile和Student模型传值给View
            //ViewData["PageTile"] = "Student Details";
            //ViewData["Student"] = model;
            //return View(model);

            /*ViewData与ViewBag对比
            ViewData与ViewBag两者都可以从控制器传递数据到视图，都是创建弱类型的视图
            ViewBag是ViewData的包装器
            ViewData使用字符串键来存储和查询ViewData字典中的数据；ViewBag使用动态属性来存储和查询数据
            ViewData与ViewBag都是在运行时动态解析，不提供编译时类型检查*/

            /*ViewData是弱类型的字典（dictionary）对象，使用String类型的键值对存储和查询ViewData字典中的数据，可以从ViewData字典直接访问数据，无需将数据转为string类型
            如果访问是任何其他类型的数据，则需要显式转换为需要的类型
            ViewData在运行时会进行动态解析，不提供编译时类型检查，这会导致编写代码的速度降低，拼写错误和打错的可能性也会增大。这些错误只会在项目运行时提示出来，所以我们通常不使用ViewData
            当使用VieewData时，我们最终会创建一个弱类型的视图*/
        }

        //返回json数据
        public JsonResult Detailsjson()
        {
            Student model = _studentRepository.GetStudent(1);
            return Json(model);
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
        //返回字符串类型
        //public string Details()
        //{
        //    return "Hellow ASP.NET Core MVC";
        //}
    }
}
