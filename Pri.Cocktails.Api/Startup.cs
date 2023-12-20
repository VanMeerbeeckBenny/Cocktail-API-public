using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Pri.Cocktails.Api.CustumSwagger;
using Pri.Cocktails.Core.Entities;
using Pri.Cocktails.Core.Interfaces.Repositories;
using Pri.Cocktails.Core.Interfaces.Services;
using Pri.Cocktails.Core.Services;
using Pri.Cocktails.Infrastructure.Data;
using Pri.Cocktails.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Pri.Cocktails.Api
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
            services.AddHttpContextAccessor();

            services.AddIdentity<ApplicationUser, IdentityRole>(
                options =>
                {
                    //This is for development only and for you to test it easy
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireDigit = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireLowercase = false;
                    options.Password.RequiredLength = 3;
                }).AddEntityFrameworkStores<CocktailDbContext>();
            
            services.AddDbContext<CocktailDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("CocktailDb")));

            services.AddCors(options =>
           options.AddDefaultPolicy(builder =>
           {
               builder.AllowAnyOrigin();
               builder.AllowAnyMethod();
               builder.AllowAnyHeader();
           }));

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateActor = true,
                    ValidateAudience = true,
                    ValidIssuer = Configuration["JWTConfiguration:Issuer"],
                    ValidAudience = Configuration["JWTConfiguration:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(
                        Configuration["JWTConfiguration:SigninKey"]))
                };
            });

            services.AddAuthorization(option =>
            {
                option.AddPolicy("user", policy =>
                {
                    policy.RequireAssertion(context =>
                    {
                        if (context.User.HasClaim(ClaimTypes.Role, "admin") ||
                            context.User.HasClaim(ClaimTypes.Role, "user")) return true;
                        else return false;
                    });
                });

                option.AddPolicy("admin", policy =>
                {
                    policy.RequireClaim(ClaimTypes.Role, "admin");
                });
            });

            services.AddScoped<IImageService, ImageService>();
            services.AddScoped<ICocktailRepository, CocktailRepository>();
            services.AddScoped<ICocktailService, CocktailService>();
            services.AddScoped<IGlassTypeRepository, GlassTypeRepository>();
            services.AddScoped<IGlassTypeService, GlassTypeService>();
            services.AddScoped<IIngredientRepository, IngredientRepository>();
            services.AddScoped<IIngredientService, IngredientService>();
            services.AddScoped<IToolRepository, ToolRepository>();
            services.AddScoped<IToolService, ToolService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IIngredientTypeRepository, IngredientTypeRepository>();
            services.AddScoped<IIngredientTypeService, IngredientTypeService>();
            services.AddScoped<IMeasuringUnitRepository, MeasuringUnitRepository>();
            services.AddScoped<IMeasuringUnitService, MeasuringUnitService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter the token below:"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                    {
                         {
                               new OpenApiSecurityScheme
                                 {
                                     Reference = new OpenApiReference
                                     {
                                         Type = ReferenceType.SecurityScheme,
                                         Id = "Bearer"
                                     }
                                 },
                                 new string[] {}
                         }
                    });
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Pri.Cocktails.Api", Version = "v1" });
                c.OperationFilter<CustomOperationFilter>();
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pri.Cocktails.Api v1"));

            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }
            
            app.UseHttpsRedirection();
            app.UseCors();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();
                     

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
