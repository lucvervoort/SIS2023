namespace SIS.Domain
{
    public class Person
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string SortName { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }
    }
}