using Equilibrium.Identity.ActionMapper;
using Equilibrium.Identity.Entities;
using Equilibrium.Identity.Manager;
using Equilibrium.Identity.Policy;
using Equilibrium.Identity.Store;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Equilibrium.Identity.Configuration
{
    public static class IdentityConfiguration
    {
        public static void AddEquilibrium(this IServiceCollection services, Action<DbContextOptionsBuilder>? optionsAction = null)
        {
            services.AddHttpContextAccessor();

            // Custom policy provider
            services.AddSingleton<IAuthorizationPolicyProvider, AuthorizationPolicyProvider>();
            // default handler override
            services.AddTransient<IAuthorizationHandler, MappedActionHandler>();

            services.AddSingleton<IActionMapper, ActionMapper.ActionMapper>();

            services.AddDbContext<IdentityContext>(optionsAction);

            services.AddScoped<UserStore>();
            services.AddScoped<AccessGroupStore>();
            services.AddScoped<ServerActionEntityStore>();

            services.AddAuthentication(IISDefaults.AuthenticationScheme);
            
            services.AddScoped<UserManager>();
            services.AddScoped<AccessGroupManager>();
            services.AddScoped<ServerActionManager>();
            services.AddScoped<IdentityManager>();
        }

        public static void UseEquilibrium(this IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
