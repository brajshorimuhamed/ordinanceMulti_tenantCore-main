using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ordinanceMulti_tenantCore.application.Doctors;
using ordinanceMulti_tenantCore.application.Helpers;
using ordinanceMulti_tenantCore.application.Infermiers;
using ordinanceMulti_tenantCore.application.Interfaces;
using ordinanceMulti_tenantCore.application.Ordinances;
using ordinanceMulti_tenantCore.application.Users;
using ordinanceMulti_tenantCore.domain.Entities;
using ordinanceMulti_tenantCore.persistence;

namespace ordinanceMulti_tenantCore.Web
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
            services.AddHttpContextAccessor();
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            string connectionString1 = Configuration.GetConnectionString("SharedDatabase");
            string connectionString2 = Configuration.GetConnectionString("TenantDatabase");

            services.AddDbContext<Ordinance_SharedDbContext>(options => options.UseSqlServer(connectionString1));
            services.AddDbContext<Ordinance_TenantDbContext>(options => {
                var scope = services.BuildServiceProvider();
               
                var claims = HttpContextHelper.Context.User.Claims;
                connectionString2 = connectionString2.Replace("#TENANT#", claims.FirstOrDefault(x => x.Type == "Ordinance").Value);
               
                options.UseSqlServer(connectionString2);
            });

            services.AddIdentity<User, Role>()
                .AddEntityFrameworkStores<Ordinance_SharedDbContext>().AddDefaultTokenProviders();

            services.Configure<PasswordHasherOptions>(options =>
            {
                options.CompatibilityMode = PasswordHasherCompatibilityMode.IdentityV2;
            });

            services.Configure<IdentityOptions>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;

                // Password Settings.
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;

                // Lockout Settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User Settings.
                //options.User.AllowedUserNameCharacters =
                //"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                //options.User.RequireUniqueEmail = true;
            });

            services.ConfigureApplicationCookie(options => {
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(5);

                options.LoginPath = $"/Account/Login";

                options.SlidingExpiration = true;
            });

            services.AddTransient<IOrdinance_SharedDbContext, Ordinance_SharedDbContext>();
            services.AddTransient<IOrdinance_TenantDbContext, Ordinance_TenantDbContext>();

            services.AddScoped<IOrdinanceService, OrdinanceService>();
            services.AddScoped<IDoctorService, DoctorService>();
            services.AddScoped<IInfermierService, InfermierService>();
            services.AddScoped<IUserService, UserService>();

            services.AddScoped<IUserHelper, UserHelper>();

            services.AddTransient<ITenantDbContextProvider, TenantDbContextProvider>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            HttpContextHelper.Configure(app.ApplicationServices.GetRequiredService<IHttpContextAccessor>());

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Clinic}/{action=Index}/{id?}");
            });
        }
        
    }
}
