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

        public CompareResults Compare(HandCard handCardA, HandCard handCardB)
        {
            var cardNumA = handCardA.Cards.GroupBy(a => a.CardNumber).First(w => w.Count() > 2).Key;
            var cardNumB = handCardB.Cards.GroupBy(a => a.CardNumber).First(w => w.Count() > 2).Key;

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