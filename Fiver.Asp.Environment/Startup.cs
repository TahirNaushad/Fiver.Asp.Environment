using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Fiver.Asp.Environment
{
    public class Startup
    {
        public void ConfigureServices(
            IServiceCollection services)
        {
        }

        //public void Configure(
        //    IApplicationBuilder app, 
        //    IHostingEnvironment env)
        //{
        //    if (env.IsEnvironment("Development"))
        //        Run(app, "Development");
        //    else if (env.IsEnvironment("Staging"))
        //        Run(app, "Staging");
        //    else if (env.IsEnvironment("Production"))
        //        Run(app, "Production");
        //    else
        //        Run(app, env.EnvironmentName);
        //}

        public void Configure(
            IApplicationBuilder app,
            IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                Run(app, "Development");
            else if (env.IsStaging())
                Run(app, "Staging");
            else if (env.IsProduction())
                Run(app, "Production");
            else
                Run(app, env.EnvironmentName);
        }

        private void Run(IApplicationBuilder app, string environmentName)
        {
            app.Run(async context =>
            {
                await context.Response.WriteAsync($"Hello {environmentName}");
            });
        }
    }
}
