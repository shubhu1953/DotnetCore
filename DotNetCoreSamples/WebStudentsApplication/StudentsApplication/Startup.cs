using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StudentRepository;
using StudentService;

namespace StudentsApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Data source=SHUBHANKAR\\SQLEXPRESS;Initial Catalog=StudentsDatabase;Integrated Security=SSPI;MultipleActiveResultSets=true";
            services.AddDbContext<StudentDbContext>(options => options.UseSqlServer("Data source=SHUBHANKAR\\SQLEXPRESS;Initial Catalog=StudentsDBB;Integrated Security=SSPI;MultipleActiveResultSets=true"));
            services.AddScoped<IUnitOfWork, UnitOfWork>();            
            services.AddScoped<IStudentService, StudentServices>();
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Students}/{id?}");
            });
        }
    }
}
