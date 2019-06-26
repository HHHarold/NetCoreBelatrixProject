using AutoMapper;
using Chinook.Repository.Postgresql;
using Chinook.WebApi.Identity.Data;
using Chinook.WebApi.Models;
using Chinook.WebApi.Profiles;
using Chinook.WebApi.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Chinook.WebApi
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
            services.AddControllers()
                .AddNewtonsoftJson();

            services.AddAutoMapper(typeof(CustomerProfile).Assembly);
            services.AddAutoMapper(typeof(EmployeeProfile).Assembly);

            services.AddEntityFrameworkNpgsql()
               .AddDbContextPool<ChinookDbContext>(
                    opt => opt.UseNpgsql(Configuration.GetConnectionString("postgresql"),
                    b => b.MigrationsAssembly("Chinook.WebApi")))
                .BuildServiceProvider();

            services.AddEntityFrameworkNpgsql()
                .AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(Configuration.GetConnectionString("postgresql"), 
                    x => x.MigrationsAssembly("Chinook.WebApi")))
                .BuildServiceProvider();

            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultTokenProviders();

            services.AddTransient<IRepository<Album>, Repository<Album>>();
            services.AddTransient<IRepository<Artist>, Repository<Artist>>();
            services.AddTransient<IRepository<Customer>, Repository<Customer>>();
            services.AddTransient<IRepository<Employee>, Repository<Employee>>();
            services.AddTransient<IRepository<Genre>, Repository<Genre>>();
            services.AddTransient<IRepository<Invoice>, Repository<Invoice>>();
            services.AddTransient<IRepository<InvoiceLine>, Repository<InvoiceLine>>();
            services.AddTransient<IRepository<MediaType>, Repository<MediaType>>();
            services.AddTransient<IRepository<Playlist>, Repository<Playlist>>();
            services.AddTransient<IRepository<PlaylistTrack>, Repository<PlaylistTrack>>();
            services.AddTransient<IRepository<Track>, Repository<Track>>();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Chinook Web Api",
                    Version = "v1"
                });
                c.CustomSchemaIds(x => x.FullName);                
            });
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            SeedData.Initialize(app.ApplicationServices
                .GetRequiredService<IServiceScopeFactory>()
                .CreateScope().ServiceProvider);

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Chinook Web Api v1");
            });
        }
    }
}
