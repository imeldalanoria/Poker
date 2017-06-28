using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Library;
using System.Linq;

namespace Poker.UnitTests
{
    [TestClass]
    public class ShowdownSolverTests
    {
        [TestMethod]
        public void CanGetSingleWinner()
        {
            // arrange
            const string sampleData = @"
Joe, 3H, 4H, 5H, 6H, 8H
Bob, 3C, 3D, 3S, 8C, 10D
Sally, AC, 10C, 5C, 2S, 2C";
            var playerHands = sampleData.CreateFromStringLines();

            // act
            var winners = ShowdownSolver.GetWinners(playerHands);

            // assert
            Assert.AreEqual("Joe", winners.Single());
        }

        [TestMethod]
        public void CanGetMultipleWinners()
        {
            // arrange
            const string sampleData = @"
Joe, 3H, 4S, 5D, 6C, 8H
Bob, 3C, 3D, 3S, 8D, 10D
Sally, AC, 10C, AH, 2S, AD";
            var playerHands = sampleData.CreateFromStringLines();

            // act
            var winners = ShowdownSolver.GetWinners(playerHands).ToList();

            // assert
            Assert.AreEqual(2, winners.Count);
            Assert.AreEqual("Bob", winners.First());
            Assert.AreEqual("Sally", winners.Last());
        }
    }
}
