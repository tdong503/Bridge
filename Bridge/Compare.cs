using Bridge.CardTypeHandler;
using Bridge.Model;

namespace Bridge
{
    public class Compare
    {
        public string CompairWith(HandCard handCardA, HandCard handCardB)
        {
            if (handCardA.CardType == handCardB.CardType)
            {
                
                return $" {handCardA.CardType.ToString()}";
            }
            else
            {
                return handCardA.CardType > handCardB.CardType ? handCardA.CardType.ToString() : handCardB.CardType.ToString();
            }
        }

//        private ICardType CompairWithSameType(HandCard handCardA, HandCard handCardB)
//        {
//            if()
//            return 
//        }
    }
}