using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SpaServices;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Movies.Data.InMemory;
using Movies.Data.SqLite;
using Movies.Data.Interfaces;
using VueCliMiddleware;
using AutoMapper;
using Movies.Data.Mappings;
using Movies.Data.Services;

namespace Movies.UI
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
            services.AddControllersWithViews();

            // In production, the Vue files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddAutoMapper(typeof(MovieProfile).Assembly);

            var storageType = Configuration.GetValue<string>("Storage");

            if(storageType == "SqLite")
            {
                services.AddScoped(typeof(SqLiteDbContext));
                services.AddTransient(typeof(IMovieRepository), typeof(MovieRepositorySqLite));
                services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepositorySqLite));
                services.AddTransient(typeof(IMovieService), typeof(MovieService));
            }
            else
            {
                services.AddTransient(typeof(IMovieRepository), typeof(MovieRepositoryInMemory));
                services.AddTransient(typeof(ICategoryRepository), typeof(CategoryRepositoryInMemory));
                services.AddTransient(typeof(IMovieService), typeof(MovieService));
            }
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.

                //I have no signed cert for production, yet i wanted to test production build also
                //app.UseHsts();
                //app.UseHttpsRedirection();
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");

                if (env.IsDevelopment())
                {
                    endpoints.MapToVueCliProxy(
                        "{*path}",
                        new SpaOptions { SourcePath = "clientapp" },
                        npmScript: "serve",
                        regex: "Compiled successfully");
                }
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "clientapp";
            });


            var storageType = Configuration.GetValue<string>("Storage");
            if (storageType == "SqLite")
            {
                using (var scope = app.ApplicationServices.CreateScope())
                {
                    var db = scope.ServiceProvider.GetService<SqLiteDbContext>();
                    db.Database.EnsureCreated();
                }
            }
            Seed(app);


        }

        void Seed(IApplicationBuilder app)
        {
            // For DbContext scope
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var mr = scope.ServiceProvider.GetService<IMovieRepository>();
                var cr = scope.ServiceProvider.GetService<ICategoryRepository>();

                Movies.Data.Helpers.Seeder.Seed(mr, cr);
            }
        }
    }
}
