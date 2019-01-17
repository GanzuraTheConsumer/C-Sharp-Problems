using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        var people = GenerateListOfPeople();

        Sort(people);
    }

    private static void Sort(List<Person> list)
    {
        var input = Console.ReadLine();

        while (input != "end")
        {
            /*var currentSort = list.Where(x => x.Age > int.Parse(input));
            foreach (var Person in currentSort)
            {
                Console.WriteLine(Person.FirstName);
            }
            if (currentSort.Count() == 0)
            {
                Console.WriteLine("No matches.");
            }*/

            var currentSort = list.Where(x => x.FirstName.Contains(input));
            foreach (var Person in currentSort)
            {
                Console.WriteLine(Person.FirstName);
            }
            if (currentSort.Count() == 0)
            {
                Console.WriteLine("No matches.");
            }

            input = Console.ReadLine();
        }
    }

    public static List<Person> GenerateListOfPeople()
    {
        var people = new List<Person>();

        people.Add(new Person { FirstName = "Eric", LastName = "Fleming", Occupation = "Dev", Age = 24 });
        people.Add(new Person { FirstName = "Steve", LastName = "Smith", Occupation = "Manager", Age = 40 });
        people.Add(new Person { FirstName = "Brendan", LastName = "Enrick", Occupation = "Dev", Age = 30 });
        people.Add(new Person { FirstName = "Jane", LastName = "Doe", Occupation = "Dev", Age = 35 });
        people.Add(new Person { FirstName = "Samantha", LastName = "Jones", Occupation = "Dev", Age = 24 });

        return people;
    }
}

public class Person
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Occupation { get; set; }
    public int Age { get; set; }
}
