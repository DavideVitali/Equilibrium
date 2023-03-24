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
    public class MappedActionHandler : AuthorizationHandler<MappedActionRequirement>
    {
        User user;
        readonly IdentityManager _manager;
        IHttpContextAccessor _context;

        /// <inheritdoc/>
        public MappedActionHandler(IdentityManager identityManager, IHttpContextAccessor contextAccessor)
        {
            _manager = identityManager;
            _context = contextAccessor;
        }

        /// <inheritdoc/>
        protected override async Task HandleRequirementAsync(
            AuthorizationHandlerContext context,
            MappedActionRequirement requirement)
        {
            HttpContext? ctx = _context.HttpContext;
            if (ctx == null)
            {
                context.Fail();
                return;
            }

            if (ctx.User.Identity == null || !ctx.User.Identity.IsAuthenticated) 
            {
                context.Fail();
                return;
            }

            string userName = ctx.User.Identity!.Name!;
            AccessGroup rootGroup = await _manager.AccessGroups.FindByNameAsync("ROOT", CancellationToken.None);
            User connectedUser = await _manager.Users.FindByNameAsync(userName, CancellationToken.None);
            if (connectedUser == null)
            {
                context.Fail();
                return;
            }

            bool isRootUser = await _manager.Users.FindInAccessGroupAsync(connectedUser, rootGroup, CancellationToken.None) != null;

            if (requirement.MustBeMapped && !isRootUser)
            {
                string applicationName = ctx.Request.RouteValues["Area"] as string ?? throw new ArgumentNullException("Area route value can't be null.");
                string entryPoint = ctx.Request.RouteValues["Controller"] as string ?? throw new ArgumentNullException("Controller route value can't be null.");
                string action = ctx.Request.RouteValues["Action"] as string ?? throw new ArgumentNullException("Action route value can't be null");
                string method = ctx.Request.Method;

                string requestedAction = $"{applicationName}.{entryPoint}.{action}[{method}]";
                ServerActionEntity serverAction = await _manager.ServerActions.FindByNameAsync(requestedAction, CancellationToken.None);

                if (serverAction != null)
                {
                    IQueryable<AccessGroup> accessGroups = _manager.AccessGroups.FindByServerActionEntity(serverAction, CancellationToken.None);

                    if (accessGroups?.Count() > 0)
                    {
                        User user = await _manager.Users.FindInAccessGroupsAsync(connectedUser, accessGroups, CancellationToken.None);

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
