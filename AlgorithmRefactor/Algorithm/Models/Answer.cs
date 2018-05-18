using System;
using System.Collections;

namespace Algorithm.Models
{
    public class Answer : IComparable<Answer>
    {
        public Person PersonFirst { get; set; }
        public Person PersonSecond { get; set; }
        public TimeSpan AgeInterval   { get; set; }

        public int CompareTo(Answer other)
        {
            return other.AgeInterval.CompareTo(this.AgeInterval);
        }

        // Method to return IComparer object for sort helper.
        public static IComparer SortAnswerAscending()
        {
            return (IComparer)new sortAnswerAscendingHelper();
        }

        private class sortAnswerAscendingHelper : IComparer
        {
            int IComparer.Compare(object a, object b)
            {
                var c1 = (Answer)a;
                var c2 = (Answer)b;
                if (c1.AgeInterval > c2.AgeInterval)
                    return 1;
                if (c1.AgeInterval < c2.AgeInterval)
                    return -1;
                else
                    return 0;
            }
        }
    }

}