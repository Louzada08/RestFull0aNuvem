using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestFull0aNuvem.Negocios;
using RestFull0aNuvem.Model.Context;
using Microsoft.AspNetCore.Builder;
using RestFull0aNuvem.Repositorio;

namespace RestFull0aNuvem
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            var ConnBd = Configuration["SqlConnection:StrSqlConnection"];

            services.AddDbContext<BdFoodContext>(options => options.UseSqlServer(ConnBd));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddApiVersioning(option => option.ReportApiVersions = true);

            //services.AddSwaggerGen(c =>
            //{
            //    c.SwaggerDoc("v1",
            //        new Info { Title = "RESTfull API With ASP.NET Core 2.0",
            //            Version = "v1" });
            //});

            //Injeção de dependencia
            services.AddScoped<IUsuarioNegocios, UsuarioNegocios>();
            services.AddScoped<IPermissoesNegocios, PermissoesNegocios>();
            services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.UseSwagger();
            //app.UseSwaggerUI(c =>
            //{
            //    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API URFood v1");
            //});

            ////Starting our API in Swagger page
            //var option = new RewriteOptions();
            //option.AddRedirect("^$", "swagger");
            //app.UseRewriter(option);

            app.UseMvc();
        }

    }
}
