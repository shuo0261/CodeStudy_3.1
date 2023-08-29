using Microsoft.AspNetCore.Mvc;

namespace CodeStudy_3._1.Controllers
{
    public class DepartmentsController : Controller
    {
        public string List()
        {
            return "我是Departments控制器的List()方法";
        }
        public string Details() {
            return "我是Departments控制器的Details()方法";
        }
    }
}
