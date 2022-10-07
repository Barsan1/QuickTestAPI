using Bogus;

namespace API.Data.Models.Test;

public class Address
{
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? ZipCode { get; set; }
    public int PersonId { get; set; }
    public Person? Person { get; set; }

    public static Address FakeAddress()
    {
        var fakeAddress = new Faker<Address>()
            .RuleFor(st => st.Street, f => f.Address.StreetAddress())
            .RuleFor(c => c.City, f => f.Address.City())
            .RuleFor(c => c.ZipCode, f => f.Address.ZipCode());

        return fakeAddress; 
    }
}

