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

        public CompareResults Compare(HandCard handCardA, HandCard handCardB)
        {
            for (var i = 0; i < 5; i++)
            {
                if (handCardA.Cards[i].CardNumber > handCardB.Cards[i].CardNumber)
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