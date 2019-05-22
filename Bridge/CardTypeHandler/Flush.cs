using System.Collections.Generic;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public class Flush : ICardType
    {
        public bool IsThisType(List<Card> cards)
        {
            return Common.IsFlush(cards) && !Common.IsStraight(cards);
        }

        public string Compare(HandCard handCardA, HandCard handCardB)
        {
            return CardTypeBase.CompareSingleCardNumber(handCardA, handCardB);
        }
    }
}