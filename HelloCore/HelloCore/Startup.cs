using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HelloCore
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IConfiguration configuration, IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            applicationLifetime.ApplicationStarted.Register(() => 
            {
                Console.WriteLine("Started");
            });

            applicationLifetime.ApplicationStopped.Register(() =>
            {
                Console.WriteLine("Stopped");
            });

            applicationLifetime.ApplicationStopping.Register(() =>
            {
                Console.WriteLine("Stopping");
            });



            app.Run(async (context) =>
            {

                await context.Response.WriteAsync(env.ApplicationName);
                await context.Response.WriteAsync(env.ContentRootPath);
                await context.Response.WriteAsync(env.EnvironmentName);

                await context.Response.WriteAsync(configuration["name"]);
                //await context.Response.WriteAsync("Hello World!");
            });
        }
    }
}
