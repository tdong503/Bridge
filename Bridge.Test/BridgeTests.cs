using System;
using System.Collections.Generic;
using System.Linq;
using Bridge.CardTypeHandler;
using Bridge.Model;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Bridge.Test
{
    public class BridgeTests
    {
        [Theory]
        [InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C AH", "White wins - high card: Ace")]
        [InlineData("2H 4S 4C 2D 4H", "2S 8S AS QS 3S", "Black wins - full house")]
        [InlineData("2H 3D 5S 9C KD", "2C 3H 4S 8C KH", "Black wins - high card: 9")]
        [InlineData("2H 3D 5S 9C KD", "2D 3H 5C 9S KH", "Tie")]
        public void CompareHandCardsAndCheckOutput(string handCardA, string handCardB, string expectedResult)
        {
            var actual = new Program().CompareHandCards(handCardA, handCardB);
            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [InlineData("2H 3H 4H 5H 6H", CardTypes.StraightFlush)]
        public void GetCardTypeGivenCardList(string handCard, CardTypes expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var cardType = DistinguishCardType.Distinguish(handCardFormatted);
            
            Assert.Equal(expectedResult, cardType);
        }

        [Fact]
        public void Test()
        {
            var tt = Common.ConvertCardStringToList("4H 4D 5C 6S 6H");

            var ttGroup = tt.GroupBy(a => a.CardNumber).ToList();
            
            var cardNumA = ttGroup.Any(w => w.Count() == 2) && ttGroup.Count == 3;
            
            Assert.True(cardNumA);
        }
    }
}