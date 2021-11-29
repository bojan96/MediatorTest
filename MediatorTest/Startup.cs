using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatorTest.Mediator.Behavior;
using MediatorTest.Mediator.Handler;
using MediatorTest.Mediator.Request;
using MediatorTest.Mediator.Response;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MediatorTest
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
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(BodyBehavior));
            services.AddHttpClient("Post", config =>
            {
                config.BaseAddress = new Uri($"{Configuration.GetValue<string>("PlaceholderApiUrl")}/posts/");
            });
            services.AddHttpClient("Comment", config =>
            {
                config.BaseAddress = new Uri($"{Configuration.GetValue<string>("PlaceholderApiUrl")}/comments/");
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
