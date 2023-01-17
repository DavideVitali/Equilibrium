using Equilibrium.Components.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equilibrium.Components.Identity.Entities
{
    /// <summary>
    /// Represents an action within the db. Mapping happens through <see cref="ActionMapAttribute"/> attribute.
    /// </summary>
    /// <remarks>Since this represents a db entity, it differs from <see cref="ServerAction"/> for the Id property.</remarks>
    public class ServerActionEntity : ResourceBase, IEquatable<ServerActionEntity>
    {
        /// <summary>
        /// Server Action description.
        /// </summary>
        [Required]
        public string Description { get; set; }

        /// <summary>
        /// Http method associated to the ServerAction
        /// </summary>
        [Required]
        public bool IsHttpPost { get; set; }

        public bool Equals(ServerActionEntity? other)
        {
            return this.Id == other?.Id;
        }

        /// <summary>
        /// Get the area segment of the ServerAction
        /// </summary>
        public string Area => Name.Split('.')[0];

        /// <summary>
        /// Get the controller segment of the ServerAction
        /// </summary>
        public string Controller => Name.Split('.')[1];

        /// <summary>
        /// Get the action segment of the ServerAction
        /// </summary>
        public string Action => Name.Split('.')[2];

        public List<AccessGroup> AccessGroups { get; set; }
    }
}
