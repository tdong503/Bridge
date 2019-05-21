using System.Collections.Generic;

namespace Bridge.Model
{
    public class HandCard
    {
        public HandCard(GroupTypes groupType, List<Card> cards)
        {
            GroupType = groupType;
            Cards = Common.SortCardsFall(cards);
            CardType = CardTypes.Pair;
        }

        public GroupTypes GroupType { get; private set; }
        public List<Card> Cards { get; private set; }
        public CardTypes CardType { get; private set; }
    }
}