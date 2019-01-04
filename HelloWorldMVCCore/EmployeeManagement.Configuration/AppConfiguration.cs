using EmployeeManagement.Models.EntityModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using EmployeeManagement.Repositories.Contracts;
using EmployeeManagement.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using EmployeeManagement.BLL.Contracts;
using EmployeeManagement.BLL.Managers;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;

namespace EmployeeManagement.Configuration
{
    public static class AppConfiguration
    {
        public static void ConfigureServices(IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddDbContext<EmployeeDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("EmployeeDbContext")));
            services.AddTransient<IEmployeeRepository>(c =>
            {
                if (1 == 1)
                {
                    return new EmployeeRepository();
                }
                else
                {
                    return null;
                }
            });
            services.AddTransient<DepartmentRepository>();
            services.AddTransient<IContractRepository, ContractRepository>();
            services.AddTransient<IContractManager,ContractManager>();
            services.AddTransient<IEmployeeManager,EmployeeManager>();



            services.AddAutoMapper();

            services.AddIdentity<AppUser,IdentityRole>()
                .AddEntityFrameworkStores<EmployeeDbContext>()
                .AddDefaultTokenProviders();


            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.Cookie.Name = "EmployeeAppCookie";
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(60);
                options.LoginPath = "/Account/Login";
                // ReturnUrlParameter requires 
                //using Microsoft.AspNetCore.Authentication.Cookies;
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.SlidingExpiration = true;
            });


            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }); 


        }
    }
}
