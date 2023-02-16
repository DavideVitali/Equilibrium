namespace Equilibrium.Identity.ActionMapper
{
    /// <summary>
    /// A server-side action
    /// </summary>
    /// <remarks>Note that, unlike <see cref="ServerActionEntity"/> that is a model for EF Core entities, this doesn't have an Id field.</remarks>

    public class ServerAction
    {
        /// <summary>
        /// Full name of the action method in the form Area.Controller.Action
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Action description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// HTTP method
        /// </summary>
        public bool IsHttpPost { get; set; }
    }
}
