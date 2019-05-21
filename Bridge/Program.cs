using System;
using System.Collections.Generic;
using Bridge.CardTypeHandler;
using Bridge.Model;
using Microsoft.Extensions.DependencyInjection;

namespace Bridge
{
    public class Program
    {
        static void Main(string[] args)
        {
            //set DI
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IBridgeCore, BridgeCore>()
                .AddSingleton<Flush>()
                .AddSingleton<FourOfAKind>()
                .AddSingleton<StraightFlush>()
                .AddSingleton(factory =>
                {
                    ICardType Accesor(CardTypes key)
                    {
                        if (key == CardTypes.StraightFlush)
                        {
                            return factory.GetService<StraightFlush>();
                        }
                        else
                        {
                            return factory.GetService<FourOfAKind>();
                        }
                    }

                    return (Func<CardTypes, ICardType>) Accesor;
                })
                .BuildServiceProvider();
            
            //start

            var tt = serviceProvider.GetService<IBridgeCore>();
            var dd = tt.Test(CardTypes.FourOfAKind);
            Console.WriteLine("Hello World!");
        }

//        public string CompareHandCards(string handCardA, string handCardB)
//        {
//            var blackGroup = new HandCard(GroupTypes.Black, Common.ConvertCardStringToList(handCardA));
//            var whiteGroup = new HandCard(GroupTypes.White, Common.ConvertCardStringToList(handCardB));
//
//            return Bridge.CompareHandCards(blackGroup, whiteGroup);
//        }
    }
}