using Algorithm.Helpers;
using Algorithm.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Algorithm.Services
{
    public class PeopleAgeService : IAgeService
    {
        private readonly IList<Person> _people;

        public PeopleAgeService(List<Person> people)
        {
            _people = people;
        }

        /// <summary>
        /// Find the the two people whose ages are the closest together.
        /// </summary>
        /// <returns>The answer to your quest</returns>
        public Answer FindClosestAges()
        {
            var answers = SetAgeDifferences(AgeCompareCriteria.Closest);
            return (answers.Count() > 0) ? answers.FirstOrDefault() : new Answer();
        }

        /// <summary>
        /// Find the the two people whose ages are the farthest apart.
        /// </summary>
        /// <returns>The answer to your quest</returns>
        public Answer FindFurthestAges()
        {
            var answers = SetAgeDifferences(AgeCompareCriteria.Closest);
            return (answers.Count() > 0) ? answers.LastOrDefault() : new Answer();
        }

        /// <summary>
        /// Find the people whose ages differ according to the age comparison type criteria.
        /// </summary>
        /// <param name="compareBy">The age comparison type criteria</param>
        /// <returns></returns>
        private IEnumerable<Answer> SetAgeDifferences(AgeCompareCriteria compareBy)
        {
            Validate(compareBy);

            // Get comparison results
            var answerCandidates = _people.CombinationBuilder((a, b) => SetBirthdateInterval(a, b)).ToList<Answer>();
            if (answerCandidates.Count < 1)
            {
                return new List<Answer>();
            }
            return answerCandidates.ToList().OrderBy(a => a.AgeInterval);
        }

        /// <summary>
        /// Create an Answer object from all combiniations of people and determine the difference interval in their birth dates
        /// </summary>
        /// <param name="candidate1"></param>
        /// <param name="candidate2"></param>
        /// <returns></returns>
        private Answer SetBirthdateInterval(Person candidate1, Person candidate2)
        {
            IList<Answer> answerCandidates = new List<Answer>();
            var answer = (candidate1.BirthDate < candidate2.BirthDate)
                ? new Answer { PersonFirst = candidate1, PersonSecond = candidate2, AgeInterval = candidate2.BirthDate - candidate1.BirthDate }
                : new Answer { PersonFirst = candidate2, PersonSecond = candidate1, AgeInterval = candidate1.BirthDate - candidate2.BirthDate };

            return answer;
        }

        /// <summary>
        /// Validate user input arguments.
        /// </summary>
        /// <param name="compareBy"></param>
        /// <returns></returns>
        private bool Validate(AgeCompareCriteria compareBy)
        {
            if (compareBy == AgeCompareCriteria.Undefined) throw new ArgumentException("The comparison type criteria was not defined");
            if (_people == null) throw new ArgumentException("A list people were expected");

            return true;
        }
    }
}
