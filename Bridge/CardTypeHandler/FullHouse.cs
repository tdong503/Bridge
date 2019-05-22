using System.Collections.Generic;
using System.Linq;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public class FullHouse : ICardType
    {
        public bool IsThisType(List<Card> cards)
        {
            var cardsGroup = cards.GroupBy(a => a.CardNumber).ToList();
            
            return cardsGroup.Any(w => w.Count() == 3) && cardsGroup.Count == 2;
        }

        public string Compare(HandCard handCardA, HandCard handCardB)
        {
            return CardTypeBase.CompareMultipleCardNumber(handCardA, handCardB);
        }
    }
}