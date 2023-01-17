﻿using Equilibrium.Components.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Equilibrium.Components.Identity.Entities
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
            return this.Id == other?.Id;
        }

        public List<AccessGroup> AccessGroups { get; set; }
    }
}
