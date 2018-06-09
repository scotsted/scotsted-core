using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ScotstedWebApplication
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
            services.AddMvc(options =>
            {
                options.MaxModelValidationErrors = 100;
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            app.UseStatusCodePages();

            app.UseWelcomePage("/");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseStaticFiles();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "api",
                    template: "api/{controller}/{action=index}/{id?}");
                routes.MapRoute(
                    name: "currency_by_code",
                    template: "currency/{code:length(3)}",
                    defaults: new { controller = "Currencies", action = "View2" });
                routes.MapRoute(
                    name: "currencies",
                    template: "{currency}/{action}",
                    defaults: new
                    {
                        controller = "currencies",
                        currency = "GBP",
                        action = "View2"
                    },
                    constraints: new
                    {
                        currency = new LengthRouteConstraint(3)
                    }
                );
                routes.MapRoute(
                    name: "convert_currencies",
                    template: "{currency}/convert/{*others}",
                    defaults: new { controller = "currencies", action = "View2" }
                );
                routes.MapRoute(
                    name: "start_checkout",
                    template: "checkout",
                    defaults: new { controller = "Payment", action = "StartProcess" }
                );
                routes.MapRoute(
                    name: "currency_default",
                    template: "{controller}/{currency}/{action}",
                    defaults: new { currency = "GBP", action = "View2" },
                    constraints: new { currency = new LengthRouteConstraint(3) });
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}"
                );
            });
        }
    }
}
