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
using Learnow.Services.Extensions;
using Learnow.Domain;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Learnow.Contract.Mapping;
using Learnow.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace mca_learnow_api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public string CorsPolicyName = "CorsPolicyName";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddDbContext<LearnowDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("LearnowDb")));
            services.AddDbContext<LearnowDbContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("LearnowDb")));

            services.AddJwt(opt => {
                opt.ExpiryMinutes = 5;
                opt.Issuer = "http://localhost";
                opt.SecretKey = "xfFUjAzHpUQaaxrDFJYQKzHtHbNebbTNZcadHRJcqCvSqQApvSDX";
            });

            services.AddSendGrid(options => {
                options.IsEnabled = false;
                options.Apikey = "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";
                options.SenderEmail = "staff@mycleverapp.com";
                options.SenderName = "MyCleverApp No-Reply";
            });

            services.AddAuthentication(options =>
            {
                options.DefaultChallengeScheme = "";
            });
            services.RegisterLearnowServices();
            

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddControllers();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            });

            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName, builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseCors(CorsPolicyName);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
