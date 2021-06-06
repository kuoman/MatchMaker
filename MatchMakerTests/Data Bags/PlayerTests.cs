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
            Player player = new Player((int) 2, (double) 50d, (int) 499);

            bool value = player.Equals(player);

            value.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldFindNotEqualsToo()
        {
            Player player = new Player((int) 2, (double) 50d, (int) 499);
            Player otherPlayer = new Player((int) 3, (double) 50d, (int) 499);

            bool value = otherPlayer.Equals(player);

            value.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldNotEquateNull()
        {
            Player player = new Player((int) 2, (double) 50d, (int) 499);

            bool value = player.Equals(null);

            value.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldEqualOnType()
        {
            Player player = new Player((int) 2, (double) 50d, (int) 499);

            player.Equals(new Player((int) 4, (double) 50d, (int) 499)).Should().BeFalse();
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
            Player player1 = new Player((int) 1, (double) 65.0d, (int) 499);

            // act
            bool result = player1.IsSameWinRateCategory(new Player((int) 2, (double) 75d, (int) 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory4()
        {
            // arrange
            Player player1 = new Player((int) 1, (double) 55.0d, (int) 499);

            // act
            bool result = player1.IsSameWinRateCategory(new Player((int) 4, (double) 59d, (int) 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory3()
        {
            // arrange
            Player player1 = new Player((int) 1, (double) 50.0d, (int) 499);

            // act
            bool result = player1.IsSameWinRateCategory(new Player((int) 5, (double) 54.9d, (int) 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory2()
        {
            // arrange
            Player player1 = new Player((int) 1, (double) 45.0d, (int) 499);

            // act
            bool result = player1.IsSameWinRateCategory(new Player((int) 5, (double) 49.999d, (int) 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory1()
        {
            // arrange
            Player player1 = new Player((int) 1, (double) 40, (int) 499);

            // act
            bool result = player1.IsSameWinRateCategory(new Player((int) 3, (double) 44.999d, (int) 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory0()
        {
            // arrange
            Player player1 = new Player(1, 40, 290);

            // act
            bool result = player1.IsSameNumBattlesCategory(new Player(2, 40, 2000));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory1()
        {
            // arrange
            Player player1 = new Player(1, 40, 2150);

            // act
            bool result = player1.IsSameNumBattlesCategory(new Player(3, 50, 5000));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory2()
        {
            // arrange
            Player player1 = new Player(1, 40, 5098);

            // act
            bool result = player1.IsSameNumBattlesCategory(new Player(3, 54, 10000));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory3()
        {
            // arrange
            Player player1 = new Player(1, 40, 10987);

            // act
            bool result = player1.IsSameNumBattlesCategory(new Player(3, 66, 15000));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory4()
        {
            // arrange
            Player player1 = new Player(1, 40, 15890);

            // act
            bool result = player1.IsSameNumBattlesCategory(new Player(3, 43, 15001));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForDifferentNumBattlesCategory()
        {
            // arrange
            Player player1 = new Player(1, 40, 290);

            // act
            bool result = player1.IsSameNumBattlesCategory(new Player(2, 40, 5000));

            // assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnFalseForNotSameWinRateCategory()
        {
            // arrange
            Player player1 = new Player((int) 1, (double) 45, (int) 499);

            // act
            bool result = player1.IsSameWinRateCategory(new Player((int) 3, (double) 23.3d, (int) 499));
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategoryFromPlayer()
        {
            // arrange
            Player player1 = new Player((int) 1, (double) 40, (int) 499);
            Player player2 = new Player((int) 1, (double) 43, (int) 499);

            // act
            bool result = player1.IsSameWinRateCategory(player2);

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForNotSameWinRateCategoryFromPlayer()
        {
            // arrange
            Player player1 = new Player((int) 1, (double) 45, (int) 499);
            Player player2 = new Player((int) 2, (double) 20.0d, (int) 499);

            // act
            bool result = player1.IsSameWinRateCategory(player2);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategoryFromPlayer()
        {
            // arrange
            Player player1 = new Player(1, 40, 5600);
            Player player2 = new Player(1, 43, 7800);

            // act
            bool result = player1.IsSameNumBattlesCategory(player2);

            // assert
            result.Should().BeTrue();
        }
    }
}

