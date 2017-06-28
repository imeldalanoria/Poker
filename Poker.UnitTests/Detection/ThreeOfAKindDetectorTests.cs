using System;
using System.Linq;
using Poker.Library.Conversion;
using Poker.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Library.Detection;

namespace Poker.UnitTests.Detection
{
    [TestClass]
    public class ThreeOfAKindDetectorTests
    {
        private readonly PokerHandDetector detector = new ThreeOfAKindDetector();

        [TestMethod]
        public void ResultIsThreeOfAKind()
        {
            Assert.AreEqual(PokerHand.ThreeOfAKind, detector.Result);
        }

    }
}
