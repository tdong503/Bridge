using System;
using Bridge.CardTypeHandler;
using Bridge.Model;

namespace Bridge
{
    public class BridgeCore : IBridgeCore
    {
        private readonly Func<CardTypes, ICardType> _serviceAccessor;

        public BridgeCore(Func<CardTypes, ICardType> serviceAccessor)
        {
            _serviceAccessor = serviceAccessor;
        }

        public ICardType Test(CardTypes cardType)
        {
            return _serviceAccessor(cardType);
        }
        
        public string CompareHandCards(HandCard blackGroup, HandCard whiteGroup)
        {
            throw new System.NotImplementedException();
        }
    }
}