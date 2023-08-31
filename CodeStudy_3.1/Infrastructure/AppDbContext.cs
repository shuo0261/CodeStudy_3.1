using CodeStudy_3._1.Model;
using Microsoft.EntityFrameworkCore;

namespace CodeStudy_3._1.Infrastructure
{
    public class AppDbContext:DbContext
    {
        /*EF Core 代码先行，使用DbContext，为了使DbContext可以正常运行，需要一个DbContextOptions类的实例；
         DbContextOptions实例负责承载应用中的配置信息，如连接字符串、数据库提供等内容；要传递DbContextOptions实例，需要使用构造函数；
        使用DbContext中的第二个重载方法，这个重载方法指定我们使用的配置信息，需要继承base，将配置信息传递到父类DbContext中*/
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { 
        
        }
        /*DbContext类里包括一个DbSet<Tentity>模型，其中会包含一个实体属性；需要使用DbSet的属性来查询和保存类的实例*/
        public DbSet<Student> Students { get; set; }
    }
}
