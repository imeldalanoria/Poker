using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Library.Detection
{
    public class HighCardDetector : PokerHandDetector
    {
        public override PokerHand Result
        {
            get { return PokerHand.HighCard; }
        }

        public override bool DoDetect(IEnumerable<PlayingCard> cards)
        {
            return cards != null && cards.Any();
        }
    }
}
