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

        //ConfigureServices()��������Ӧ�ó�������Ҫ�ķ���
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddMvc(a=>a.EnableEndpointRouting=false);

            //.NET  Core 3.0�Ժ��Ƽ���д�� ע��MVC�����ֻʹ��MVC��
            services.AddControllersWithViews(a => a.EnableEndpointRouting = false);
            //app.UseMvc()��֧��Routing Endpoints,Ҫ����ʹ��UseMVC�м����Ҫ��EnableEndpointRouting����ΪFalse
            //services.AddControllersWithViews().AddXmlSerializerFormatters();

            //ʹ������ע����ע�����������ע��IStudentRepository��MockStudentRepository��Ҳ�����ڿ����������
            services.AddSingleton<IStudentRepository, MockStudentRepository>();
            //�����ݿ��ȡ����
            //services.AddSingleton<IStudentRepository, DatabaseStudentRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

        //Configure()��������Ӧ�ó����������ܵ�     ILogger<Startup>��ע�뵽Configure()������������־��¼
        //��Ŀ����ʱ��Main()��������CreateDefaultBuilder()������־��¼
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,ILogger<Startup> logger)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc();

            app.UseMvcWithDefaultRoute();

            //UseEndpoints(�ٷ�����Ϊ�ս��·�ɣ�dotnet�����Ŷ��Ƽ�ʹ��)���Դ���粻ͬ�м��ϵͳ(��MVC��RazorPages��Blazor��SignalR��gRPC)��·��ϵͳ
            //ͨ���ս��·�ɿ���ʹ�˵��໥Э������ʹϵͳ��û���໥�Ի����ն��м����ȫ��
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

            ////ʹ�ô���̬�ļ�֧�ֵ��м������ʹ���ն��м��
            //app.UseStaticFiles();
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hosting Environment��"+env.EnvironmentName);
            //});

            //if (env.IsDevelopment())
            //{
            //    //DeveloperExceptionPageOptions()�м��Ҫ�������������м��ǰ�棬��಻����ʾ�쳣
            //    //DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
            //    //{
            //    //    //SourceCodeLineCount:ȷ����ʾ�����쳣������Ϸ�������·���������
            //    //    SourceCodeLineCount = 3
            //    //};
            //    //app.UseDeveloperExceptionPage(developerExceptionPageOptions);

            //    //UseDeveloperExceptionPage����������쳣���һ�����Development�����м������ã���ʾ�����쳣����
            //    app.UseDeveloperExceptionPage();
            //}

            //app.UseFileServer();

            //app.Run(async (context) =>
            //{
            //    throw new Exception("���ߵ������ڹܵ��з�����һЩ�쳣�����顣");
            //    await context.Response.WriteAsync("Hello World!");
            //});

            ////UseFileServer()�����UseStaticFiles()��UseDefaultFiles()��UseDirectoryBrowser()�м���Ĺ���
            //FileServerOptions fileServerOptions = new FileServerOptions();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
            //fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("CodeStudy.html");
            //app.UseFileServer(fileServerOptions);

            ////���һ����̬��ҳΪĬ���ļ�
            //DefaultFilesOptions defaultFilesOptions = new DefaultFilesOptions();
            //defaultFilesOptions.DefaultFileNames.Clear();
            //defaultFilesOptions.DefaultFileNames.Add("CodeStudy.html");

            ////���Ĭ���ļ��м��
            //app.UseDefaultFiles(defaultFilesOptions);

            ////��Ӿ�̬�ļ��м��
            //app.UseStaticFiles();

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Hello World!");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW1:��������");
            //    await next();
            //    logger.LogInformation("MW1:������Ӧ");
            //});

            //app.Use(async (context, next) =>
            //{
            //    logger.LogInformation("MW2:��������");
            //    await next();
            //    logger.LogInformation("MW2:������Ӧ");
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("MW3:��������������Ӧ");
            //    logger.LogInformation("MW3:��������������Ӧ");
            //});

            //app.Run(async (context) =>
            //{
            //    //await context.Response.WriteAsync("Hello World!");

            //    //��ֹ����
            //    context.Response.ContentType = "text/plain;charset=utf-8";
            //    //ע���ͨ��_configuration����MyKey
            //    await context.Response.WriteAsync("�ӵ�һ���м���д�ӡHello World!");
            //    //await context.Response.WriteAsync(_configuration["MyKey"]);
            //});

            //app.Use(async (context, next) =>
            //{
            //    await next();
            //});

            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("�ӵڶ����м���д�ӡHello World!");
            //});

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //         await context.Response.WriteAsync("Hello World!");

            //        //У�鵱ǰ��Ŀ�ǽ������йܻ��ǽ������й� �������йܷ���iisexperss���������йܷ��ص�ǰ��Ŀ����
            //        //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //        //await context.Response.WriteAsync(processName);
            //    });
            //});

        }
    }
}
