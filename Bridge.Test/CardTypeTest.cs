using Bridge.CardTypeHandler;
using Bridge.Model;
using Xunit;

namespace Bridge.Test
{
    public class CardTypeTest
    {
        [Theory]
        [InlineData("2H 3H 4H 5H 6H", true)]
        [InlineData("10H JH QH KH AH", true)]
        [InlineData("2H 3H 4H 5H AH", false)]
        [InlineData("2H 3H 4H 5H 6D", false)]
        public void GivenHandCardThenCheckIfStraightFlush(string handCard, bool expectedResult)
        {
            var handCardFormatted = Common.ConvertCardStringToList(handCard);

            var isStraightFlush = new StraightFlush().IsThisType(handCardFormatted);

            Assert.True(isStraightFlush == expectedResult);
        }

        [Theory]
        [InlineData("2H 3H 4H 5H 6H", "3D 4D 5D 7D 6D", CompareResults.Lose)]
        [InlineData("10H JH QH KH AH", "3D 4D 5D 7D 6D", CompareResults.Win)]
        [InlineData("10H JH QH KH AH", "10H JH QH KH AH", CompareResults.Tie)]
        public void GivenHandCardsThenCompareStraightFlush(string handCardA, string handCardB,
            CompareResults expectedResult)
        {
            var blackGroup = new HandCard(GroupTypes.Black, Common.ConvertCardStringToList(handCardA));
            var whiteGroup = new HandCard(GroupTypes.White, Common.ConvertCardStringToList(handCardB));

            var compareResult = new StraightFlush().Compare(blackGroup, whiteGroup);

            Assert.Equal(expectedResult, compareResult);
        }
    }
}