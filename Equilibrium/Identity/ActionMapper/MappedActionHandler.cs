using Equilibrium.Identity.Entities;
using Equilibrium.Identity.Manager;
using Equilibrium.Identity.Store;
using Equilibrium.Resources;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Equilibrium.Identity.ActionMapper
{
    internal class MappedActionHandler : AuthorizationHandler<MappedActionRequirement>
    {
        User user;
        readonly IdentityManager _manager;
        IHttpContextAccessor ContextAccessor;

        /// <inheritdoc/>
        public MappedActionHandler(IdentityManager identityManager, IHttpContextAccessor contextAccessor)
        {
            _manager = identityManager;
            ContextAccessor = contextAccessor;
        }

        /// <inheritdoc/>
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            MappedActionRequirement requirement)
        {
            AccessGroup rootGroup = await _manager.AccessGroup.FindByNameAsync("ROOT");
            bool isRootUser = await IdentityManager.User.FindInAccessGroupAsync(ContextUser.ContextUserId, rootGroup) != null;

            if (requirement.MustBeMapped && !isRootUser)
            {
                string applicationName = (string)ContextAccessor.HttpContext.Request.RouteValues["Area"];
                string entryPoint = (string)ContextAccessor.HttpContext.Request.RouteValues["Controller"];
                string action = (string)ContextAccessor.HttpContext.Request.RouteValues["Action"];
                string method = ContextAccessor.HttpContext.Request.Method;

                string requestedAction = $"{applicationName}.{entryPoint}.{action}[{method}]";
                ServerActionEntity serverAction = await IdentityManager.Action.FindByNameAsync(requestedAction);

                if (serverAction != null)
                {
                    IQueryable<AccessGroup> accessGroups = IdentityManager.AccessGroup.FindByServerActionEntity(serverAction);

                    if (accessGroups?.Count() > 0)
                    {
                        User user = await IdentityManager.User.FindInAccessGroupAsync(ContextUser.ContextUserId, accessGroups, true);

                        if (user != null)
                        {
                            context.Succeed(requirement);
                        }
                    }
                }
            }
            else
            {
                context.Succeed(requirement);
            }
        }
    }
}
