using System;

namespace Algorithm
{
    public class RankedPair
    {
        public RankedPair() { }

        public RankedPair(Person younger, Person older)
        {
            Younger = younger;
            Older = older;
            AgeGap = Older.BirthDate - Younger.BirthDate;
        }

        public Person Younger { get; protected  set; }
        public Person Older { get; protected set; }
        public TimeSpan AgeGap { get; protected set; }
    }
}