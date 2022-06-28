using Asp_core_practice.model;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;

namespace Asp_core_practice
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
          
            services.AddMvc().AddXmlSerializerFormatters();
            services.AddRazorPages();
            services.AddControllers(options => options.EnableEndpointRouting = false);
            services.AddSingleton<IEmployeeRepository, MockEmployeeRepository>();
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env /*ILogger<Startup> logger*/)
        {
            if (env.IsDevelopment())
            {
                /*DeveloperExceptionPageOptions developerExceptionPageOptions = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount = 10
                };
                app.UseDeveloperExceptionPage(developerExceptionPageOptions);*/

               app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            /*    app.Use(async (context, next) =>
                {
                    logger.LogInformation("MW1: Incoming Request");
                    await next();
                    logger.LogInformation("MW1: Outgoing Response");
                });

                app.Use(async (context, next) =>
                {
                    logger.LogInformation("MW2: Incoming Request");
                    await next();
                    logger.LogInformation("MW2: Outgoing Response");
                });*/


            // Specify foo.html as the default document
            /*  FileServerOptions fileServerOptions = new FileServerOptions();
              fileServerOptions.DefaultFilesOptions.DefaultFileNames.Clear();
              fileServerOptions.DefaultFilesOptions.DefaultFileNames.Add("foo.html");
              app.UseFileServer(fileServerOptions);*/
            // Add Static Files Middleware
        //    app.UseFileServer();
           
            app.UseStaticFiles();
              app.UseRouting();
            // app.UseMvcWithDefaultRoute();
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseAuthorization();
            app.UseMvc();

            //    app.Run(async (context) =>
            //    {
            // throw new Exception("Some error processing the request");
            //       await context.Response.WriteAsync("hello world");
            // logger.LogInformation("MW3: Request handled and response produced");
            //  });


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
