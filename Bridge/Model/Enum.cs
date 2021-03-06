using System.ComponentModel;

namespace Bridge.Model
{
    public enum GroupTypes
    {
        Black,
        White
    }

    public enum CompareResults
    {
        Win,
        Lose,
        Tie
    }

    public enum CardTypes
    {
        [Description("high card")]
        HighCard,
        [Description("pair")]
        Pair,
        [Description("two pair")]
        TwoPair,
        [Description("three of a kind")]
        ThreeOfAKind,
        [Description("straight")]
        Straight,
        [Description("flush")]
        Flush,
        [Description("full house")]
        FullHouse,
        [Description("four of a kind")]
        FourOfAKind,
        [Description("straight flush")]
        StraightFlush
    }
    
    public enum CardNums
    {
        [Description("2")]
        Two = 2,
        [Description("3")]
        Three,
        [Description("4")]
        Four,
        [Description("5")]
        Five,
        [Description("6")]
        Six,
        [Description("7")]
        Seven,
        [Description("8")]
        Eight,
        [Description("9")]
        Nine,
        [Description("10")]
        Ten,
        [Description("Jack")]
        J,
        [Description("Queen")]
        Q,
        [Description("King")]
        K,
        [Description("Ace")]
        A
    }

    public enum CardColors
    {
        D,
        C,
        H,
        S
    }
}