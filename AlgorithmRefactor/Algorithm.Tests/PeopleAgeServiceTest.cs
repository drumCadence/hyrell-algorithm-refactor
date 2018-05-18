using Algorithm.Models;
using Algorithm.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace Algorithm.Test
{
    public class PeopleAgeServiceTest
    {
        private readonly Person sue = new Person() { Id = 1, Name = "Sue", BirthDate = new DateTime(1950, 1, 1) };
        private readonly Person greg = new Person() { Id = 2, Name = "Greg", BirthDate = new DateTime(1952, 6, 1) };
        private readonly Person mike = new Person() { Id = 3, Name = "Mike", BirthDate = new DateTime(1979, 1, 1) };
        private readonly Person sarah = new Person() { Id = 4, Name = "Sarah", BirthDate = new DateTime(1982, 1, 1) };

        [Fact]
        public void Returns_Empty_Results_When_Given_Empty_List()
        {
            var list = new List<Person>();
            var finderService = new PeopleAgeService(list);

            var result = finderService.FindClosestAges();

            Assert.Null(result.PersonFirst);
            Assert.Null(result.PersonSecond);
        }

        [Fact]
        public void Returns_Empty_Results_When_Given_One_Person()
        {
            var list = new List<Person>() { sue };
            var finderService = new PeopleAgeService(list);

            var result = finderService.FindClosestAges();

            Assert.Null(result.PersonFirst);
            Assert.Null(result.PersonSecond);
        }

        [Fact]
        public void Closest_Ages_Given_Two_People()
        {
            var list = new List<Person>() { sue, greg };
            var finderService = new PeopleAgeService(list);

            var result = finderService.FindClosestAges();

            Assert.Same(sue, result.PersonFirst);
            Assert.Same(greg, result.PersonSecond);
        }

        [Fact]
        public void Closest_Ages_Given_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finderService = new PeopleAgeService(list);

            var result = finderService.FindClosestAges();

            Assert.Same(sue, result.PersonFirst);
            Assert.Same(greg, result.PersonSecond);
        }

        [Fact]
        public void Furthest_Ages_Given_Two_People()
        {
            var list = new List<Person>() { greg, mike };
            var finderService = new PeopleAgeService(list);

            var result = finderService.FindFurthestAges();

            Assert.Same(greg, result.PersonFirst);
            Assert.Same(mike, result.PersonSecond);
        }

        [Fact]
        public void Furthest_Ages_Given_Four_People()
        {
            var list = new List<Person>() { greg, mike, sarah, sue };
            var finderService = new PeopleAgeService(list);

            var result = finderService.FindFurthestAges();

            Assert.Same(sue, result.PersonFirst);
            Assert.Same(sarah, result.PersonSecond);
        }
    }
}
