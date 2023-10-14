using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Survey.EFCore.DataContext;
using Survey.Infra.Interfaces;
using Survey.Repository.Infra_Implement;
using Survey.Services.Implement;
using Survey.Services.Interface;
using Survey.Services.ModelMapper;
using System.ComponentModel;
using System.Reflection.PortableExecutable;

namespace GiglerSurveyAPI
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors(options =>
            {
                options.AddPolicy("EnableCORS",
                builder =>
                {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().Build();
                    //builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials().Build();
                });
            });
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(Configuration["Swagger:version"], new OpenApiInfo
                {
                    Title = Configuration["Swagger:title"],
                    Version = Configuration["Swagger:version"],
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = Configuration["Swagger:description"],
                    Name = Configuration["Swagger:name"],
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
               

            });
            services.AddDbContext<SurveyDBContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("conStr")).UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking));
            services.AddScoped<IMapperFactory, MapperFactory>();
            //Repositories
            services.AddScoped<ITblQuestionRepo, TblQuestionRepo>();
            //services
            services.AddScoped<ITblQuestionService, TblQuestionService>();


        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, ILoggerFactory loggerFactory)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint(Configuration["Swagger:swaggerurl"], Configuration["Swagger:swaggertitle"]);
                });
                app.UseDeveloperExceptionPage();
            }
            app.UseRouting();
            app.UseCors("EnableCORS");
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });


        }

    }
}
