using CodeStudy_3._1.Model;
using CodeStudy_3._1.Model.EnumTypes;
using System.Collections.Generic;
using System.Linq;

namespace CodeStudy_3._1.DataRepositories
{
    public class MockStudentRepository : IStudentRepository
    {
        //仓储模式下的内存实现
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

         public Student Delete(int Id)
         {
             Student student = _studentList.FirstOrDefault(x => x.Id == Id);
             if (student != null) {
                 _studentList.Remove(student);
             }
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

         public Student Update(Student updatestudent)
         {
             Student student = _studentList.FirstOrDefault(x => x.Id == updatestudent.Id);
             if (student!=null)
             {
                 student.Name = updatestudent.Name;
                 student.Calssroom = updatestudent.Calssroom;
                 student.Major = updatestudent.Major;
                 student.Email = updatestudent.Email;
             }
             return student;
         }
    }
}
