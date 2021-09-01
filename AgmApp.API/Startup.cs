using AgmApp.Core;
using AgmApp.Core.Handlers.Logic;
using AgmApp.Core.Interfaces;
using AgmApp.Infrastructure.Data;
using AgmApp.Infrastructure.Filters;
using AgmApp.Infrastructure.Repositories;
using AspNetCoreRateLimit;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgmApp.API
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
            services.AddCors();

            //Desactivamos los filtros d emodelo para hacerlos mediante filtros personalizados
            services.AddControllers();
            //.ConfigureApiBehaviorOptions(options => { options.SuppressModelStateInvalidFilter = true; });

            services.AddDbContext<AgmAppContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AgmAppDb"))
            );


            //Resolución de dependencias
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IUserRolesRepository, UserRolesRepository>();
            services.AddTransient<IAuthHandler, AuthHandler>();

            ///JWT antes del mvc
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = Configuration["Authentication:Issuer"],
                    ValidAudience = Configuration["Authentication:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Authentication:SecretKey"]))
                };
            });


            //Limitar número de peticiones
            // needed to load configuration from appsettings.json
            services.AddOptions();

            // needed to store rate limit counters and ip rules
            services.AddMemoryCache();

            //load general configuration from appsettings.json
            services.Configure<IpRateLimitOptions>(Configuration.GetSection("IpRateLimiting"));

            //load ip rules from appsettings.json
           // services.Configure<IpRateLimitPolicies>(Configuration.GetSection("IpRateLimitPolicies"));

            // inject counter and rules stores
            services.AddInMemoryRateLimiting();



            //Filtro personalizado de model.isvalid | FLUENT : SE REGISTRAN LOS ENSAMBLADOS 
            services.AddMvc(options =>
            {
                options.Filters.Add<ModelValidationFilter>();

            });

            // configuration (resolvers, counter key builders)
            services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

            //.AddFluentValidation(options =>
            //{
            //    options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());
            //});
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Configuración del SPA
            app.UseCors(options =>
            {
                options.WithOrigins(Configuration["SPA:Url"]);
                options.AllowAnyMethod();
                options.AllowAnyHeader();
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //Restriciones de limit de IP
            app.UseIpRateLimiting();

            app.UseHttpsRedirection();

            app.UseRouting();

            //JWT
            app.UseAuthentication();

            app.UseAuthorization();



            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
