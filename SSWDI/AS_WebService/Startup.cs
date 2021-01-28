using AS_Core.DomainModel;
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
using Newtonsoft.Json;
using System;

namespace AS_WebService
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
            // .AddDefaultUI()
            .AddDefaultTokenProviders();

            services.AddAuthorization(options =>
            {
                options.AddPolicy("RequireVolunteer",
                    policy => policy.RequireRole("Volunteer"));
                options.AddPolicy("RequireCustomer",
                    policy => policy.RequireRole("Customer"));
            });

            services.AddControllers();
            services.AddMvc();
            services.AddSwaggerGen();

            services.AddControllers().AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );

            // Dependency Injection; Repos
            services.AddTransient<IAnimalRepository, EFAnimalRepository>();
            services.AddTransient<ICommentRepository, EFCommentRepository>();
            services.AddTransient<ILodgingRepository, EFLodgingRepository>();
            services.AddTransient<IStayRepository, EFStayRepository>();
            services.AddTransient<ITreatmentRepository, EFTreatmentRepository>();
            services.AddTransient<IUserRepository, EFUserRepository>();
            services.AddTransient<IInterestedAnimalRepository, EFInterestedAnimalRepository>();

            // Dependency Injection; Services
            services.AddTransient<IAnimalService, AnimalService>();
            services.AddTransient<IStayService, StayService>();
            services.AddTransient<ILodgingService, LodgingService>();
            services.AddTransient<ICommentService, CommentService>();
            services.AddTransient<ITreatmentService, TreatmentService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IInterestedAnimalService, InterestedAnimalService>();

            // Mapping our ViewModel to the ApplicationUser
            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<User, ApplicationUser>()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.),
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Animal Shelter API");
                c.RoutePrefix = string.Empty;
            });

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
