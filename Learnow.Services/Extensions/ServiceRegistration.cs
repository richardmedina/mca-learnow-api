using Learnow.Common.Services;
using Learnow.Services.Security;
using Learnow.Services.User;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Learnow.Services.Extensions
{
    public static class ServiceRegistration
    {
        public static void RegisterLearnowServices(this IServiceCollection services)
        {
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
