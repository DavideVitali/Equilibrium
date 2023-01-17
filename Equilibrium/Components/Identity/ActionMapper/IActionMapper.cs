namespace Equilibrium.Components.Identity.ActionMapper
{
    /// <summary>
    /// Defines a contract for DI
    /// </summary>
    public interface IActionMapper
    {
        /// <summary>
        /// List of server-side actions to be mapped.
        /// </summary>
        public List<ServerAction> ServerActions { get; }
    }
}
