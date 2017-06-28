using System.Linq;
using Poker.Library.Conversion;
using Poker.Library;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Poker.UnitTests.Conversion
{
    [TestClass]
    public class PlayerHandConverterTests
    {
        private readonly IConverter<PlayerHand> converter = new PlayerHandConverter();
        private readonly PlayingCard jackH = new PlayingCard(Suit.Hearts, FaceValue.Jack);
        private readonly PlayingCard tenS = new PlayingCard(Suit.Spades, FaceValue.Ten);

        [TestMethod]
        public void CanConvertToString()
        {
            // arrange
            var playerHand =
                new PlayerHand { Player = "John", Cards = new[] { jackH, tenS, } };

            // act
            string result = converter.ToString(playerHand);

            // assert
            Assert.AreEqual("John, JH, 10S", result);
        }

        [TestMethod]
        public void CanConvertToStringWithoutPlayerName()
        {
            // arrange
            var playerHand = new PlayerHand { Cards = new[] { jackH, tenS, } };

            // act
            string result = converter.ToString(playerHand);

            // assert
            Assert.AreEqual("<player not set>, JH, 10S", result);
        }

        [TestMethod]
        public void CanConvertToStringWithoutCards()
        {
            // arrange
            var playerHand = new PlayerHand { Player = "John" };

            // act
            string result = converter.ToString(playerHand);

            // assert
            Assert.AreEqual("John, <empty hand>", result);
        }

    }
}
