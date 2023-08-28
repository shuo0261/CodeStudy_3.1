using CodeStudy_3._1.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodeStudy_3._1.DataRepositories
{
    public class MockStudentRepository : IStudentRepository
    {
        private List<Student> _studentList;

        public MockStudentRepository() {
            _studentList = new List<Student>()
            {
                new Student() { Id=1,Name="张三",Calssroom="一年级",Major="计算机软件",Email="123@qq.com"},
                new Student() { Id=2,Name="张三2",Calssroom="二年级",Major="计算机软件2",Email="1234@qq.com"},
                new Student() { Id=3,Name="张三3",Calssroom="三年级",Major="计算机软件3",Email="12345@qq.com"},
            };
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _studentList;
        }

        public Student GetStudent(int id)
        {
            return _studentList.FirstOrDefault(a => a.Id == id);
        }
    }
}
