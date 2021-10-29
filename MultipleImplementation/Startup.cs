using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Collections.Generic;
using System.Linq;

namespace MultipleImplementation
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

            services.AddSingleton<IFoo, Foo1>();
            services.AddSingleton<IFoo, Foo2>();

            services.AddScoped<IBar, Bar1>();
            services.AddScoped<IBar, Bar2>();
            services.AddScoped<IReadOnlyDictionary<string, IBar>>(provider =>
            {
                var allBar = provider.GetService<IEnumerable<IBar>>();
                return allBar.ToDictionary(bar => bar.Name, bar => bar);
            });

            services.AddScoped<IBaz, Baz1>();
            services.AddScoped<IBaz, Baz2>();
            services.AddScoped<IBazBridge, BazBridge>();
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
