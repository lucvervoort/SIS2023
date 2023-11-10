using System;
using System.Collections.Generic;
namespace SIS.API.DTO
{
    public class PersonDTO
    {
        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string SortName { get; set; } = null!;

        public string? Phone { get; set; }

        public string? Mobile { get; set; }

        public string? Email { get; set; }
    }
}
