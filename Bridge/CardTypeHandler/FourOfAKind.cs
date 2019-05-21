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

        public CompareResults Compare(HandCard handCardA, HandCard handCardB)
        {
            var cardNumA = handCardA.Cards.GroupBy(a => a.CardNumber).First(w => w.Count() > 1).Key;
            var cardNumB = handCardB.Cards.GroupBy(a => a.CardNumber).First(w => w.Count() > 1).Key;

            if (cardNumA > cardNumB)
            {
                return CompareResults.Win;
            }
            else if (cardNumA < cardNumB)
            {
                return CompareResults.Lose;
            }

            return CompareResults.Tie;
        }
    }
}