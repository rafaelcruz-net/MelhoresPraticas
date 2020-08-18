using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MelhoresPraticas.ApplicationServices.Account;
using MelhoresPraticas.Domain.Account.Aggregate.Repository;
using MelhoresPraticas.Domain.Product.Agreggate.Repository;
using MelhoresPraticas.Filter;
using MelhoresPraticas.Repository.Context;
using MelhoresPraticas.Repository.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace MelhoresPraticas
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
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<IUserAccountRepository, UserAccountRepository>();
            services.AddTransient<IAccountService, AccountService>();


            services.AddDbContext<MelhoresPraticasContext>(opt =>
            {
                opt.UseSqlServer(Configuration.GetConnectionString("DefaultDatabase"));
            });

            services.AddControllers(o =>
            {
                o.Filters.Add(new HttpResponseExceptionFilter());
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

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
