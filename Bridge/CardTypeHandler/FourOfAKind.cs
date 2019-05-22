using System.Collections.Generic;
using System.Linq;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public class FourOfAKind : ICardType
    {
        public bool IsThisType(List<Card> cards)
        {
            return cards.GroupBy(a => a.CardNumber).Any(w => w.Count() == 4);
        }

        public string Compare(HandCard handCardA, HandCard handCardB)
        {
            return CardTypeBase.CompareMultipleCardNumber(handCardA, handCardB);
        }
    }
}