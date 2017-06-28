using System;
using System.Collections.Generic;

namespace Poker.Library.Detection
{
    public class OnePairDetector : FewOfAKindDetector
    {
        public OnePairDetector()
            : base(2 /*numOfCardsOfSameKind */)
        {
        }

        public override PokerHand Result
        {
            get { return PokerHand.OnePair; }
        }
    }
}
