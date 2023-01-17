using static Equilibrium.Components.Resources.IResource;
using System.ComponentModel.DataAnnotations;

namespace Equilibrium.Components.Resources
{
    /// <summary>
    /// Default resource implementation.
    /// </summary>
    public abstract class ResourceBase : ResourceBase<Guid>
    {

    }

    /// <summary>
    /// Generic resource implementation
    /// </summary>
    /// <typeparam name="TKey">Type of the Id property</typeparam>
    public abstract class ResourceBase<TKey> : IResource<TKey>
    {
        /// <inheritdoc/>
        [Key]
        [Required(ErrorMessage = "Campo obbligatorio.")]
        public virtual TKey Id { get; set; }

        /// <inheritdoc/>
        [Required]
        [StringLength(255)]
        public virtual string Name { get; set; }

        /// <inheritdoc/>
        [Required]
        public virtual string CreateUser { get; set; }

        /// <inheritdoc/>
        [Required]
        public virtual DateTime CreateDate { get; set; }
    }
}
