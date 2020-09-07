using BudgetGuard.App.Implementations;
using BudgetGuard.Domain.Models;
using BudgetGuard.Infrastructure.Interfaces;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace BudgetGuard.Tests
{
    public class EntryServiceTests
    {
        [Fact]
        public void HasNewIncomeBeenAdded() 
        {
            //Arrange
            var mock = new Mock<IEntryRepository>();
            mock.Setup(x => x.GetNextId()).Returns(1);
            var newIncome = new Income(1, 400.25M, "Car sale", new DateTime(2020, 01, 01));
            mock.Setup(x => x.Add(newIncome));
            var entryService = new EntryService(mock.Object);

            //Act
            var returnedNewIncomeId = entryService.AddNewIncome(newIncome.Amount, newIncome.Name, newIncome.Date);

            //Assert
            Assert.Equal(1, returnedNewIncomeId);
        }


        [Fact]
        public void HasNewOutcomeBeenAdded()
        {
            //Arrange
            var mock = new Mock<IEntryRepository>();
            mock.Setup(x => x.GetNextId()).Returns(2);
            var newOutcome = new Outcome(2, 5.25M, "Baby dipers", new DateTime(2020, 01, 01));
            mock.Setup(x => x.Add(newOutcome));
            var entryService = new EntryService(mock.Object);

            //Act
            var returnedNewOutcomeId = entryService.AddNewIncome(newOutcome.Amount, newOutcome.Name, newOutcome.Date);

            //Assert
            returnedNewOutcomeId.Should().NotBe(0);
            returnedNewOutcomeId.Should().Be(2);
        }
    }
}
