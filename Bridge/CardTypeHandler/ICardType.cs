using System.Collections.Generic;
using Bridge.Model;

namespace Bridge.CardTypeHandler
{
    public interface ICardType
    {
        bool IsThisType(List<Card> cards);
        
        string Compare(HandCard handCardA, HandCard handCardB);
    }
}