using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using FluentValidation;
using InterviewLists.Application.Implementations.Services;
using InterviewLists.Application.Infrastructure.AutoMapper;
using InterviewLists.Application.Interfaces;
using InterviewLists.Application.Interfaces.Services;
using InterviewLists.Application.Interfaces.WebServices;
using InterviewLists.Application.Models.Artist;
using InterviewLists.Application.Models.Car;
using InterviewLists.Application.Models.Trip;
using InterviewLists.Infrastructure.WebServices;
using InterviewLists.Persistence;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using RestSharp;

namespace InterviewLists
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
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });
            services.AddTransient<IArtistService, ArtistService>();
            services.AddTransient<ICarService, CarService>();
            services.AddTransient<ITripService, TripService>();
            services.AddTransient<ICarMakeService, CarMakeService>();
            services.AddTransient<ICarModelService, CarModelService>();
            services.AddTransient<ICountriesWebService, CountriesWebService>();
            services.AddTransient<IRestClient, RestClient>();

            services.AddTransient<IValidator<CarCreate>, CarCreateValidator>();
            services.AddTransient<IValidator<CarUpdate>, CarUpdateValidator>();
            services.AddTransient<IValidator<ArtistCreate>, ArtistCreateValidator>();
            services.AddTransient<IValidator<ArtistUpdate>, ArtistUpdateValidator>();
            services.AddTransient<IValidator<TripCreate>, TripCreateValidator>();
            services.AddTransient<IValidator<TripUpdate>, TripUpdateValidator>();


            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            services.AddDbContext<IInterviewDbContext, InterviewDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("InterviewDatabase")));

            /*
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = OpenIdConnectDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

            })
            .AddCookie()
            .AddOpenIdConnect(options =>
            {
                options.Authority = "https://login.microsoftonline.com/92904ab7-965c-404f-abfb-d523297408fa";
                options.ClientId = "f97f3d45-d438-4c74-82d0-54dd1a2f2bcd";
                options.ResponseType = OpenIdConnectResponseType.IdToken;
                options.CallbackPath = "/authorization/callback";
                options.SignedOutRedirectUri = "https://localhost:44354";
                options.TokenValidationParameters.NameClaimType = "name";
                
            });
            */
            /*
            services.AddAuthentication(AzureADDefaults.AuthenticationScheme)
        .AddAzureAD(options => Configuration.Bind("AzureAd", options));

            services.Configure<OpenIdConnectOptions>(AzureADDefaults.OpenIdScheme, options =>
            {
                options.Authority = options.Authority + "/v2.0/";         // Microsoft identity platform

                options.TokenValidationParameters.ValidateIssuer = false; // accept several tenants (here simplified)
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
