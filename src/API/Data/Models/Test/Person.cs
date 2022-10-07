using Bogus;
using System.Text.Json;
using System.Xml;

namespace API.Data.Models.Test;

public class Person
{
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? UserName { get; set; }
    public string? Avatar { get; set; }
    public string? Email { get; set; }
    public DateTime DateOfBirth { get; set; }
    public Address? Address { get; set; }
    public string? Phone { get; set; }

    public static Person FakePerson()
    {
        var fakePerson = new Faker<Person>()
            .RuleFor(fn => fn.FirstName, f => f.Name.FirstName())
            .RuleFor(ls => ls.LastName, f => f.Name.LastName())
            .RuleFor(un => un.UserName, (f, u) => f.Internet.UserName(u.FirstName, u.LastName))
            .RuleFor(u => u.Avatar, f => f.Internet.Avatar())
            .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
            .RuleFor(dob => dob.DateOfBirth, f => f.Person.DateOfBirth)
            .RuleFor(ad => ad.Address, f => Address.FakeAddress())
            .RuleFor(p => p.Phone, f => f.Person.Phone);

        return fakePerson;
    }

    public void PrintJsonObj()
    {
        var options = new JsonSerializerOptions()
        {
            WriteIndented = true
        };
        var json = JsonSerializer.Serialize(this, options);
        Console.WriteLine(json + "\n------------------------------------------------------\n");
    }

}