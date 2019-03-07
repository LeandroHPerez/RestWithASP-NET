using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RestWithASPNET.Model.Context;
using RestWithASPNET.Services.Implementations;
using Microsoft.EntityFrameworkCore;



namespace RestWithASPNET
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
            var connection = Configuration["MySqlConnection:MySqlConnectionString"]; //vai pegar o caminho de conexão do arquico appsettings.json

            //services.AddDbContext<MySqlContext>(options => options.UseMySql(connection));

            services.AddDbContext<MySQLContext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<MySQLContext>(optionsBuilder => optionsBuilder.UseMySQL(connection));

            //services.AddDbContext<MySQLContext>(options => options.UseMySql(connection));


            //Framework MVC
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            //Injeção de dependência
            services.AddScoped<IPersonService, PersonServiceImpl>();
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
