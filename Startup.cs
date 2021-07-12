using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Watch_List.Data;


namespace Watch_List
{

    public class Startup
    {


        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }


        public async Task CreateGestorAsync(WatchListDbContext context, UserManager<ApplicationUser> userManager)
        {



            const string nome = "gestor";
            const string email = "gestor@gestor.com";
            const string password = "98w6kB.RWUS5a2P";



            var user = new ApplicationUser
            {
                UserName = email,
                Email = email,
                DataRegisto = DateTime.Now,
                EmailConfirmed = true, // o email está confirmado
            };
            if (!userManager.Users.Contains<ApplicationUser>(user))
            {
                var util = new Watch_List.Models.Utilizador

                {
                    Email = email,
                    Id = 1,
                    Nome = nome,
                    UtilIdFK = user.Id,
                };
                var result = await userManager.CreateAsync(user, password);

                if (result.Succeeded)
                {


                    await userManager.AddToRoleAsync(user, "Gestor");

                }
                context.Add(context.Utilizador); // adicionar o utilizador
                await context.SaveChangesAsync();
            }


        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // variaveis aux 
            services.AddDistributedMemoryCache();
            services.AddSession(options => {
                options.IdleTimeout = TimeSpan.FromSeconds(100);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            
            services.AddDbContext<WatchListDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddDatabaseDeveloperPageExceptionFilter();

            // deixa -se  de referir 'IdentityUser' e passa-se a usar 'ApplicationUser'

            services.AddDefaultIdentity<ApplicationUser>(options =>
                          options.SignIn.RequireConfirmedAccount = true)
                                 .AddRoles<IdentityRole>()  // ativa o uso de Roles
                                 .AddEntityFrameworkStores<WatchListDbContext>();
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
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

            // permitir o uso de vars. de sessão
            app.UseSession();

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
