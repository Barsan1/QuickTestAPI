using API.Data.Models.Test;

namespace API.Data;

public class SeedData
{
    public static IEnumerable<Person> GenerateSeedData(int numberOfPersons)
    {
        if (numberOfPersons <= 0 || numberOfPersons > 100) numberOfPersons = 10;

        var pepole = new List<Person>();

        for (int i = 0; i < numberOfPersons; i++)
        {
            pepole.Add(Person.FakePerson());
        }

        return pepole;
    }
}
