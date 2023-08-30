using CodeStudy_3._1.Model;
using System.Collections.Generic;

namespace CodeStudy_3._1.DataRepositories
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);
        IEnumerable<Student> GetAllStudent();
        Student Add(Student student);
    }
}
