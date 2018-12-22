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
            services.AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddJsonOptions(options => {
                    options.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                }); 


        }
    }
}
