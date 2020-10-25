using System;
using AS_DomainServices;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_EFShelterData;
using AS_Identity;
using AS_Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AS_Management
{
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:AS_AnimalData:ConnectionString"])
                    .EnableSensitiveDataLogging());

            services.AddDbContext<AppIdentityDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:AS_Identity:ConnectionString"])
                    .EnableSensitiveDataLogging());

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5; // Max amount of login attempts
                // Email must be unique since we use this to link to Customer's domain model.
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<AppIdentityDbContext>()
            .AddDefaultUI()
            .AddDefaultTokenProviders();

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();
            services.AddSession();

            // Dependency Injection; Repos
            services.AddTransient<IAnimalRepository, EFAnimalRepository>();
            services.AddTransient<ICommentRepository, EFCommentRepository>();
            services.AddTransient<ILodgingRepository, EFLodgingRepository>();
            services.AddTransient<IStayRepository, EFStayRepository>();
            services.AddTransient<ITreatmentRepository, EFTreatmentRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();

            // Dependency Injection; Services
            services.AddTransient<IAnimalService, AnimalService>();
            services.AddTransient<IStayService, StayService>();
            services.AddTransient<ILodgingService, LodgingService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ITreatmentService, TreatmentService>();
            services.AddTransient<IUserService, UserService>();

            // Map Domain User to Identity User TODO: Properly implement this
            // services.AddAutoMapper(typeof(Startup)); 
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
