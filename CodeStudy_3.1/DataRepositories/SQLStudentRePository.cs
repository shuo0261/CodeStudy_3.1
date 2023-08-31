using CodeStudy_3._1.Infrastructure;
using CodeStudy_3._1.Model;
using System.Collections.Generic;

namespace CodeStudy_3._1.DataRepositories
{
    public class SQLStudentRePository : IStudentRepository
    {
        private readonly AppDbContext _context;
        public SQLStudentRePository(AppDbContext context) {
            _context = context;
        }
        public Student Add(Student student)
        {
            _context.Students.Add(student);
            _context.SaveChanges();
            return student;
        }

        public Student Delete(int Id)
        {
            Student student = _context.Students.Find(Id);
            if (student != null) {
                _context.Students.Remove(student);
                _context.SaveChanges();
            }
            return student;
           
        }

        public IEnumerable<Student> GetAllStudent()
        {
            return _context.Students;
        }

        public Student GetStudent(int id)
        {
            return _context.Students.Find(id);
        }

        public Student Update(Student updatestudent)
        {
            var student = _context.Students.Attach(updatestudent);
            student.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _context.SaveChanges();
            return updatestudent;
        }
    }
}
