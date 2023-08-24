using CodeStudy_3._1.Model;

namespace CodeStudy_3._1.DataRepositories
{
    public interface IStudentRepository
    {
        Student GetStudent(int id);
    }
}
