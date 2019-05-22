using System;
using System.Collections.Generic;
using System.Linq;
using Bridge.CardTypeHandler;
using Bridge.Model;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Bridge.Test
{
    public class BridgeTests
    {
        [Theory]
        [InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "White wins - high card")]
        [InlineData("2H 4S 4C 2D 4H", "2S 8S AS QS 3S", "Black wins - full house")]
        [InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C KH", "Black wins - high card")]
        [InlineData("2H 3D 5S 9C KD", "2D 3H 5C 9S KH", "Tie - high card")]
        public void CompareHandCardsAndCheckOutput(string handCardA, string handCardB, string expectedResult)
        {
            var actual = new Program().CompareHandCards(handCardA, handCardB);
            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [InlineData("2H 3H 4H 5H 6H", CardTypes.StraightFlush)]
        [InlineData("JH JD JS JC 6H", CardTypes.FourOfAKind)]
        [InlineData("2H 3H 4H 5H AH", CardTypes.Flush)]
        [InlineData("2H 3H 4C 5D 6H", CardTypes.Straight)]
        [InlineData("3H 3D 3C 6D 6H", CardTypes.FullHouse)]
        [InlineData("QH QD QC 5S 6H", CardTypes.ThreeOfAKind)]
        [InlineData("3D 3H QH QC 6H", CardTypes.TwoPair)]
        [InlineData("3S 3H AC KH 6H", CardTypes.Pair)]
        [InlineData("2H QH 4D 10H AH", CardTypes.HighCard)]
        public void GetCardTypeGivenCardList(string handCard, CardTypes expectedResult)
        {
            var serviceProvider = new Program().SetDI();
            
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var cardType = serviceProvider.GetService<Compare>().DistinguishCardTypes(handCardFormatted);
            
            Assert.Equal(expectedResult, cardType);
        }

        [Fact]
        public void ConvertCardStringToListTest()
        {
            var cardList = Common.ConvertCardStringToList("4H 4D 5C 6S 6H");

            Assert.Equal( CardNums.Four, cardList[0].CardNumber);
            Assert.Equal( CardColors.H, cardList[0].Color);
            Assert.Equal( CardNums.Four, cardList[1].CardNumber);
            Assert.Equal( CardColors.D, cardList[1].Color);
            Assert.Equal( CardNums.Five, cardList[2].CardNumber);
            Assert.Equal( CardColors.C, cardList[2].Color);
            Assert.Equal( CardNums.Six, cardList[3].CardNumber);
            Assert.Equal( CardColors.S, cardList[3].Color);
            Assert.Equal( CardNums.Six, cardList[4].CardNumber);
            Assert.Equal( CardColors.H, cardList[4].Color);
        }
    }
}