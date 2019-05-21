using Bridge.CardTypeHandler;
using Bridge.Model;

namespace Bridge
{
    public interface IBridgeCore
    {
        ICardType Test(CardTypes cardType);
    }
}