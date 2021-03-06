using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TodoList.Repositories;

namespace TodoList
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            // middlewares:
            // services.AddSingleton<ITarefaRepository, TarefaMemoryRepository>();
            services.AddTransient<ITarefaRepository, TarefaRepository>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();

            services.AddSession(options =>
                {
                    options.IdleTimeout = TimeSpan.FromSeconds(3600);
                    options.Cookie.HttpOnly = true;
                    options.Cookie.IsEssential = true;
                });

            // middleware para adicionar tratamento de requisições com controllers e views.
            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                // http://localhost:5001/{controller}/{action}
                // endpoints.MapDefaultControllerRoute();

                endpoints.MapControllerRoute("default", "{controller=Usuario}/{action=Login}/{id?}");
            });
        }
    }
}
