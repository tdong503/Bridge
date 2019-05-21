using System.Collections.Generic;
using System.Linq;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public class ThreeOfAKind : ICardType
    {
        public bool IsThisType(List<Card> cards)
        {
            var cardsGroup = cards.GroupBy(a => a.CardNumber).ToList();
            
            return cardsGroup.Count(w => w.Count() == 3) == 1 && cardsGroup.Count == 3;
        }

        public CompareResults Compare(HandCard handCardA, HandCard handCardB)
        {
            var cardsA = handCardA.Cards.GroupBy(a => a.CardNumber)
                .Select(s => new {CardNumber = s.Key, Count = s.Count()}).OrderByDescending(o => o.Count).ThenByDescending(o => o.CardNumber).ToList();
            var cardsB = handCardB.Cards.GroupBy(a => a.CardNumber)
                .Select(s => new {CardNumber = s.Key, Count = s.Count()}).OrderByDescending(o => o.Count).ThenByDescending(o => o.CardNumber).ToList();

            for (var i = 0; i < cardsA.Count; i++)
            {
                if (cardsA[i].CardNumber > cardsB[i].CardNumber)
                {
                    return CompareResults.Win;
                } else if (handCardA.Cards[i].CardNumber < handCardB.Cards[i].CardNumber)
                {
                    return CompareResults.Lose;
                }
            }
            
            return CompareResults.Tie;
        }
    }
}