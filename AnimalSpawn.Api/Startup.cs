using AnimalSpawn.Domain.Interfaces;
using AnimalSpawn.Infrastructure.Data;
using AnimalSpawn.Infrastructure.Repositories;
using AutoMapper;
using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using AnimalSpawn.Application.Services;
using AnimalSpawn.Infrastructure.Filters;

namespace AnimalSpawn.Api
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
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());      
            services.AddControllers(options => options.Filters.Add<GlobalExceptionFilter>());
            services.AddDbContext<AnimalSpawnContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("AnimalSpawnEF")));
            //services.AddTransient<IAnimalRepository, AnimalRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(SQLRepository<>));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAnimalServices, AnimalService>();
            services.AddTransient<ICountryServices, CountryService>();
            services.AddMvc().AddFluentValidation(options => options.RegisterValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies()));
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
