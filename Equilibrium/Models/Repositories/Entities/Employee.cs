namespace Equilibrium.Models.Repositories.Entities
{
    public class Employee : IEntity
    {
        public Guid Id { get; }

        public string FirstName { get; }

        public string LastName { get; }

        public string Title { get; }

        public Nationality Nationality { get; }

        public DateTime DateOfBirth { get; }

        public Employee() { }

        public Employee(Guid id, string firstName, string lastName, string title, Nationality nationality, DateTime dateOfBirth)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Title = title;
            Nationality = nationality;
            DateOfBirth = dateOfBirth;
        }

        public bool Equals(IEntity? other)
        {
            if (other is null) return false;
            return this.Id == other.Id;
        }
    }
}
