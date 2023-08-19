using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeStudy_3._1
{
    public class Program
    {
        //ASP.NET Core��Ŀ����� Main
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        // CreateHostBuilder()������Ϊ���ڷ������ϴ����������õ�Ĭ��ֵ������
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
