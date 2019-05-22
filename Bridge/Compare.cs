using System;
using System.Collections.Generic;
using System.Linq;
using Bridge.CardTypeHandler;
using Bridge.Model;

namespace Bridge
{
    public class Compare
    {
        private readonly Func<CardTypes, ICardType> _serviceAccessor;

        public Compare(Func<CardTypes, ICardType> serviceAccessor)
        {
            _serviceAccessor = serviceAccessor;
        }

        public string CompareWith(HandCard handCardA, HandCard handCardB)
        {
            if (handCardA.CardType == handCardB.CardType)
            {
                var result = GetCardTypeHandler(handCardA.CardType).Compare(handCardA, handCardB);
                return result;
            }
            else
            {
                return handCardA.CardType > handCardB.CardType
                    ? $"{handCardA.GroupType.ToString()} wins - {handCardA.CardType.GetDescription()}"
                    : $"{handCardB.GroupType.ToString()} wins - {handCardB.CardType.GetDescription()}";
            }
        }

        public CardTypes DistinguishCardTypes(List<Card> cards)
        {
            return Enum.GetValues(typeof(CardTypes)).Cast<CardTypes>()
                .LastOrDefault(x => _serviceAccessor(x).IsThisType(cards));
        }

        private ICardType GetCardTypeHandler(CardTypes cardType)
        {
            return _serviceAccessor(cardType);
        }
    }
}