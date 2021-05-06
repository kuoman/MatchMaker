using FluentAssertions;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks.TierX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class QueueItemTests
    {
        [TestMethod]
        public void ShouldFindPlayer()
        {
            // arrange
            Player player = new Player(1);

            QueueItem queueItem = CreateQueueItem(1);

            // act // assert
            queueItem.HasPlayer(player).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotFindPlayer()
        {
            // arrange
            QueueItem queueItem = CreateQueueItem(1);

            // act // assert
            queueItem.HasPlayer(new Player(2)).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfCorrectTier()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItem(5);

            // act // assert
            queueItem.IsTier(5).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTier()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItem(5);

            // act // assert
            queueItem.IsTier(4).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfCorrectTankType()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Heavy", "Light");

            // act // assert
            queueItem.IsTankType("Heavy").Should().BeTrue();
        }


        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTankType()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Light", "Light");

            // act // assert
            queueItem.IsTankType("Heavy").Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfCorrectTankRank()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Heavy", "Heavy");

            // act // assert
            queueItem.IsRank("Heavy").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTankRank()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Heavy", "Heavy");

            // act // assert
            queueItem.IsRank("Light").Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRate()
        {
            QueueItem queueItem = new QueueItem(new Player(1, 50), new E100());


            queueItem.IsSameWinRateCategory(3).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForSameWinRate()
        {
            QueueItem queueItem = new QueueItem(new Player(1, 50), new E100());
            Player player = new Player(2, 38);

            queueItem.IsSameWinRateCategory(1).Should().BeFalse();
        }

        private static QueueItem CreateQueueItem(int tier)
        {
            return new QueueItem(new Player(1), new Tank(tier, null));
        }

        private static QueueItem CreateQueueItemOfTankType(string tankType, string rank)
        {
            return new QueueItem(new Player(1), new Tank(1, tankType, rank));
        }

    }
}


