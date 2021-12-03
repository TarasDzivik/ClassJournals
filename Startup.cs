using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc;
using ClassJournals.Domain;
using ClassJournals.Domain.Repositories.EntityFramework;
using ClassJournals.Domain.Repositories.Abstract;
using ClassJournals.Service;
using System;

namespace ClassJournals
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // Додаємо конфіг з файлу appsettings.json
            Configuration.Bind("Project", new Config());

            // Підключаємо необхідний функціонал програми в якості сервісів
            // AddTransient Означає, що в рамках одного http запиту може бути
            // нижче підключаємо об'єкти цих репозиторіїв (при потребі)
            services.AddTransient<IStudentRepository, EFStudentRepository>();
            services.AddTransient<ILectorRepository, EFLectorRepository>();
            services.AddTransient<ILectureRepository, EFLectureRepository>();
            services.AddTransient<ILectorsScheduleRepository, EFLectorsScheduleRepository>();
            services.AddTransient<IStudentScheduleRepository, EFStudentScheduleRepository>();
            services.AddTransient<ICourcesRepository, EFCourcesRepositories>();
            services.AddTransient<IGroupsRepository, EFGroupeRepository>();
            services.AddTransient<DataManager>();

            // Підключаємо БД
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            // Настроюємо Identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                // Password settings
                opts.User.RequireUniqueEmail = true; // Підтвердження емейлу через лист (має прийти на пошту)
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false; // поки що не добавляю вимоги що до пароля...
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireDigit = false;

                opts.SignIn.RequireConfirmedAccount = true;

                opts.User.AllowedUserNameCharacters = 
                "АаБбВвГгҐґДдЕеЄєЖжЗзиІіЇїЙйКкЛлМмНнОоПпРрСсТтУуФфХхЦцЧчШшЩщьЮюЯя'" + // Чи виникнуть трабли при реєстрації користувача
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";               // при використанні кириличних символів в якості логіну?
                opts.User.RequireUniqueEmail = true;

                opts.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
                opts.Lockout.MaxFailedAccessAttempts = 5;
                opts.Lockout.AllowedForNewUsers = true;

            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            // Настроюємо authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.ExpireTimeSpan = TimeSpan.FromMinutes(1);
                options.Cookie.Name = "ClassJournals";              // назва куккі
                options.Cookie.HttpOnly = true;                     // не буде доступна на стороні клієнта

                options.LoginPath = "/account/login";               // адрес контроллера для авторизації
                options.AccessDeniedPath = "/account/accessdenied"; // для доступу до панелі адміністраора

                options.SlidingExpiration = true;                   // 
            });


            // настроюємо політику авторизації для Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            // Додаэмо сервіси для controllers & Views
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //добавлаем сумісність з більш ранніми версіями АСП
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();
           
            app.UseStaticFiles();

            app.UseRouting();

            /* Підключаємо аутентифікацію та авторизацію (Порядок авторизації та аутентифікації
             * повинен буди після маршрутизації "UseRouting" но до реєстрації маршрутів "UseEndpoints")*/
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // Реєструєм маршрути (ендпоінти)
            app.UseEndpoints(endpoints =>
            {
                // обов'язково позначаємо що такий маршрут в маршрутизаторі мусить існувати {area:exists}
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}