using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MovieCrud.Data;

namespace MovieCrud {
    public class Startup {
        public void ConfigureServices (IServiceCollection services) {

            services.AddDbContext<MovieDbContext>(options=> options.UseSqlite("DataSource=Movies.db"));
            
            services.AddMvc ();
            services.AddRouting ();
        }

        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            }

            app.UseStaticFiles ();

            app.UseMvc (routes => {
                routes.MapRoute ("default", "{controller=movie}/{action=index}/{id?}");
            });
        }
    }
}