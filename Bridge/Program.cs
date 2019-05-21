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
            var blackGroup = new HandCard(GroupTypes.Black, Common.ConvertCardStringToList(handCardA));
            var whiteGroup = new HandCard(GroupTypes.White, Common.ConvertCardStringToList(handCardB));

            return Bridge.CompareHandCards(blackGroup, whiteGroup);
        }
    }
}