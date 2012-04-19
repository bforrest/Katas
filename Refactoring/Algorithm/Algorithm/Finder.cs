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

        public RankedPair Find(FindThe findBy)
        {
            List<RankedPair> pairListing = CreateSortedRankedPairMatrix();

            if (pairListing.Count < 1)
            {
                return new RankedPair();
            }

            if (findBy == FindThe.Closest)
            {
                return pairListing.First();
            }
            return pairListing.Last();
        }

        private List<RankedPair> CreateSortedRankedPairMatrix()
        {
            var tr = new List<RankedPair>();

            for (var i = 0; i < persons.Count - 1; i++)
            {
                for (var j = i + 1; j < persons.Count; j++)
                {
                    tr.Add(persons[i].BirthDate < persons[j].BirthDate ? new RankedPair(persons[i], persons[j]) : new RankedPair(persons[j], persons[i]));
                }
            }
            return tr.OrderBy(x => x.AgeGap).ToList();
        }
    }
}