using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Portal.Application.FoodApplication.Mapper;
using Portal.Application.FoodApplication.Commands.Create;
using Portal.Application.Foods;
using Portal.Persisatance;
using FluentValidation;
using Portal.Application.FoodApplication.Behavior;
using FluentValidation.AspNetCore;
using Portal.Application.FoodApplication.Validation;
using MediatR.Pipeline;
using Portal.Infrastructure.Persistance;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Portal.Infrastructure.Persistance.Repositories;

namespace Portal.UI
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
            services.AddControllersWithViews();
            services.AddDbContext<PortalDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
                options.EnableDetailedErrors();
                options.EnableSensitiveDataLogging();
            });

            services.AddAutoMapper(typeof(FoodMapper).GetTypeInfo().Assembly);
            services.AddMediatR(typeof(FoodCreateCommand).GetTypeInfo().Assembly);
            services.AddTransient<IFoodService, FoodService>();
            services.AddScoped<IJwtRepository, JwtServise>();
            services.AddScoped<IUserRepository, UserService>();

            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidateCommandBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(FoodCreateCommandValidator).GetTypeInfo().Assembly);
            services.AddScoped(typeof(IRequestPostProcessor<,>), typeof(CommitCommandPostProcessor<,>));
            services.AddScoped(typeof(IRequestPreProcessor<>), typeof(GenericRequestPreProcessor<>));

            // services.AddRazorPages().AddFluentValidation(cfg => { cfg.RegisterValidatorsFromAssemblyContaining<FoodAddValidator>(); });

            //  services.AddTransient(typeof(IPipelineBehavior<FoodCreateCommand, Guid>), typeof(CreateFoodValidationBehavior<FoodCreateCommand, Guid>));
            //jwt start
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
               .AddJwtBearer(options =>
               {
                   var secretkey = Encoding.UTF8.GetBytes(Configuration["Jwt:SecretKey"]);
                   var encryptionkey = Encoding.UTF8.GetBytes(Configuration["Jwt:Encryptkey"]);

                   var validationParameters = new TokenValidationParameters
                   {
                       ClockSkew = TimeSpan.Zero, // default: 5 min
                       RequireSignedTokens = true,

                       ValidateIssuerSigningKey = true,
                       IssuerSigningKey = new SymmetricSecurityKey(secretkey),

                       RequireExpirationTime = true,
                       ValidateLifetime = true,

                       ValidateAudience = true, //default : false
                       ValidAudience = Configuration["Jwt:Audience"],

                       ValidateIssuer = true, //default : false
                       ValidIssuer = Configuration["Jwt:Issuer"],

                       TokenDecryptionKey = new SymmetricSecurityKey(encryptionkey)
                   };

                   options.RequireHttpsMetadata = false;
                   options.SaveToken = true;
                   options.TokenValidationParameters = validationParameters;
               });
            //jwt end
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, PortalDbContext dbContext)
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
             DataSeeder.Initialize (dbContext);
        }
    }
}
