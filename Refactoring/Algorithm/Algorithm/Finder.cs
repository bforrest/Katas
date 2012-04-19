using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> persons;

        public Finder(List<Person> people)
        {
            persons = people;
        }

        public RankedPair Find(By findBy)
        {
            if (persons.Count < 2)
                return new RankedPair();

            var pairListing = (from person in persons
                               from person1 in persons.Skip(persons.IndexOf(person) + 1)
                               select person.BirthDate < person1.BirthDate ? new RankedPair(person, person1) : new RankedPair(person1, person)).OrderBy(x => x.AgeGap);
            
            return findBy == By.Closest ? pairListing.First() : pairListing.Last();
        }
    }
}