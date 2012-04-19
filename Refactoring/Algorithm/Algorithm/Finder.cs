using System.Collections.Generic;

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
            List<RankedPair> pairListing = CreateRankedPairs();

            if(pairListing.Count < 1)
            {
                return new RankedPair();
            }

            RankedPair answer = pairListing[0];
            foreach(var result in pairListing)
            {
                switch(findBy)
                {
                    case FindThe.Younger:
                        if(result.AgeGap < answer.AgeGap)
                        {
                            answer = result;
                        }
                        break;

                    case FindThe.Older:
                        if(result.AgeGap > answer.AgeGap)
                        {
                            answer = result;
                        }
                        break;
                }
            }

            return answer;
        }
        private List<RankedPair> CreateRankedPairs()
        {
            var tr = new List<RankedPair>();

            for (var i = 0; i < persons.Count - 1; i++)
            {
                for (var j = i + 1; j < persons.Count; j++)
                {
                    tr.Add(persons[i].BirthDate < persons[j].BirthDate ? new RankedPair(persons[i], persons[j]) : new RankedPair(persons[j], persons[i]));
                }
            }
            return tr;
        }
    }
}