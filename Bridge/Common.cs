using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using Bridge.CardTypeHandler;
using Bridge.Model;

namespace Bridge
{
    public static class Common
    {
        public static List<Card> ConvertCardStringToList(string cardString)
        {
            var cardStringArr = cardString.Split(' ');
            
            var cardList = new List<Card>();
            foreach (var card in cardStringArr)
            {
                cardList.Add(new Card()
                {
                    CardNumber = (CardNums) Enum.Parse(typeof(CardNums), card.Substring(0, card.Length - 1)),
                    Color = (CardColors) Enum.Parse(typeof(CardColors), card.Substring(card.Length - 1))
                });
            }

            return cardList;
        }

        public static bool IsStraight(List<Card> cards)
        {
            cards = SortCardsFall(cards);
            return cards.First().CardNumber - 4 == cards.Last().CardNumber && cards.GroupBy(a => a.CardNumber).ToList().Count == cards.Count;
        }

        public static bool IsFlush(List<Card> cards)
        {
            return cards.Count == cards.Count(c => c.Color == cards.First().Color);
        }

        public static string GetDescription(this Enum enumName)
        {
            var description = string.Empty;
            var fieldInfo = enumName.GetType().GetField(enumName.ToString());
            var attributes = fieldInfo.GetCustomAttribute<DescriptionAttribute>();
            description = attributes != null ? attributes.Description : enumName.ToString();
            return description;
        }

        private static List<Card> SortCardsFall(IEnumerable<Card> cards)
        {
            return cards.OrderByDescending(o => o.CardNumber).ToList();
        }
    }
}