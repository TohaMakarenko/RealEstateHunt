using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using RealEstateHunt.Core.Business.Services;
using RealEstateHunt.Core.Data.UnitOfWork;
using RealEstateHunt.Infrastructure.Business.Services;
using RealEstateHunt.Infrastructure.Data;
using RealEstateHunt.Infrastructure.Data.UnitOfWork.EfUnitOfWork;

namespace RealEstateHunt.WebApp
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            EnsureDatabaseCreated(new DbContextOptionsBuilder()
                .UseSqlServer(Configuration.GetConnectionString("SocialNet"))
                .Options);
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper();
            services.AddDbContext<RehDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("SocialNet")));
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IClientService, ClientService>();
            services.AddTransient<IOfferService, OfferService>();
            services.AddTransient<IRealEstateService, RealEstateService>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddMvc()
                .AddJsonOptions(
                    options => options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore
                );
            ;
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseDefaultFiles();
            var provider = new FileExtensionContentTypeProvider {Mappings = {[".vue"] = "application/javascript"}};
            app.UseStaticFiles(new StaticFileOptions() {
                ContentTypeProvider = provider
            });

            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }

        private void EnsureDatabaseCreated(DbContextOptions dbContextOptions)
        {
            using (var db = new RehDbContext(dbContextOptions)) {
                db.Database.EnsureCreated();
            }
        }
    }
}