﻿using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks.Tier01;
using MatchMaker.Data_Bags.Tanks.Tier02;
using MatchMaker.Data_Bags.Tanks.Tier09;
using MatchMaker.Data_Bags.Tanks.Tier10;
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
            Player player = ObjectBuider.CreatePlayer(1, 50d, 499);

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
            queueItem.HasPlayer(ObjectBuider.CreatePlayer(2, 50d, numBattles: 499)).Should().BeFalse();
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
        public void ShouldReturnTrueForSameWinRateByPlayer()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 499), new E100());
            Player player = ObjectBuider.CreatePlayer(2, 53, 499);

            queueItem.IsSameWinRateCategory(player).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForSameWinRateByPlayer()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 499), new E100());
            Player player = ObjectBuider.CreatePlayer(2, 38, 499);

            queueItem.IsSameWinRateCategory(player).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameWinRateByQueueItem()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 499), new E100());
            QueueItem queueItemOther = new QueueItem(ObjectBuider.CreatePlayer(2, 53, 499), new E100());

            queueItem.IsSameWinRateCategory(queueItemOther).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForNotSameWinRateByQueueItem()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 499), new E100());
            QueueItem queueItemOther = new QueueItem(ObjectBuider.CreatePlayer(2, 38, 499), new E100());

            queueItem.IsSameWinRateCategory(queueItemOther).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategoryByPlayer()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 3000), new E100());
            Player player = ObjectBuider.CreatePlayer(2, 53, 4000);

            queueItem.IsSameNumBattlesCategory(player).Should().BeTrue();
        }


        [TestMethod]
        public void ShouldReturnFalseForSameNumBattlesCategoryByPlayer()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 15000), new E100());
            Player player = ObjectBuider.CreatePlayer(2, 38, 1000);

            queueItem.IsSameNumBattlesCategory(player).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueForSameNumBattlesCategoryByQueueItem()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 800), new E100());
            QueueItem queueItemOther = new QueueItem(ObjectBuider.CreatePlayer(2, 53, 1500), new E100());

            queueItem.IsSameNumBattlesCategory(queueItemOther).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseForNotSameNumBattlesByQueueItem()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 50, 1788), new E100());
            QueueItem queueItemOther = new QueueItem(ObjectBuider.CreatePlayer(2, 38, 9000), new E100());

            queueItem.IsSameNumBattlesCategory(queueItemOther).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldValidateNextTierTankMin()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 1, 499), new PzKpfwIi());

            queueItem.IsNextTierTank(new M3Stewart()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldInValidateNextTierTank()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 1, 499), new M3Stewart());

            queueItem.IsNextTierTank(new M3Stewart()).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldValidateNextTierTankMax()
        {
            QueueItem queueItem = new QueueItem(ObjectBuider.CreatePlayer(1, 1, 499), new E75());

            queueItem.IsNextTierTank(new E100()).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnTrueIfInPlatoon()
        {
            QueueItem queueItem1 = new QueueItem(ObjectBuider.CreatePlayer(1, 1, 499), new E75());
            QueueItem queueItem2 = new QueueItem(ObjectBuider.CreatePlayer(2, 1, 499), new E75());
            
            queueItem1.AddPlatoonMate(queueItem2);

            queueItem1.IsInPlatoon().Should().BeTrue();
            queueItem2.IsInPlatoon().Should().BeTrue();
        }

        [TestMethod] 
        public void ShouldReturnFalseIfNotInPlatoon()
        {
            QueueItem queueItem1 = new QueueItem(ObjectBuider.CreatePlayer(1, 1, 499), new E75());

            queueItem1.IsInPlatoon().Should().BeFalse();
        }


        [TestMethod]
        public void ShouldReturnTrueIfNotInPlatoon()
        {
            QueueItem queueItem1 = new QueueItem(ObjectBuider.CreatePlayer(1, 1, 499), new E75());

            queueItem1.IsNotInPlatoon().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldGetMatchForPlatoonMate()
        {
            // arrange

            QueueItem queueItem1 = new QueueItem(ObjectBuider.CreatePlayer(1, 1, 499), new E75());
            QueueItem queueItem12 = new QueueItem(ObjectBuider.CreatePlayer(12, 1, 499), new E75());

            queueItem12.AddPlatoonMate(queueItem1);

            QueueItems queueItems = new QueueItems();

            QueueItem queueItemB = new QueueItem(ObjectBuider.CreatePlayer(2, 1, 499), new E75());
            queueItems.Add(queueItemB);
            // act

            IMatchPair matchPair = queueItem12.GetMatchForPlatoonMateTeamA(queueItems);

            // assert
            queueItem12.IsInPlatoon().Should().BeTrue();
            queueItem1.IsInPlatoon().Should().BeTrue();
            queueItemB.IsInPlatoon().Should().BeFalse();
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem12).Should().BeFalse();
            matchPair.Contains(queueItemB).Should().BeTrue();

        }

        [TestMethod]
        public void ShouldReturnFalseIfInPlatoon()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(ObjectBuider.CreatePlayer(1, 1, 499), new E75());
            QueueItem queueItem2 = new QueueItem(ObjectBuider.CreatePlayer(2, 1, 499), new E75());

            // act
            queueItem1.AddPlatoonMate(queueItem2);

            // assert
            queueItem1.IsNotInPlatoon().Should().BeFalse();
            queueItem2.IsNotInPlatoon().Should().BeFalse();
        }

        private static QueueItem CreateQueueItem(int tier)
        {
            return new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), ObjectBuider.CreateTank(tier, null, "Heavy"));
        }

        private static QueueItem CreateQueueItemOfTankType(string tankType, string rank)
        {
            return new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), ObjectBuider.CreateTank(1, tankType, rank));
        }
    }
}


