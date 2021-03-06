﻿using System.Collections.Generic;
using System.IO;
using Poker.Library.Conversion;

namespace Poker.Library
{
    public static class UtilityExtensions
    {
        public static PlayerHand CreateFromString(this string input)
        {
            return new PlayerHandConverter().FromString(input);
        }

        public static IEnumerable<PlayerHand> CreateFromStringLines(this string inputLines)
        {
            var result = new List<PlayerHand>();

            var reader = new StringReader(inputLines);
            string line;

            do
            {
                line = reader.ReadLine();

                //
                // empty lines will be safely bypassed
                //
                if (!string.IsNullOrEmpty(line))
                {
                    result.Add(line.CreateFromString());
                }

            } while (line != null);

            return result;
        }
    }
}
