using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using XieChenProject.Api.Database;
using XieChenProject.Api.Services;
using Microsoft.EntityFrameworkCore;

namespace XieChenProject.Api
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();//ע��api controllers ���
            services.AddTransient<ITouristRouteRepository, MockTouristRouteReository>();  //ÿ������ ����ȫ�µ����ݲֿ�
            //services.AddSingleton  ֻ����һ�����ݴ���
            //services.AddScoped   

            services.AddDbContext<AppDbContext>(option=> {
                option.UseSqlServer("Server=1.15.81.57;Database=Test;User Id=sa;Password=!Q@W3e4r5t6y");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/test", async context =>
                //{
                //    await context.Response.WriteAsync("Hello form Test!");
                //});

                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapControllers();
            });

        }
    }
}
