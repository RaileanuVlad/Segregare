using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Segregare.Contexts;
using Segregare.Repositories.ScoalaIntrebareRepository;
using Segregare.Repositories.ClasaRepository;
using Segregare.Repositories.IntrebareRepository;
using Segregare.Repositories.MonitorIntrebareRepository;
using Segregare.Repositories.MonitorRepository;
using Segregare.Repositories.ScoalaRepository;
using Segregare.Repositories.UnitateRepository;
using Segregare.Repositories.UnitateIntrebareRepository;
using Segregare.Helpers;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.Extensions.FileProviders;
using System.IO;

namespace Segregare
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDbContext<Context>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));
            services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit = int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddTransient<IScoalaIntrebareRepository, ScoalaIntrebareRepository>();
            services.AddTransient<IClasaRepository, ClasaRepository>();
            services.AddTransient<IIntrebareRepository, IntrebareRepository>();
            services.AddTransient<IMonitorIntrebareRepository, MonitorIntrebareRepository>();
            services.AddTransient<IMonitorRepository, MonitorRepository>();
            services.AddTransient<IScoalaRepository, ScoalaRepository>();
            services.AddTransient<IUnitateRepository, UnitateRepository>();
            services.AddTransient<IUnitateIntrebareRepository, UnitateIntrebareRepository>();
        }
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
            app.UseCors(builder => builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials());
            app.UseMvc();
            app.UseMiddleware<JwtMiddleware>();

        }
    }
}
