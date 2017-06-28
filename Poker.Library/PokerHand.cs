namespace Poker.Library.Detection
{
    public enum PokerHand : byte
    {
        Flush = 128,

        ThreeOfAKind = 64,

        OnePair = 32,

        HighCard = 16,

        Unknown = 0
    }
}
