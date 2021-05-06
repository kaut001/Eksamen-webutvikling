using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

using Microsoft.EntityFrameworkCore;
using FindAMusicianApi.Models;

namespace FindAMusicianApi
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

            // CORS konfigurering
            services.AddCors(
                options => {
                    options.AddPolicy("AllowAll", 
                        builder => builder
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowAnyOrigin()
                    );
                }
            );

            services.AddDbContext<FindAMusicianContext>( // Redegjør for at det er FindAMusician databasen som skal jobbes mot
                options => options.UseSqlite("Data Source = FindAMusicianDb.db")
            );

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "FindAMusicianApi", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "FindAMusicianApi v1"));
            }

            app.UseCors("AllowAll"); // Gjør APIet tilgjengelig for vue-prosjektet

            app.UseDefaultFiles(); // Gjør at index.html i wwwroot er startside

            app.UseStaticFiles(); // Tilgjengeligjør wwwroot

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
