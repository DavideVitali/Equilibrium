using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Extensions.Options;
using Equilibrium.Identity.ActionMapper;

namespace Web.Policy
{
    /// <summary>
    /// Custom policy provider.
    /// </summary>
    /// <remarks>
    /// This provider overrides the default <see cref="AuthorizeAttribute"/>
    /// </remarks>
    public class AuthorizationPolicyProvider : IAuthorizationPolicyProvider
    {
        /// <inheritdoc/>
        public DefaultAuthorizationPolicyProvider FallbackPolicyProvider { get; set; }

        /// <inheritdoc/>
        public AuthorizationPolicyProvider(IHttpContextAccessor ctx, IOptions<AuthorizationOptions> options)
        {
            FallbackPolicyProvider = new DefaultAuthorizationPolicyProvider(options);
        }

        /// <inheritdoc/>
        public Task<AuthorizationPolicy> GetDefaultPolicyAsync()
        {
            AuthorizationPolicyBuilder policyBuilder = new AuthorizationPolicyBuilder(IISDefaults.AuthenticationScheme);
            policyBuilder.AddRequirements(new MappedActionRequirement(mustBeMapped: true));
            return Task.FromResult(policyBuilder.Build());
        }

        /// <inheritdoc/>
        public Task<AuthorizationPolicy> GetFallbackPolicyAsync() => FallbackPolicyProvider.GetFallbackPolicyAsync();

        public Task<AuthorizationPolicy?> GetPolicyAsync(string policyName)
        {
            return FallbackPolicyProvider.GetPolicyAsync(policyName);
        }
    }
}
