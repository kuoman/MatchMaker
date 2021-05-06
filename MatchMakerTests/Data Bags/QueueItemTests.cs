﻿using FluentAssertions;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks.TierIX;
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
        public void ShouldReturnTrueIfCorrectTierByTank()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItem(9);

            // act // assert
            queueItem.IsTier(new E75()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTierByTank()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItem(9);

            // act // assert
            queueItem.IsTier(new E100()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfCorrectTierByQueueItem()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItem(9);
            QueueItem secondQueueItem = CreateQueueItem(9);

            // act // assert
            queueItem.IsTier(secondQueueItem).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTierByQueueItem()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItem(9);

            QueueItem secondQueueItem = CreateQueueItem(3);

            // act // assert
            queueItem.IsTier(secondQueueItem).Should().BeFalse();
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
        public void ShouldReturnTrueIfCorrectTankTypeByTank()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Heavy", "Light");

            // act // assert
            queueItem.IsTankType(new E100()).Should().BeTrue();
        }


        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTankTypeByTank()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Light", "Light");

            // act // assert
            queueItem.IsTankType(new E75()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfCorrectTankTypeByQueueItem()
        {
            // arrange 
            QueueItem queueItem1 = CreateQueueItemOfTankType("Heavy", "Light");
            QueueItem queueItem2 = CreateQueueItemOfTankType("Heavy", "Light");

            // act // assert
            queueItem1.IsTankType(queueItem2).Should().BeTrue();
        }


        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTankTypeByQueueItem()
        {
            // arrange 
            QueueItem queueItem1 = CreateQueueItemOfTankType("Heavy", "Light");
            QueueItem queueItem2 = CreateQueueItemOfTankType("Light", "Light");

            // act // assert
            queueItem1.IsTankType(queueItem2).Should().BeFalse();
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
        public void ShouldReturnTrueIfCorrectTankRankByTank()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Heavy", "Heavy");

            // act // assert
            queueItem.IsRank(new Maus()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTankRankByTank()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Heavy", "Heavy");

            // act // assert
            queueItem.IsRank(new Leopard1()).Should().BeFalse();
        }


        [TestMethod]
        public void ShouldReturnTrueIfCorrectTankRankByQueueItem()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Heavy", "Heavy");
            QueueItem queueItemOther = CreateQueueItemOfTankType("Heavy", "Heavy");

            // act // assert
            queueItem.IsRank(queueItemOther).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTankRankByQueueItem()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Heavy", "Heavy");
            QueueItem queueItemOther = CreateQueueItemOfTankType("Heavy", "Light");

            // act // assert
            queueItem.IsRank(queueItemOther).Should().BeFalse();
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

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateByPlayer()
        {
            QueueItem queueItem = new QueueItem(new Player(1, 50), new E100());
            Player player = new Player(2, 53);

            queueItem.IsSameWinRateCategory(player).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForSameWinRateByPlayer()
        {
            QueueItem queueItem = new QueueItem(new Player(1, 50), new E100());
            Player player = new Player(2, 38);

            queueItem.IsSameWinRateCategory(player).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateByQueueItem()
        {
            QueueItem queueItem = new QueueItem(new Player(1, 50), new E100()); 
            QueueItem queueItemOther = new QueueItem(new Player(2, 53), new E100());

            queueItem.IsSameWinRateCategory(queueItemOther).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForSameWinRateByQueueItem()
        {
            QueueItem queueItem = new QueueItem(new Player(1, 50), new E100());
            QueueItem queueItemOther = new QueueItem(new Player(2, 38), new E100());

            queueItem.IsSameWinRateCategory(queueItemOther).Should().BeFalse();
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


