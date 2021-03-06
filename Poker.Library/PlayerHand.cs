﻿using System;
using System.Collections.Generic;
using Poker.Library.Conversion;

namespace Poker.Library
{
    public class PlayerHand
    {
        public string Player { get; set; }

        /// <remarks>
        /// by default is initialized with an empty list
        /// so client code has no worry and check for null
        /// </remarks>
        public IEnumerable<PlayingCard> Cards
        {
            get { return _cards ?? (_cards = new List<PlayingCard>()); }
            set { _cards = value; }
        }

        private IEnumerable<PlayingCard> _cards;

        public override string ToString()
        {
            return new PlayerHandConverter().ToString(this);
        }
    }
}
