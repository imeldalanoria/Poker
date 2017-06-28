using System;
using System.Collections.Generic;
using System.Linq;

namespace Poker.Library.Detection
{
    public abstract class FewOfAKindDetector : PokerHandDetector
    {
        private byte NumOfCardsOfSameKind { get; set; }

        protected FewOfAKindDetector(byte numOfCardsOfSameKind)
        {
            NumOfCardsOfSameKind = numOfCardsOfSameKind;
        }

        public override bool DoDetect(IEnumerable<PlayingCard> cards)
        {
            return
                cards
                    .GroupBy(card => card.Value)
                    .Any(group => group.Count() >= NumOfCardsOfSameKind);
        }
    }
}
