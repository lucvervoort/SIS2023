using System;
using System.Collections.Generic;

namespace SIS.Infrastructure.EFRepository.Models;

public partial class Address
{
    public int AddressId { get; set; }

    public string Street { get; set; } = null!;

    public int StreetNumber { get; set; }

    public int? Bus { get; set; }

    public int PostalCode { get; set; }

    public string City { get; set; } = null!;

    public int CountryId { get; set; }

    public DateTime AutoTimeCreation { get; set; }

    public DateTime AutoTimeUpdate { get; set; }

    public int AutoUpdateCount { get; set; }

    public bool IsDeleted { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = new List<Company>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Person> People { get; set; } = new List<Person>();
}
