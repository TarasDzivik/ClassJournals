using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

namespace ClassJournals
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            // ������ ������ � ����� appsettings.json
            Configuration.Bind("Project", new Config());

            // ϳ�������� ���������� ���������� �������� � ����� ������
            // AddTransient ������, �� � ������ ������ http ������ ���� ����
            // ����� ��������� ��'���� ��� ���������� (��� ������)
            services.AddTransient<IStudentRepository, EFStudentRepository>();
            services.AddTransient<ILectorRepository, EFLectorRepository>();
            services.AddTransient<ILectureRepository, EFLectureRepository>();
            services.AddTransient<ILectorsScheduleRepository, EFLectorsScheduleRepository>();
            services.AddTransient<IStudentScheduleRepository, EFStudentScheduleRepository>();
            services.AddTransient<DataManager>();

            // ϳ�������� ��
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            // ���������� Identity �������
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            // ���������� authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "myCompanyAuth";              // ����� ����
                options.Cookie.HttpOnly = true;                     // �� ���� �������� �� ������ �볺���

                options.LoginPath = "/account/login";               // ����� ����������� ��� �����������
                options.AccessDeniedPath = "/account/accessdenied"; // ��� ������� �� ����� �����������

                options.SlidingExpiration = true;                   // 
            });


            // ���������� ������� ����������� ��� Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            // ������� ������ ��� controllers & Views
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //��������� �������� � ���� ������ ������� ���
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0)
                .AddSessionStateTempDataProvider();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            //!!! ��� �������� ����� ������� ��������� middleware

            // ������� ��� ���� ��� ���������� �� ����� ������ ������� � ���������
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            // ϳ�������� �������� ��������� ����� (css, js end ect.)
            app.UseStaticFiles();

            app.UseRouting(); // �� � ������������

            /* ϳ�������� �������������� �� ����������� (������� ����������� �� ��������������
             * ������� ���� ���� ������������� "UseRouting" �� �� ��������� �������� "UseEndpoints")*/
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            // ������� �������� (��������)
            app.UseEndpoints(endpoints =>
            {
                // ����'������ ��������� �� ����� ������� � ������������� ������ �������� {area:exists}
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
