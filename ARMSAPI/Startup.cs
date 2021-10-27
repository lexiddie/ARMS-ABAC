using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ARMSAPI.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using ARMSAPI.Interfaces;
using ARMSAPI.Providers;
namespace ARMSAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("local"),
                sqlServerOptions => sqlServerOptions.CommandTimeout(12000)));

            services.AddIdentity<IdentityUser, IdentityRole>()
                    .AddEntityFrameworkStores<ApplicationDbContext>()
                    .AddDefaultUI()
                    .AddDefaultTokenProviders();

            services.AddMvc();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                    .AddCookie(options =>
                    {
                        options.LoginPath = $"/Identity/Account/Login";
                        options.LogoutPath = $"/Identity/Account/Logout";
                        options.AccessDeniedPath = $"/Identity/Account/AccessDenied";
                    });

            services.AddHttpContextAccessor();  

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            
            services.AddAntiforgery(x => x.HeaderName = "X-XSRF-TOKEN");
            // services.AddAutoMapper();

            services.AddTransient<IExceptionManager, ExceptionManager>();
            services.AddTransient<ILogProvider, LogProvider>();
            services.AddTransient<IExaminationRoomProvider, ExaminationRoomProvider>();
            services.AddTransient<IExaminationAssigningProvider, ExaminationAssigningProvider>();
            services.AddTransient<IFirebaseProvider, FirebaseProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
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
            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();
            
        }
    }
}
