using System;
using System.Linq;
using Poker.Library.Conversion;
using Poker.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Library.Detection;

namespace Poker.UnitTests.Detection
{
    [TestClass]
    public class HighCardDetectorTests
    {
        private readonly PokerHandDetector detector = new HighCardDetector();

        [TestMethod]
        public void ResultIsHighCard()
        {
            Assert.AreEqual(PokerHand.HighCard, detector.Result);
        }
    }
}
