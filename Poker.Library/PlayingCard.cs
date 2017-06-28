using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poker.Library.Conversion;

namespace Poker.Library
{
    public class PlayingCard
    {
        public Suit Suit { get; private set; }

        public FaceValue Value { get; private set; }

        protected PlayingCard(): this(Suit.Clubs, FaceValue.Two)
        {
        }


        public PlayingCard(Suit suit, FaceValue faceValue)
        {
            CheckArgument(suit, "suit", "suit");
            CheckArgument(faceValue, "faceValue", "face value");

            Suit = suit;
            Value = faceValue;
        }

        private static void CheckArgument(object actualValue, string paramName, string humanName)
        {
            if (Enum.IsDefined(actualValue.GetType(), actualValue))
                return;

            string message =
                string.Format(
                    "The value '{0}' does not represent a valid {1}.",
                    actualValue, humanName);

            throw new ArgumentOutOfRangeException(paramName, actualValue, message);
        }

        public override string ToString()
        {
            return new PlayingCardConverter().ToString(this);
        }

    }
}
