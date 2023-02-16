using Equilibrium.Resources;
using System.ComponentModel.DataAnnotations;

namespace Equilibrium.Identity.Entities
{
    public class AccessGroup : ResourceBase, IEquatable<AccessGroup>
    {
        [Required]
        public string Description { get; set; }

        public bool Equals(AccessGroup? other)
        {
            return Id == other?.Id;
        }

        public List<ServerActionEntity> Actions { get; set; } = new();
        public List<User> Users { get; set; } = new();
    }
}
