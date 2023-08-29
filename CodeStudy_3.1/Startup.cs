using CodeStudy_3._1.DataRepositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeStudy_3._1
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940

        //private IConfiguration _configuration;
        //public Startup(IConfiguration configuration) 
        //{
        //    _configuration = configuration;
        //}

        //ConfigureServices()方法配置应用程序所需要的服务
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(a=>a.EnableEndpointRouting=false);

            //.NET  Core 3.0以后推荐到写法 注入MVC（如果只使用MVC）
            services.AddControllersWithViews(a => a.EnableEndpointRouting = false);
            //app.UseMvc()不支持Routing Endpoints,要继续使用UseMVC中间件需要将EnableEndpointRouting设置为False
            //services.AddControllersWithViews().AddXmlSerializerFormatters();

            //使用依赖注入来注册服务，在这里注入IStudentRepository与MockStudentRepository，也可以在控制器里更改
            services.AddSingleton<IStudentRepository, MockStudentRepository>();
            //从数据库获取数据
            //services.AddSingleton<IStudentRepository, DatabaseStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //Configure()方法配置应用程序的请求处理管道     ILogger<Startup>被注入到Configure()方法，用于日志记录
        //项目启动时，Main()方法调用CreateDefaultBuilder()配置日志记录
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc();

            app.UseMvcWithDefaultRoute();

            //UseEndpoints(官方命名为终结点路由，dotnet开发团队推荐使用)可以处理跨不同中间件系统(如MVC、RazorPages、Blazor、SignalR和gRPC)的路由系统
            //通过终结点路由可以使端点相互协作，并使系统比没有相互对话的终端中间件更全面
            //app.UseStaticFiles();
            //app.UseRouting();
            //app.UseEndpoints(endpoint => {
            //    endpoint.MapControllerRoute(
            //       name: "default",
            //       pattern: "{controller=Home}/{action=Index}/{id?}"
            //        );
            //    });


            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});


            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            ////使用纯静态文件支持的中间件，不使用终端中间件
            //app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hosting Environment："+env.EnvironmentName);
            //});

            //if (env.IsDevelopment())
            //{
            //    //DeveloperExceptionPageOptions()中间件要尽量放在其他中间件前面，否侧不会显示异常
            //    //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
            //    //{
            //    //    //SourceCodeLineCount:确定显示引发异常代码的上方代码和下方代码行数
            //    //    SourceCodeLineCount = 3
            //    //};
            //    //app.UseDeveloperExceptionPage(developerExceptionPageOptions);

            //    //UseDeveloperExceptionPage：如果存在异常并且环境是Development，此中间件会调用，显示开发异常界面
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseFileServer();

            //app.Run(async (context) =>
            //{
            //    throw new Exception("读者的请求在管道中发生了一些异常，请检查。");
            //    await context.Response.WriteAsync("Hello World!");
            //});

            ////UseFileServer()结合了UseStaticFiles()、UseDefaultFiles()、UseDirectoryBrowser()中间件的功能
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("CodeStudy.html");
            //app.UseFileServer(fileServerOptions);

            ////添加一个静态网页为默认文件
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("CodeStudy.html");

            ////添加默认文件中间件
            //app.UseDefaultFiles(defaultFilesOptions);

            ////添加静态文件中间件
            //app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW1:传入请求");
            //    await next();
            //    logger.LogInformation("MW1:传出响应");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2:传入请求");
            //    await next();
            //    logger.LogInformation("MW2:传出响应");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("MW3:处理请求并生成响应");
            //    logger.LogInformation("MW3:处理请求并生成响应");
            //});

            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync("Hello World!");

            //    //防止乱码
            //    context.Response.ContentType = "text/plain;charset=utf-8";
            //    //注入后通过_configuration访问MyKey
            //    await context.Response.WriteAsync("从第一个中间件中打印Hello World!");
            //    //await context.Response.WriteAsync(_configuration["MyKey"]);
            //});

            //app.Use(async (context, next) =>
            //{
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("从第二个中间件中打印Hello World!");
            //});

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //         await context.Response.WriteAsync("Hello World!");

            //        //校验当前项目是进程内托管还是进程外托管 进程内托管返回iisexperss，进程外托管返回当前项目名称
            //        //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //        //await context.Response.WriteAsync(processName);
            //    });
            //});

        }
    }
}
