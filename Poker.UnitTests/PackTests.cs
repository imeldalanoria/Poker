using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Library;

namespace Poker.UnitTests
{
    [TestClass]
    public class PackTests
    {
        [TestMethod]
        public void CanCreatePack()
        {
            // arrange

            // act
            var pack = new Pack();

            // assert
            Assert.AreEqual(52, pack.Count());
        }

        [TestMethod]
        public void CanShuffle()
        {
            // arrange
            var pack = new Pack(false /* shuffle */);

            // act
            pack.Shuffle();

            // assert
            Assert.AreNotEqual(Pack.Etalon, pack);
        }

        [TestMethod]
        public void CanDeal()
        {
            // arrange
            var pack = new Pack();

            // act
            var hand = pack.Deal(5);

            // assert
            Assert.AreEqual(5, hand.Count());
            Assert.AreEqual(47, pack.Count());
        }

    }
}
