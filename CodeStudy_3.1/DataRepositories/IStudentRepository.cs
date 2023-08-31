using CodeStudy_3._1.Model;
using System.Collections.Generic;

namespace CodeStudy_3._1.DataRepositories
{
    public interface IStudentRepository
    {
        /// <summary>
        /// 通过Id获取学生信息
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Student GetStudent(int id);

        /// <summary>
        /// 获取所有的学生信息
        /// </summary>
        /// <returns></returns>
        IEnumerable<Student> GetAllStudent();

        /// <summary>
        /// 添加学生信息
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        Student Add(Student student);

        /// <summary>
        /// 修改学生信息
        /// </summary>
        /// <param name="Updatestudent"></param>
        /// <returns></returns>
        Student Update(Student updatestudent);

        /// <summary>
        /// 删除学生信息
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Student Delete(int Id);
    }
}
