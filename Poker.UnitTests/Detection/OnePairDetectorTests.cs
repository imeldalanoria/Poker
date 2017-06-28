using System;
using System.Linq;
using Poker.Library.Conversion;
using Poker.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Library.Detection;

namespace Poker.UnitTests.Detection
{
    [TestClass]
    public class OnePairDetectorTests
    {
        private readonly PokerHandDetector detector = new OnePairDetector();

        [TestMethod]
        public void ResultIsOnePair()
        {
            Assert.AreEqual(PokerHand.OnePair, detector.Result);
        }

    }
}
