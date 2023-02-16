using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace Equilibrium.Identity.ActionMapper
{
    /// <summary>
    /// Inspects the Controllers collection and maps the action methods decorated with the ActionMapAttribute
    /// </summary>
    public class ActionMapper : IActionMapper
    {
        /// <inheritdoc/>
        public List<ServerAction> ServerActions { get; } = new List<ServerAction>();

        /// <inheritdoc/>
        public ActionMapper(IActionDescriptorCollectionProvider provider)
        {
            foreach (ActionDescriptor mappedAction in provider.ActionDescriptors.Items)
            {
                var actionMapAttribute = mappedAction.EndpointMetadata.FirstOrDefault(collection => collection.GetType() == typeof(ActionMapAttribute));

                if (actionMapAttribute != null)
                {
                    bool isHttpPost = mappedAction.EndpointMetadata.Any(c => c.GetType() == typeof(HttpPostAttribute));
                    string httpPostIdentifier = isHttpPost ? "POST" : "GET";
                    ServerAction action = new ServerAction
                    {
                        Description = ((ActionMapAttribute)actionMapAttribute).Description,
                        Name = $"{mappedAction.RouteValues["area"]}.{mappedAction.RouteValues["controller"]}.{mappedAction.RouteValues["action"]}[{httpPostIdentifier}]",
                        IsHttpPost = isHttpPost
                    };

                    ServerActions.Add(action);
                }
            }
        }
    }
}
