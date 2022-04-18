using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ISRPO.Fourth.AutoMapping;
using ISRPO.Fourth.Domain.Models;
using ISRPO.Fourth.Domain.Repositories.Base;
using ISRPO.Fourth.DTO;
using ISRPO.Fourth.Infrastructure.AutoMapping;
using ISRPO.Fourth.Infrastructure.Contexts;
using ISRPO.Fourth.Infrastructure.Repositories.Base;
using ISRPO.Fourth.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace ISRPO.Fourth
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
            services.AddAutoMapper(expression => expression.AddProfiles(new Profile[]{new EntityMappingProfile(), new EntityToDTOMappingProfile()}));
            services.AddTransient<IRepository<Instrument>, Repository<Instrument>>();
            services.AddDbContext<ApplicationContext>(builder => 
                    builder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = Instruments"), 
                ServiceLifetime.Transient);
            services.AddTransient<InstrumentService>();
            services.AddControllersWithViews();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}