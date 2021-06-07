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
            Player player = ObjectBuider.CreatePlayer(2, 50d, 499);

            bool value = player.Equals(player);

            value.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldFindNotEqualsToo()
        {
            Player player = ObjectBuider.CreatePlayer(2, 50d, 499);
            Player otherPlayer = ObjectBuider.CreatePlayer(3, 50d, 499);

            bool value = otherPlayer.Equals(player);

            value.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldNotEquateNull()
        {
            Player player = ObjectBuider.CreatePlayer(2, 50d, 499);

            bool value = player.Equals(null);

            value.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldEqualOnType()
        {
            Player player = ObjectBuider.CreatePlayer(2, 50d, 499);

            player.Equals(ObjectBuider.CreatePlayer(4, 50d, 499)).Should().BeFalse();
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
            Player player1 = ObjectBuider.CreatePlayer(1, 65.0d, 499);

            // act
            bool result = player1.IsSameWinRateCategory(ObjectBuider.CreatePlayer(2, 75d, 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory4()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 55.0d, 499);

            // act
            bool result = player1.IsSameWinRateCategory(ObjectBuider.CreatePlayer(4, 59d, 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory3()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 50.0d, 499);

            // act
            bool result = player1.IsSameWinRateCategory(ObjectBuider.CreatePlayer(5, 54.9d, 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory2()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 45.0d, 499);

            // act
            bool result = player1.IsSameWinRateCategory(ObjectBuider.CreatePlayer(5, 49.999d, 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategory1()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer( 1, 40,  499);

            // act
            bool result = player1.IsSameWinRateCategory(ObjectBuider.CreatePlayer(3, 44.999d, 499));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory0()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 40, 290);

            // act
            bool result = player1.IsSameNumBattlesCategory(ObjectBuider.CreatePlayer(2, 40, 2000));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory1()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 40, 2150);

            // act
            bool result = player1.IsSameNumBattlesCategory(ObjectBuider.CreatePlayer(3, 50, 5000));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory2()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 40, 5098);

            // act
            bool result = player1.IsSameNumBattlesCategory(ObjectBuider.CreatePlayer(3, 54, 10000));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory3()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 40, 10987);

            // act
            bool result = player1.IsSameNumBattlesCategory(ObjectBuider.CreatePlayer(3, 66, 15000));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategory4()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 40, 15890);

            // act
            bool result = player1.IsSameNumBattlesCategory(ObjectBuider.CreatePlayer(3, 43, 15001));

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForDifferentNumBattlesCategory()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 40, 290);

            // act
            bool result = player1.IsSameNumBattlesCategory(ObjectBuider.CreatePlayer(2, 40, 5000));

            // assert
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnFalseForNotSameWinRateCategory()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 45, 499);

            // act
            bool result = player1.IsSameWinRateCategory(ObjectBuider.CreatePlayer(3, 23.3d, 499));
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateCategoryFromPlayer()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 40, 499);
            Player player2 = ObjectBuider.CreatePlayer(1, 43, 499);

            // act
            bool result = player1.IsSameWinRateCategory(player2);

            // assert
            result.Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForNotSameWinRateCategoryFromPlayer()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 45, 499);
            Player player2 = ObjectBuider.CreatePlayer(2, 20.0d, 499);

            // act
            bool result = player1.IsSameWinRateCategory(player2);
            result.Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategoryFromPlayer()
        {
            // arrange
            Player player1 = ObjectBuider.CreatePlayer(1, 40, 5600);
            Player player2 = ObjectBuider.CreatePlayer(1, 43, 7800);

            // act
            bool result = player1.IsSameNumBattlesCategory(player2);

            // assert
            result.Should().BeTrue();
        }
    }
}

