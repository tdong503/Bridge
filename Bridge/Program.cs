using System;
using System.Collections.Generic;
using Bridge.Model;

namespace Bridge
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }

        public string CompareHandCards(string handCardA, string handCardB)
        {
            var blackGroup = new HandCards
            {
                GroupType = GroupTypes.Black,
                Cards = Common.ConvertCardStringArrToList(handCardA.Split(' '))
                
            };
            var whiteGroup = new HandCards
            {
                GroupType = GroupTypes.White,
                Cards = Common.ConvertCardStringArrToList(handCardB.Split(' '))
            };
            
            return Bridge.CompareHandCards(blackGroup, whiteGroup);
        }
    }
}