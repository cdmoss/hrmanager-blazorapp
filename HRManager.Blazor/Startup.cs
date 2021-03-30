using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using HRManager.Common;
using Syncfusion.Blazor;
using Blazorise;
using Blazorise.Bootstrap;
using Blazorise.Icons.FontAwesome;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Net.Http.Headers;
using Microsoft.IdentityModel.Tokens;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.AspNetCore.Localization;
using IdentityModel;
using HRManager.Blazor.Services;
using HRManager.Blazor.Adaptors;
using Microsoft.Extensions.Options;
using Blazored.Modal;
using Microsoft.ApplicationInsights.Extensibility.PerfCounterCollector.QuickPulse;

namespace HRManager.Blazor
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Clear(); // prevents our configured claims from being mapped to defaults
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.ConfigureTelemetryModule<QuickPulseTelemetryModule>((module, o) => module.AuthenticationApiKey = "54hoe6zdjlcpixiwlopcitytuttx7vhkn3lqvxle");

            services.AddServerSideBlazor().AddCircuitOptions(o =>
            {
                o.DetailedErrors = true;
            });
            services.AddSyncfusionBlazor();

            #region localization
            services.AddLocalization(options => options.ResourcesPath = "Resources");
            services.AddSingleton(typeof(ISyncfusionStringLocalizer), typeof(SyncfusionLocalizer));
            services.Configure<RequestLocalizationOptions>(options =>
            {
                // Define the list of cultures your app will support
                var supportedCultures = new List<CultureInfo>()
                {
                    new CultureInfo("en-US"),
                    new CultureInfo("de")
                };
                // Set the default culture
                options.DefaultRequestCulture = new RequestCulture("en-US");
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;
            });
            #endregion

            services.AddRazorPages();
            services.AddBlazorise(options =>
            {
                    options.ChangeTextOnKeyPress = true; // optional
            })
                .AddBootstrapProviders()
                .AddFontAwesomeIcons();

            services.AddBlazoredModal();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
            })
                .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddOpenIdConnect(OpenIdConnectDefaults.AuthenticationScheme, // responsible for creating authorization request, token requests and token validation
                    options =>
                    {
                        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                        options.Authority = "https://localhost:5002/";
                        options.ClientId = "blazorclient";
                        options.ClientSecret = "secret";
                        options.ResponseType = "code"; // PKCE protection is used by default
                        options.Scope.Add("role"); // openid and profile scopes are requested by default
                        options.Scope.Add("profile");
                        options.Scope.Add("main.super_admin");
                        options.Scope.Add("main.admin");
                        options.Scope.Add("main.member");
                        options.ClaimActions.DeleteClaim("sid"); // uneeded
                        options.ClaimActions.DeleteClaim("idp"); // uneeded
                        options.ClaimActions.DeleteClaim("s_hash"); // uneeded
                        options.ClaimActions.DeleteClaim("auth_time"); // uneeded
                        options.ClaimActions.MapUniqueJsonKey("role", "role");
                        options.ClaimActions.MapUniqueJsonKey("member_id", "member_id");
                        options.SaveTokens = true;
                        options.GetClaimsFromUserInfoEndpoint = true;
                        options.TokenValidationParameters.NameClaimType = JwtClaimTypes.GivenName;
                        options.TokenValidationParameters.RoleClaimType = JwtClaimTypes.Role;
                    });

            // client for accessing the api
            services.AddHttpClient("ApiClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5001");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            // client for accessing the idp
            services.AddHttpClient("IdpClient", client =>
            {
                client.BaseAddress = new Uri("https://localhost:5002");
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Add(HeaderNames.Accept, "application/json");
            });

            services.AddScoped<TokenProvider>();
            services.AddScoped<ScheduleAdaptor>();
            services.AddScoped<IShiftService, HttpShiftService>();
            services.AddScoped<ITeamService, HttpTeamService>();
            services.AddScoped<IPositionService, HttpPositionService>();
            services.AddScoped<ITimesheetService, HttpTimesheetService>();
            services.AddScoped<IRegistrationService, RegistrationService>();
            services.AddScoped<IAlertService, HttpAlertService>();
            services.AddScoped<IDbSeeder, DbSeeder>();
            services.AddApplicationInsightsTelemetry();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("@31392e312e30Iq6ATYCwWbeLKFZ5vaJeF3JxjE4NRvxR3n+xoyJARsI=");
            #region Localization
            app.UseRequestLocalization(app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>().Value);
            #endregion

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapRazorPages();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
