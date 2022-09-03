using Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Model.General;

namespace WebApiMicroData
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
            //Settings settings = new Settings();
            //Configuration.GetSection("Settings").Bind(settings);
            services.Configure<Settings>(options => Configuration.GetSection("Settings").Bind(options));

            var connection = Configuration["ConexaoSql:ConnectionString"];

            services.AddDbContext<SolutionContext>(options =>
              options.UseSqlServer(connection));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "API NFe - WCI",
                        Version = "v1",
                        Description = "API NFe - WCI criada com o ASP.NET Core",
                        Contact = new OpenApiContact
                        {
                            Name = "Samuel Apolion Benevenuto"
                        }
                    });

                //string caminhoAplicacao = PlatformServices.Default.Application.ApplicationBasePath;
                //string nomeAplicacao = PlatformServices.Default.Application.ApplicationName;
                //string caminhoXmlDoc = Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                //c.IncludeXmlComments(caminhoXmlDoc);

                //c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
            });

            services.AddControllersWithViews().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());


            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "API Pedidos - Micro Data");
            });
        }
    }
}
