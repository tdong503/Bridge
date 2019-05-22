using System.Collections.Generic;
using System.Linq;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public static class CardTypeBase
    {
        public static string CompareSingleCardNumber(HandCard handCardA, HandCard handCardB)
        {
            return CompareMultipleCardNumber(handCardA, handCardB);
        }

        public static string CompareMultipleCardNumber(HandCard handCardA, HandCard handCardB)
        {
            var cardsA = handCardA.Cards.GroupBy(a => a.CardNumber)
                .Select(s => new {CardNumber = s.Key, Count = s.Count()}).OrderByDescending(o => o.Count).ThenByDescending(o => o.CardNumber).ToList();
            var cardsB = handCardB.Cards.GroupBy(a => a.CardNumber)
                .Select(s => new {CardNumber = s.Key, Count = s.Count()}).OrderByDescending(o => o.Count).ThenByDescending(o => o.CardNumber).ToList();

            for (var i = 0; i < cardsA.Count; i++)
            {
                if (cardsA[i].CardNumber > cardsB[i].CardNumber)
                {
                    return $"{handCardA.GroupType} wins - {handCardA.CardType.GetDescription()}";
                } else if (cardsA[i].CardNumber < cardsB[i].CardNumber)
                {
                    return $"{handCardB.GroupType} wins - {handCardB.CardType.GetDescription()}";
                }
            }
            
            return $"Tie - {handCardA.CardType.GetDescription()}";
        }
        
    }
}