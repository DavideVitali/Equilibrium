namespace Equilibrium.Models.Repositories.Entities
{
    public interface IEntity : IEquatable<IEntity>
    {
        public Guid Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Title { get; }
        public Nationality Nationality { get; }
        public DateTime DateOfBirth { get; }
    }
}
