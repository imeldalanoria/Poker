﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Library.Detection;

namespace Poker.Library
{
    public static class ShowdownSolver
    {
        public static IEnumerable<string> GetWinners(IEnumerable<PlayerHand> playerHands)
        {
            var detector = GetDetectionChain();

            var detectedHands =
                playerHands.Select(hand =>
                    new
                    {
                        DetectedHand = detector.Detect(hand.Cards),
                        PlayerName = hand.Player,
                        //Cards = hand.Cards
                    });

            var winningGroup =
                detectedHands
                    .GroupBy(_ => _.DetectedHand)
                    .OrderBy(_ => _.Key)
                    .Last();

            var winners = winningGroup.Select(_ => _.PlayerName).ToArray();

            return winners;
        }

        public static PokerHand DetectHand(PlayerHand playerHand)
        {
            var detector = GetDetectionChain();

            return detector.Detect(playerHand.Cards);
        }

        private static PokerHandDetector GetDetectionChain()
        {
            var flushDetector = new FlushDetector();
            var threeOfAKindDetector = new ThreeOfAKindDetector();
            var onePairDetector = new OnePairDetector();
            var highCardDetector = new HighCardDetector();

            flushDetector.Successor = threeOfAKindDetector;
            threeOfAKindDetector.Successor = onePairDetector;
            onePairDetector.Successor = highCardDetector;

            return flushDetector;
        }
    }
}
