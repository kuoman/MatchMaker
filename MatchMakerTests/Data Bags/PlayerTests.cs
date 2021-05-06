using FluentAssertions;
using MatchMaker.Data_Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class PlayerTests
    {
        [TestMethod]
        public void ShouldEquatePlayerCorrectly()
        {
            Player player = new Player(2);

            bool value = player.Equals(player);

            value.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldFindNotEqualsToo()
        {
            Player player = new Player(2);
            Player otherPlayer = new Player(3);

            bool value = otherPlayer.Equals(player);

            value.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldNotEquateNull()
        {
            Player player = new Player(2);

            bool value = player.Equals(null);

            value.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldEqualOnType()
        {
            Player player = new Player(2);

            player.Equals(new Player(4)).Should().BeFalse();
        }

        // 60+  - high
        // 55   - above average
        // 50   - average
        // 45   - below average
        // 40-  - low

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory5()
        {
            // arrange
            Player player1 = new Player(1, 65.0d);

            // act
            bool result = player1.IsSameWinRateCategory(5);

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory4()
        {
            // arrange
            Player player1 = new Player(1, 55.0d);

            // act
            bool result = player1.IsSameWinRateCategory(4);

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory3()
        {
            // arrange
            Player player1 = new Player(1, 50.0d);

            // act
            bool result = player1.IsSameWinRateCategory(3);

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory2()
        {
            // arrange
            Player player1 = new Player(1, 45.0d);

            // act
            bool result = player1.IsSameWinRateCategory(2);

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory1()
        {
            // arrange
            Player player1 = new Player(1, 40);

            // act
            bool result = player1.IsSameWinRateCategory(1);

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForNotSameWinRateCategory()
        {
            // arrange
            Player player1 = new Player(1, 45);
            Player player2 = new Player(2, 20.0d);

            // act
            bool result = player1.IsSameWinRateCategory(5);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategoryFromPlayer()
        {
            // arrange
            Player player1 = new Player(1, 40);
            Player player2 = new Player(1, 43);

            // act
            bool result = player1.IsSameWinRateCategory(player2);

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForNotSameWinRateCategoryFromPlayer()
        {
            // arrange
            Player player1 = new Player(1, 45);
            Player player2 = new Player(2, 20.0d);

            // act
            bool result = player1.IsSameWinRateCategory(player2);
            result.Should().BeFalse();
        }
    }
}

