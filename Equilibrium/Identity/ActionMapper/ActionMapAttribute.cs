namespace Equilibrium.Identity.ActionMapper
{
    /// <summary>
    /// Enables mapping an action method for authorization purposes
    /// </summary>
    public class ActionMapAttribute : Attribute
    {
        /// <summary>
        /// Short description about the action
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Initializes an instance of ActionMapAttribute
        /// </summary>
        /// <param name="description">A brief description of what the action does.</param>
        public ActionMapAttribute(string description) {
            Description = description;
        }
    }
}
