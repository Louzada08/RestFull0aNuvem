using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestFull0aNuvem.Services;
using RestFull0aNuvem.Services.Implementations;
using RestFull0aNuvem.Model.Context;
using Microsoft.AspNetCore.Builder;

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
            var ConnBd = Configuration["SqlConnection:StrSqlConnection"];

            services.AddDbContext<BdFoodContext>(options => options.UseSqlServer(ConnBd));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            //Injeção de dependencia
            services.AddScoped<IUsuarioService, UsuarioServiceImplementations>();
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
