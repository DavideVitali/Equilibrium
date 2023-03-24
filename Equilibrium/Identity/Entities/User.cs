using Equilibrium.Resources;
using System.ComponentModel.DataAnnotations;

namespace Equilibrium.Identity.Entities
{
    public class User : ResourceBase, IEquatable<User>
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public override string Name { get => base.Name; set => base.Name = $"{LastName}, {FirstName}"; }

        public bool Equals(User? other)
        {
            return Id == other?.Id;
        }

        public List<AccessGroup> AccessGroups { get; set; }
    }
}
