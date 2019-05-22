using Bridge.CardTypeHandler;
using Bridge.Model;
using Xunit;

namespace Bridge.Test
{
    public class CardTypeTest
    {
        [Theory]
        [InlineData("10H JH QH KH AH", true)]
        [InlineData("2H 2D 2C 2S 6H", false)]
        [InlineData("3C 3H 3D 5H 5D", false)]
        [InlineData("2H 3H 4H 5H 7H", false)]
        [InlineData("2H 3H 4C 5H 6D", false)]
        [InlineData("5D 5S 4H 5H 7H", false)]
        [InlineData("3D 3H JH 8H JS", false)]
        [InlineData("AH KH 6D AC 7D", false)]
        [InlineData("AH QC 8S 9D 10H", false)]
        public void GivenHandCardThenCheckIfStraightFlush(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new StraightFlush().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }

        [Theory]
        [InlineData("2H 3H 4H 5H 6H", "3D 4D 5D 7D 6D", "White wins - straight flush", CardTypes.StraightFlush)]
        [InlineData("10H JH QH KH AH", "3D 4D 5D 7D 6D", "Black wins - straight flush", CardTypes.StraightFlush)]
        [InlineData("10H JH QH KH AH", "10H JH QH KH AH", "Tie - straight flush", CardTypes.StraightFlush)]
        [InlineData("JD JH JC JS AH", "KD KH KS KC AD", "White wins - four of a kind", CardTypes.FourOfAKind)]
        [InlineData("KD KH KS KC AD", "JD JH JC JS AH", "Black wins - four of a kind", CardTypes.FourOfAKind)]
        [InlineData("10H 10D 10C JS AH", "KH KC KS 10S QH", "White wins - full house", CardTypes.FullHouse)]
        [InlineData("KH KC KS 10S QH", "10H 10D 10C JS AH", "Black wins - full house", CardTypes.FullHouse)]
        [InlineData("10H JH 8H KH AH", "10D JD 3D KD AD", "Black wins - flush", CardTypes.Flush)]
        [InlineData("10D JD 3D KD AD", "10H JH 8H KH AH", "White wins - flush", CardTypes.Flush)]
        [InlineData("10D JD 3D KD AD", "10H JH 3H KH AH", "Tie - flush", CardTypes.Flush)]        
        [InlineData("10D JS QH KC AH", "4D 5C 7S 6H 3H", "Black wins - straight", CardTypes.Straight)]
        [InlineData("4D 5C 7S 6H 3H", "10D JS QH KC AH", "White wins - straight", CardTypes.Straight)]
        [InlineData("10S JH QC KH AH", "10D JC QH AC KD", "Tie - straight", CardTypes.Straight)]
        [InlineData("9H 9D 9C KH AH", "8H 8C 8D 2H AH", "Black wins - three of a kind", CardTypes.ThreeOfAKind)]
        [InlineData("8H 8C 8D 7S AH", "10H 10D 10C 6D AH", "White wins - three of a kind", CardTypes.ThreeOfAKind)]
        [InlineData("QH JH QD JS 4H", "8H 9D 8D 7S 9H", "Black wins - two pair", CardTypes.TwoPair)]
        [InlineData("2H 2D JS JC AD", "4H 7S 4C AS AH", "White wins - two pair", CardTypes.TwoPair)]
        [InlineData("10C QC QD 10S 4D", "10H 10D QH QS 3S", "Black wins - two pair", CardTypes.TwoPair)]
        [InlineData("10C QC QD 10S 3D", "10H 10D QH QS 3S", "Tie - two pair", CardTypes.TwoPair)]
        [InlineData("10H 10D QH 2D 7C", "8D JH QH 8S AH", "Black wins - pair", CardTypes.Pair)]
        [InlineData("2H 2C 4S 7D KS", "AH JH QH KH AC", "White wins - pair", CardTypes.Pair)]
        [InlineData("10H 10D QH 2D 7C", "10S 10C AS 2C 7D", "White wins - pair", CardTypes.Pair)]
        [InlineData("10H 10D QH 2D 7C", "10S 10C QS 2C 7D", "Tie - pair", CardTypes.Pair)]
        [InlineData("2H 5H 7H KH AD", "10H JH QH KH 8C", "Black wins - high card", CardTypes.HighCard)]
        [InlineData("10H JH 3D KH AH", "10H JH 9C KH AH", "White wins - high card", CardTypes.HighCard)]
        [InlineData("10H JH 3D KH AH", "10H JH 3C KH AH", "Tie - high card", CardTypes.HighCard)]
        public void GivenHandCardsThenCompareStraightFlush(string handCardA, string handCardB, string expectedResult, CardTypes cardType)
        {
            var blackGroup = new HandCard(GroupTypes.Black, Common.ConvertCardStringToList(handCardA), cardType);
            var whiteGroup = new HandCard(GroupTypes.White, Common.ConvertCardStringToList(handCardB), cardType);

            var compareResult = CardTypeBase.CompareMultipleCardNumber(blackGroup, whiteGroup);

            Assert.Equal(expectedResult, compareResult);
        }
        
        [Theory]
        [InlineData("10H JH QH KH AH", false)]
        [InlineData("2H 2D 2C 2S 6H", true)]
        [InlineData("3C 3H 3D 5H 5D", false)]
        [InlineData("2H 3H 4H 5H 7H", false)]
        [InlineData("2H 3H 4C 5H 6D", false)]
        [InlineData("5D 5S 4H 5H 7H", false)]
        [InlineData("3D 3H JH 8H JS", false)]
        [InlineData("AH KH 6D AC 7D", false)]
        [InlineData("AH QC 8S 9D 10H", false)]
        public void GivenHandCardThenCheckIfFourOfAKind(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new FourOfAKind().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }
        
        [Theory]
        [InlineData("10H JH QH KH AH", false)]
        [InlineData("2H 2D 2C 2S 6H", false)]
        [InlineData("3C 3H 3D 5H 5D", true)]
        [InlineData("2H 3H 4H 5H 7H", false)]
        [InlineData("2H 3H 4C 5H 6D", false)]
        [InlineData("5D 5S 4H 5H 7H", false)]
        [InlineData("3D 3H JH 8H JS", false)]
        [InlineData("AH KH 6D AC 7D", false)]
        [InlineData("AH QC 8S 9D 10H", false)]
        public void GivenHandCardThenCheckIfFullHouse(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new FullHouse().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }
        
        [Theory]
        [InlineData("10H JH QH KH AH", false)]
        [InlineData("2H 2D 2C 2S 6H", false)]
        [InlineData("3C 3H 3D 5H 5D", false)]
        [InlineData("2H 3H 4H 5H 7H", true)]
        [InlineData("2H 3H 4C 5H 6D", false)]
        [InlineData("5D 5S 4H 5H 7H", false)]
        [InlineData("3D 3H JH 8H JS", false)]
        [InlineData("AH KH 6D AC 7D", false)]
        [InlineData("AH QC 8S 9D 10H", false)]
        public void GivenHandCardThenCheckIfFlush(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new Flush().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }
        
        [Theory]
        [InlineData("10H JH QH KH AH", false)]
        [InlineData("2H 2D 2C 2S 6H", false)]
        [InlineData("3C 3H 3D 5H 5D", false)]
        [InlineData("2H 3H 4H 5H 7H", false)]
        [InlineData("2H 3H 4C 5H 6D", true)]
        [InlineData("5D 5S 4H 5H 7H", false)]
        [InlineData("3D 3H JH 8H JS", false)]
        [InlineData("AH KH 6D AC 7D", false)]
        [InlineData("AH QC 8S 9D 10H", false)]
        public void GivenHandCardThenCheckIfStraight(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new Straight().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }
        
        [Theory]
        [InlineData("10H JH QH KH AH", false)]
        [InlineData("2H 2D 2C 2S 6H", false)]
        [InlineData("3C 3H 3D 5H 5D", false)]
        [InlineData("2H 3H 4H 5H 7H", false)]
        [InlineData("2H 3H 4C 5H 6D", false)]
        [InlineData("5D 5S 4H 5H 7H", true)]
        [InlineData("3D 3H JH 8H JS", false)]
        [InlineData("AH KH 6D AC 7D", false)]
        [InlineData("AH QC 8S 9D 10H", false)]
        public void GivenHandCardThenCheckIfThreeOfAKind(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new ThreeOfAKind().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }
        
        [Theory]
        [InlineData("10H JH QH KH AH", false)]
        [InlineData("2H 2D 2C 2S 6H", false)]
        [InlineData("3C 3H 3D 5H 5D", false)]
        [InlineData("2H 3H 4H 5H 7H", false)]
        [InlineData("2H 3H 4C 5H 6D", false)]
        [InlineData("5D 5S 4H 5H 7H", false)]
        [InlineData("3D 3H JH 8H JS", true)]
        [InlineData("AH KH 6D AC 7D", false)]
        [InlineData("AH QC 8S 9D 10H", false)]
        public void GivenHandCardThenCheckIfTwoPair(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new TwoPair().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }
        
        [Theory]
        [InlineData("10H JH QH KH AH", false)]
        [InlineData("2H 2D 2C 2S 6H", false)]
        [InlineData("3C 3H 3D 5H 5D", false)]
        [InlineData("2H 3H 4H 5H 7H", false)]
        [InlineData("2H 3H 4C 5H 6D", false)]
        [InlineData("5D 5S 4H 5H 7H", false)]
        [InlineData("3D 3H JH 8H JS", false)]
        [InlineData("AH KH 6D AC 7D", true)]
        [InlineData("AH QC 8S 9D 10H", false)]
        public void GivenHandCardThenCheckIfPair(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new Pair().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }
        
        [Theory]
        [InlineData("10H JH QH KH AH", false)]
        [InlineData("2H 2D 2C 2S 6H", false)]
        [InlineData("3C 3H 3D 5H 5D", false)]
        [InlineData("2H 3H 4H 5H 7H", false)]
        [InlineData("2H 3H 4C 5H 6D", false)]
        [InlineData("5D 5S 4H 5H 7H", false)]
        [InlineData("3D 3H JH 8H JS", false)]
        [InlineData("AH KH 6D AC 7D", false)]
        [InlineData("AH QC 8S 9D 10H", true)]
        public void GivenHandCardThenCheckIfHighCard(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new HighCard().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }
    }
}