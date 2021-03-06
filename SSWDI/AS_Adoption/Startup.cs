using System;
using AS_DomainHttpService;
using AS_DomainServices.Repositories;
using AS_DomainServices.Services;
using AS_EFShelterData;
using AS_HttpData;
using AS_Identity;
using AS_Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace AS_Adoption
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

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireVolunteer",
                    policy => policy.RequireRole("Volunteer"));
                options.AddPolicy("RequireCustomer",
                    policy => policy.RequireRole("Customer"));
                options.AddPolicy("VolunteerOrCustomer",
                    policy => policy.RequireRole("Customer", "Volunteer"));
            });

            services.AddControllersWithViews();
            services.AddRazorPages();
            services.AddMvc();
            services.AddSession();

            // TODO: Proper link to user reference via httpservice
            // Dependency Injection; Repos
            // services.AddTransient<IUserRepository, EFUserRepository>();

            // Dependency Injection; Repos
            services.AddTransient<IAnimalHttpRepository, AnimalHttpRepository>();
            services.AddTransient<IInterestHttpRepository, InterestHttpRepository>();
            services.AddTransient<IStayHttpRepositorycs, StayHttpRepository>();
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
