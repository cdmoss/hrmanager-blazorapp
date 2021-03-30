using AutoMapper;
using HRManager.Api.Services;
using HRManager.Api.Data;
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
using Microsoft.EntityFrameworkCore;
using IdentityServer4.AccessTokenValidation;
using System.Security.Claims;
using IdentityModel;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;

namespace HRManager.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            Enviornment = env;
        }

        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Enviornment { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationInsightsTelemetry();
            services.ConfigureTelemetryModule<QuickPulseTelemetryModule>((module, o) => module.AuthenticationApiKey = "2bdciekr2ks1sugn4qgj153k01kocvcvvibbevn1");

            SetupDbContext(services);

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HRManager.Api", Version = "v1" });
            });

            services.AddAuthentication(
                IdentityServerAuthenticationDefaults.AuthenticationScheme)
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:5002";
                    options.RoleClaimType = JwtClaimTypes.Role;
                });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddScoped<ITeamService, EFTeamService>();
            services.AddScoped<IShiftService, EFShiftService>();
            services.AddScoped<IAlertService, EFAlertService>();
            services.AddScoped<IPositionService, EFPositionService>();
            services.AddScoped<ITimesheetService, EFTimeSheetService>();
            services.AddScoped<IDbSeeder, DbSeeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (Enviornment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HRManager.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private void SetupDbContext(IServiceCollection services)
        {
            if (Enviornment.IsDevelopment())
            {
                services.AddDbContext<MainContext>(opt => 
                    opt.UseSqlite(Configuration.GetConnectionString("MainDevConnection")));
            }
            else if (Enviornment.IsProduction() || Enviornment.IsStaging())
            {
                services.AddDbContext<MainContext>(opt =>
                    opt.UseNpgsql(Configuration.GetConnectionString("MainProdConnection")));
            }
        }
    }
}
