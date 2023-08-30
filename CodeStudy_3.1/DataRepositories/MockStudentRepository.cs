using CodeStudy_3._1.Model;
using CodeStudy_3._1.Model.EnumTypes;
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
                new Student() { Id=1,Name="张三",Calssroom=ClassroomEnum.FreshmanYear,Major=MajorEnum.ComputerScience,Email="123@qq.com"},
                new Student() { Id=2,Name="张三2",Calssroom=ClassroomEnum.SecondGrade,Major=MajorEnum.Mathematics,Email="1234@qq.com"},
                new Student() { Id=3,Name="张三3",Calssroom=ClassroomEnum.JuniorClass,Major=MajorEnum.ElectronicCommerce,Email="12345@qq.com"},
            };
        }

        public Student Add(Student student) {
            student.Id = _studentList.Max(x => x.Id) + 1;
            _studentList.Add(student);
            return student;
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
