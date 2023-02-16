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
        public string Description { get; set; }
    }
}
