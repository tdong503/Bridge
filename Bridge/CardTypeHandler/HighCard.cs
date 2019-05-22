using System.Collections.Generic;
using System.Linq;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public class HighCard : ICardType
    {
        public bool IsThisType(List<Card> cards)
        {
            var cardsGroup = cards.GroupBy(a => a.CardNumber).ToList();
            
            return !Common.IsFlush(cards) && !Common.IsStraight(cards) && cardsGroup.Count == 5;
        }

        public string Compare(HandCard handCardA, HandCard handCardB)
        {
            return CardTypeBase.CompareSingleCardNumber(handCardA, handCardB);
        }
    }
}