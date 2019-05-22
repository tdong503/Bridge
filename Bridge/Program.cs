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
            Console.WriteLine("Hello World!");
        }

        public ServiceProvider SetDI()
        {
            //set DI
            var serviceProvider = new ServiceCollection()
                .AddTransient<Compare>()
                .AddTransient<HighCard>()
                .AddTransient<Pair>()
                .AddTransient<TwoPair>()
                .AddTransient<ThreeOfAKind>()
                .AddTransient<Straight>()
                .AddTransient<Flush>()
                .AddTransient<FullHouse>()
                .AddTransient<FourOfAKind>()
                .AddTransient<StraightFlush>()
                .AddTransient(factory =>
                {
                    ICardType Accesor(CardTypes key)
                    {
                        switch (key)
                        {
                            case CardTypes.StraightFlush:
                                return factory.GetService<StraightFlush>();
                            case CardTypes.FourOfAKind:
                                return factory.GetService<FourOfAKind>();
                            case CardTypes.FullHouse:
                                return factory.GetService<FullHouse>();
                            case CardTypes.Flush:
                                return factory.GetService<Flush>();
                            case CardTypes.Straight:
                                return factory.GetService<Straight>();
                            case CardTypes.ThreeOfAKind:
                                return factory.GetService<ThreeOfAKind>();
                            case CardTypes.TwoPair:
                                return factory.GetService<TwoPair>();
                            case CardTypes.Pair:
                                return factory.GetService<Pair>();
                            default:
                                return factory.GetService<HighCard>();
                        }
                    }

                    return (Func<CardTypes, ICardType>) Accesor;
                })
                .BuildServiceProvider();
            return serviceProvider;
        }

        public string CompareHandCards(string handCardA, string handCardB)
        {
            var serviceProvider = SetDI();

            var cardListA = Common.ConvertCardStringToList(handCardA);
            var cardListB = Common.ConvertCardStringToList(handCardB);
            var bridge = serviceProvider.GetService<Compare>();

            var blackGroup = new HandCard(GroupTypes.Black, cardListA, bridge.DistinguishCardTypes(cardListA));
            var whiteGroup = new HandCard(GroupTypes.White, cardListB, bridge.DistinguishCardTypes(cardListB));

            return bridge.CompareWith(blackGroup, whiteGroup);
        }
    }
}