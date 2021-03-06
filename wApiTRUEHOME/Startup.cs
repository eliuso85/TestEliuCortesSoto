using BussinesLogic;
using DataAccess;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace wApiTRUEHOME
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
            /// Se configura la cadena de coneccion PostgreSQL
            services.AddSingleton<IConfiguration>(Configuration);
            var ConnectionString = new PostgresSQLConfiguration(Configuration.GetConnectionString("PostgreSqlConnection"));
            services.AddSingleton(ConnectionString); /// se Utiliza AddSingleton - Se crea una sola intancia en toda la aplicacion y se reutiliza-

            services.AddResponseCaching();
            services.AddTransient<IActivity, DataActivity>();     /// Se usa AddTransient -se crean cada vez que se utilizan- por que es un servicio liviano .
            services.AddTransient<IActivityBussiness, ActivityData>();

            services.AddTransient<IProperty, DataProperty>();
            services.AddTransient<IPropertyBussiness, PropertyData>();



            services.AddSwaggerGen(c =>
                     {
                         c.SwaggerDoc("v1", new OpenApiInfo { Title = "TRUEHOME", Version = "v1" });
                     });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "wApiTRUEHOME v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseResponseCaching();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
