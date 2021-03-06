﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Poker.Library;

namespace Poker.App
{
    internal static class Program
    {
        private static ConsoleKeyInfo _keyInfo;
        private static readonly DemoPlayingCardConverter _cardConverter = new DemoPlayingCardConverter();
        private static readonly DemoPokerHandConverter _handConverter = new DemoPokerHandConverter();

        private static void Main(string[] args)
        {
            AskUserToContinueOrExit();
            while (Continue)
            {
                PokerDemoCase();
                AskUserToContinueOrExit();
            }
        }

        private static void AskUserToContinueOrExit()
        {
            Print("");
            Print("Press any key to continue OR press <Esc> to exit...");
            _keyInfo = Console.ReadKey(true);
        }

        private static void Print(string text, params object[] arg)
        {
            Console.WriteLine(text, arg);
        }

        private static bool Continue
        {
            get { return _keyInfo.Key != ConsoleKey.Escape; }
        }

        private static void PokerDemoCase()
        {
            Print("");
            Print("---------------------------------------------------");

            var pack = new Pack();
            var players = GetRandomNumberOfPlayers();

            var playerHands =
                players.Select(
                    p => new PlayerHand { Player = p, Cards = pack.Deal(5) })
                    .ToArray();

            Print(@"
  Given following random case:
");

            const string indent = "    ";
            foreach (PlayerHand playerHand in playerHands)
                Print(indent + playerHand);

            Print(@"

  Following poker hands were detected:

");

            foreach (PlayerHand playerHand in playerHands)
            {
                Console.Write(indent + playerHand.Player.PadRight(10));
                foreach (var card in playerHand.Cards)
                {
                    PrintCardColored(card);
                    Console.Write(" ");
                }
                var pokerHand = ShowdownSolver.DetectHand(playerHand);
                Console.WriteLine("    =>    " + _handConverter.ToString(pokerHand));
                Console.WriteLine();
            }

            var winners = ShowdownSolver.GetWinners(playerHands).ToList();

            Print("");
            Print(winners.Count == 1 ? "  So the winner is:" : "  So the winners are:");
            Print("");

            foreach (string winner in winners)
                Print(indent + winner);

            Print("");

        }

        private static IEnumerable<string> GetRandomNumberOfPlayers()
        {
            var rnd = new Random();

            return
                new[] { "Alice", "Bob", "Clara", "Dino", "Elvis", "Ferdinand", "George", "Helen", "Ivan", "John" }
                    .OrderBy(_ => rnd.Next())
                    .Take(rnd.Next(3, 3))
                    .ToArray();
        }

        private static void PrintCardColored(PlayingCard card)
        {
            var foreground = Console.ForegroundColor;
            var background = Console.BackgroundColor;

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor =
                card.Suit == Suit.Clubs || card.Suit == Suit.Spades
                    ? ConsoleColor.Black
                    : ConsoleColor.Red;

            Console.Write(_cardConverter.ToString(card));

            Console.ForegroundColor = foreground;
            Console.BackgroundColor = background;
        }

    }
}
