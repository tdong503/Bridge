using System.Collections.Generic;

namespace Bridge.Model
{
    public class HandCard
    {
        public HandCard(GroupTypes groupType, List<Card> cards, CardTypes cardType)
        {
            GroupType = groupType;
            Cards = cards;
            CardType = cardType;
        }

        public GroupTypes GroupType { get; private set; }
        public List<Card> Cards { get; private set; }
        public CardTypes CardType { get; private set; }
    }
}