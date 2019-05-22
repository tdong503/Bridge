using System.Collections.Generic;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public class Straight : ICardType
    {
        public bool IsThisType(List<Card> cards)
        {
            return Common.IsStraight(cards) && !Common.IsFlush(cards);
        }

        public string Compare(HandCard handCardA, HandCard handCardB)
        {
            return CardTypeBase.CompareSingleCardNumber(handCardA, handCardB);
        }
    }
}