using CodeStudy_3._1.Model.EnumTypes;
using CodeStudy_3._1.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeStudy_3._1.Infrastructure
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder) {
            modelBuilder.Entity<Student>().HasData(
                    new Student
                    {

                        Id = 1,
                        Name = "张三",
                        Calssroom = ClassroomEnum.FreshmanYear,
                        Major = MajorEnum.ComputerScience,
                        Email = "123@qq.com"
                    });
            modelBuilder.Entity<Student>().HasData(
                new Student
                {

                    Id = 2,
                    Name = "李四",
                    Calssroom = ClassroomEnum.SecondGrade,
                    Major = MajorEnum.Mathematics,
                    Email = "1234@qq.com"
                });
        }
    }
}
