using System.Collections.Generic;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public class StraightFlush: ICardType
    {
        public bool IsThisType(List<Card> cards)
        {
            return Common.IsFlush(cards) && Common.IsStraight(cards); 
        }

        public CompareResults Compare(HandCards handCardA, HandCards handCardB)
        {
            for (var i = 0; i < 5; i++)
            {
                if (handCardA.Cards[i].CardNumber > handCardB.Cards[i].CardNumber)
                {
                    return CompareResults.Win;
                } else if (handCardA.Cards[i].CardNumber > handCardB.Cards[i].CardNumber)
                {
                    return CompareResults.Lose;
                }
            }
            
            return CompareResults.Tie;
        }
    }
}