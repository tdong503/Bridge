using System.Collections.Generic;
using System.Linq;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public class Pair : ICardType
    {
        public bool IsThisType(List<Card> cards)
        {
            var cardsGroup = cards.GroupBy(a => a.CardNumber).ToList();
            
            return cardsGroup.Any(w => w.Count() == 2) && cardsGroup.Count == 4;
        }

        public string Compare(HandCard handCardA, HandCard handCardB)
        {
            return CardTypeBase.CompareMultipleCardNumber(handCardA, handCardB);
        }
    }
}