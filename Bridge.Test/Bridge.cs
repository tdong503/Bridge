using System;
using System.Collections.Generic;
using Bridge.CardTypeHandler;
using Bridge.Model;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Xunit;

namespace Bridge.Test
{
    public class Bridge
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

        [Fact]
        public void GetCardTypeGivenCardList()
        {
            var handCardA = new List<Card>
            {
                new Card() {CardNumber = CardNums.Two, Color = CardColors.H},
                new Card() {CardNumber = CardNums.Three, Color = CardColors.D},
                new Card() {CardNumber = CardNums.Five, Color = CardColors.S},
                new Card() {CardNumber = CardNums.Nine, Color = CardColors.C},
                new Card() {CardNumber = CardNums.K, Color = CardColors.D}
            };

            var cardType = DistinguishCardType.Distinguish(handCardA);
            
            Assert.Equal(CardTypes.HighCard, cardType);
        }

        [Fact]
        public void GivenStraightFlushThenReturnTrue()
        {
            var handCard = new List<Card>
            {
                new Card() {CardNumber = CardNums.Two, Color = CardColors.H},
                new Card() {CardNumber = CardNums.Three, Color = CardColors.H},
                new Card() {CardNumber = CardNums.Four, Color = CardColors.H},
                new Card() {CardNumber = CardNums.Five, Color = CardColors.H},
                new Card() {CardNumber = CardNums.Six, Color = CardColors.H}
            };

            var isStraightFlush = new StraightFlush().IsThisType(handCard);
            
            Assert.True(isStraightFlush);
        }
    }
}