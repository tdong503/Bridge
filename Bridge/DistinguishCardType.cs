using System.Collections.Generic;
using Bridge.Model;

namespace Bridge
{
    public static class DistinguishCardType
    {
        public static CardTypes Distinguish(List<Card> cards)
        {
            return CardTypes.Pair;
        }
    }
}