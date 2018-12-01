using EmployeeManagement.Models.EntityModels;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManagement.Repositories.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

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
            services.AddTransient<EmployeeRepository>();
            services.AddTransient<DepartmentRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);


        }
    }
}
