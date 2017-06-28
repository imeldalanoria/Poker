using System;
using System.Linq;
using Poker.Library.Conversion;
using Poker.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Poker.Library.Detection;


namespace Poker.UnitTests.Detection
{
    [TestClass]
    public class FlushDetectorTests
    {
        private readonly PokerHandDetector detector = new FlushDetector();

        [TestMethod]
        public void ResultIsFlash()
        {
            Assert.AreEqual(PokerHand.Flush, detector.Result);
        }

    }
}
