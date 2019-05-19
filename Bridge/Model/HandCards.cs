using System.Collections.Generic;

namespace Bridge.Model
{
    public class HandCards
    {
        public HandCards()
        {
            Cards = Common.SortCardsFall(Cards);
            CardType = CardTypes.Pair;
        }

        public GroupTypes GroupType { get; set; }
        public List<Card> Cards { get; set; }
        public CardTypes CardType { get; set; }
    }
}