﻿using System;
using Poker.Library;
using Poker.Library.Conversion;

namespace Poker.App
{
    internal class DemoSuitConverter : IConverter<Suit>
    {
        public string ToString(Suit suit)
        {
            switch (suit)
            {
                case Suit.Clubs:
                    return "♣";
                case Suit.Diamonds:
                    return "♦";
                case Suit.Hearts:
                    return "♥";
                case Suit.Spades:
                    return "♠";
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        public Suit FromString(string str)
        {
            throw new NotImplementedException();
        }
    }
}
