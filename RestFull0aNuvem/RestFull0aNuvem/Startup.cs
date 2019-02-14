using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestFull0aNuvem.Negocios;
using RestFull0aNuvem.Negocios.Implementations;
using RestFull0aNuvem.Model.Context;
using Microsoft.AspNetCore.Builder;
using RestFull0aNuvem.Repositorio.Implementations;
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

            services.AddApiVersioning();

            //Injeção de dependencia
            services.AddScoped<IUsuarioNegocios, Negocios.Implementations.UsuarioNegocios>();
            services.AddScoped<IUsuarioRepositorio, UsuarioRepositorios>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }

    }
}
