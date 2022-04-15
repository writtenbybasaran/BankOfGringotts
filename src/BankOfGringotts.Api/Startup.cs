using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BankOfGringotts.Api.Filter;
using BankOfGringotts.Api.Middleware;
using BankOfGringotts.Bussiness.Mappers;
using BankOfGringotts.Common.Helpers.RepoHelper;
using BankOfGringotts.Context.Context;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Serilog;
using Serilog.Core;


namespace BankOfGringotts.Api
{
    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            _logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        private Logger _logger;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
         
           
            services.AddControllersWithViews(options =>
            {
                options.Filters.Add<GeneralExceptionFilter>();
            }).AddFluentValidation();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BankOfGringotts.Api", Version = "v1" });
            });

            services.AddDbContext<GringottsContext>(options =>
                 options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            //Generic Repo
            services.AddConfigureRepositoryWrapper();

            //Auto Mapper
            services.AddMappers();

            //logging
            services.AddLogging(log => log.AddSerilog(_logger));

            //validation
            services.AddGringottsValidators();
            
            //dependency Injection
            services.UseRegisterServices();

            //Jwt Auth
            services.UseCustomJwtAuthorize();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BankOfGringotts.Api v1"));
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
