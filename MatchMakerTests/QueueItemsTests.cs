using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks.TierX;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests
{
    [TestClass]
    public class QueueItemsTests
    {
        [TestMethod]
        public void ShouldSortByTier()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem10A = CreateQueueItem(10, "Heavy");
            QueueItem queueItem10B = CreateQueueItem(10, "Heavy");
            QueueItem queueItem10C = CreateQueueItem(10, "Heavy");
            QueueItem queueItem09A = CreateQueueItem(9,"Heavy");
            QueueItem queueItem09B = CreateQueueItem(9,"Heavy");
            QueueItem queueItem09C = CreateQueueItem(9,"Heavy");
            QueueItem queueItem03A = CreateQueueItem(3,"Heavy");
            QueueItem queueItem03B = CreateQueueItem(3,"Heavy");
            QueueItem queueItem03C = CreateQueueItem(3,"Heavy");

            queueItems.Add(queueItem10A);
            queueItems.Add(queueItem10B);
            queueItems.Add(queueItem10C);
            queueItems.Add(queueItem09A);
            queueItems.Add(queueItem09B);
            queueItems.Add(queueItem09C);
            queueItems.Add(queueItem03A);
            queueItems.Add(queueItem03B);
            queueItems.Add(queueItem03C);

            // act
            QueueItems result = queueItems.ByTier(10);

            // assert
            result.Contains(queueItem10A).Should().Be(true);
            result.Contains(queueItem10B).Should().Be(true);
            result.Contains(queueItem10C).Should().Be(true);
            result.Contains(queueItem09A).Should().Be(false);
            result.Contains(queueItem09B).Should().Be(false);
            result.Contains(queueItem09C).Should().Be(false);
            result.Contains(queueItem03A).Should().Be(false);
            result.Contains(queueItem03B).Should().Be(false);
            result.Contains(queueItem03C).Should().Be(false);
        }

        [TestMethod]
        public void ShouldSortByTankType()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem10A = CreateQueueItem(10, "Heavy");
            QueueItem queueItem10B = CreateQueueItem(10, "Light");
            QueueItem queueItem10C = CreateQueueItem(10, "Medium");
            QueueItem queueItem09A = CreateQueueItem(9, "Heavy");
            QueueItem queueItem09B = CreateQueueItem(9, "Light");
            QueueItem queueItem09C = CreateQueueItem(9, "Medium");
            QueueItem queueItem03A = CreateQueueItem(3, "Heavy");
            QueueItem queueItem03B = CreateQueueItem(3, "Light");
            QueueItem queueItem03C = CreateQueueItem(3, "Medium");

            queueItems.Add(queueItem10A);
            queueItems.Add(queueItem10B);
            queueItems.Add(queueItem10C);
            queueItems.Add(queueItem09A);
            queueItems.Add(queueItem09B);
            queueItems.Add(queueItem09C);
            queueItems.Add(queueItem03A);
            queueItems.Add(queueItem03B);
            queueItems.Add(queueItem03C);

            // act
            QueueItems result = queueItems.ByTankType("Light");

            // assert
            result.Contains(queueItem10B).Should().Be(true);
            result.Contains(queueItem09B).Should().Be(true);
            result.Contains(queueItem03B).Should().Be(true);
            result.Contains(queueItem10A).Should().Be(false);
            result.Contains(queueItem10C).Should().Be(false);
            result.Contains(queueItem09A).Should().Be(false);
            result.Contains(queueItem09C).Should().Be(false);
            result.Contains(queueItem03A).Should().Be(false);
            result.Contains(queueItem03C).Should().Be(false);
        }

        [TestMethod]
        public void ShouldSortByTankType2()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem10A = CreateQueueItem(10, "Heavy");
            QueueItem queueItem10B = CreateQueueItem(10, "Light");
            QueueItem queueItem10C = CreateQueueItem(10, "Medium");
            QueueItem queueItem09A = CreateQueueItem(9, "Heavy");
            QueueItem queueItem09B = CreateQueueItem(9, "Light");
            QueueItem queueItem09C = CreateQueueItem(9, "Medium");
            QueueItem queueItem03A = CreateQueueItem(3, "Heavy");
            QueueItem queueItem03B = CreateQueueItem(3, "Light");
            QueueItem queueItem03C = CreateQueueItem(3, "Medium");

            queueItems.Add(queueItem10A);
            queueItems.Add(queueItem10B);
            queueItems.Add(queueItem10C);
            queueItems.Add(queueItem09A);
            queueItems.Add(queueItem09B);
            queueItems.Add(queueItem09C);
            queueItems.Add(queueItem03A);
            queueItems.Add(queueItem03B);
            queueItems.Add(queueItem03C);

            // act
            QueueItems result = queueItems.ByTankType("Light").ByTier(10);

            // assert
            result.Contains(queueItem10B).Should().Be(true);
            result.Contains(queueItem09B).Should().Be(false);
            result.Contains(queueItem03B).Should().Be(false);
            result.Contains(queueItem10A).Should().Be(false);
            result.Contains(queueItem10C).Should().Be(false);
            result.Contains(queueItem09A).Should().Be(false);
            result.Contains(queueItem09C).Should().Be(false);
            result.Contains(queueItem03A).Should().Be(false);
            result.Contains(queueItem03C).Should().Be(false);
        }

        [TestMethod]
        public void ShouldAddQueueItemToList()
        {
            // arrange
            QueueItem queueItem = CreateQueueItem(3, "Light");
            QueueItems queueItems = new QueueItems();

            // act
            queueItems.Add(queueItem);

            // assert
            queueItems.Contains(queueItem).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotFindQueueItemThatHasNotBeenAdded()
        {
            // arrange
            QueueItem queueItem = CreateQueueItem(3, "Light");
            QueueItems queueItems = new QueueItems();

            // act
            queueItems.Add(queueItem);

            // assert
            queueItems.Contains(CreateQueueItem(4, "Light")).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldBeFalseIfNotEnoughForBattle()
        {
            // arrange
            QueueItems queueItems = new QueueItems();
            AddGivenNumberOfTanksOfTier(13, 3, "Medium", queueItems);

            // assert
            queueItems.HasEnoughTanks(14).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldFailIfNotEnoughTanks()
        {
            // arrange
            QueueItems queueItems = new QueueItems();
            AddGivenNumberOfTanksOfTier(13, 3, "Medium", queueItems);

            // assert
            queueItems.HasEnoughTanks(14).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldSucceedIfEnoughTanks()
        {
            // arrange
            QueueItems queueItems = new QueueItems();
            AddGivenNumberOfTanksOfTier(14, 3, "Medium", queueItems);

            // act
            // assert
            queueItems.HasEnoughTanks(14).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldAddTanksToBattleInPairsToMaxCount()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem10A = CreateQueueItem(1, 10, "Heavy");
            QueueItem queueItem10B = CreateQueueItem(2, 10, "Light");
            QueueItem queueItem09A = CreateQueueItem(3, 9, "Heavy");
            QueueItem queueItem09B = CreateQueueItem(4, 9, "Light");
            QueueItem queueItem09C = CreateQueueItem(5, 9, "Medium");
            QueueItem queueItem03B = CreateQueueItem(6, 3, "Light");
            QueueItem queueItem03C = CreateQueueItem(7, 3, "Medium");

            queueItems.Add(queueItem10A);
            queueItems.Add(queueItem10B);
            queueItems.Add(queueItem09A);
            queueItems.Add(queueItem09B);
            queueItems.Add(queueItem09C);
            queueItems.Add(queueItem03B);
            queueItems.Add(queueItem03C);

            // act
            IBattle returnBattleReady = queueItems.AddTanksToBattleReady(new Battle(), 3);

            // assert
            returnBattleReady.ContainsPlayer(new Player(1)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(2)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(3)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(4)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(5)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(6)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(7)).Should().Be(false);
        }

        [TestMethod]
        public void ShouldAddTanksToBattleInPairsUnderMaxCount()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem10A = CreateQueueItem(1, 10, "Heavy");
            QueueItem queueItem10B = CreateQueueItem(2, 10, "Light");
            QueueItem queueItem09A = CreateQueueItem(3, 9, "Heavy");
            QueueItem queueItem09B = CreateQueueItem(4, 9, "Light");
            QueueItem queueItem03C = CreateQueueItem(7, 3, "Medium");

            queueItems.Add(queueItem10A);
            queueItems.Add(queueItem10B);
            queueItems.Add(queueItem09A);
            queueItems.Add(queueItem09B);
            queueItems.Add(queueItem03C);

            // act
            IBattle returnBattleReady = queueItems.AddTanksToBattleReady(new Battle(), 3);

            // assert
            returnBattleReady.ContainsPlayer(new Player(1)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(2)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(3)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(4)).Should().Be(true);
            returnBattleReady.ContainsPlayer(new Player(7)).Should().Be(false);
        }

        [Ignore]
        [TestMethod]
        public void ShouldRemoveTanksFromAvailableQueue()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem10A = CreateQueueItem(1, 10, "Heavy");
            QueueItem queueItem10B = CreateQueueItem(2, 10, "Light");
            QueueItem queueItem09A = CreateQueueItem(3, 9, "Heavy");
            QueueItem queueItem09B = CreateQueueItem(4, 9, "Light");
            QueueItem queueItem03C = CreateQueueItem(7, 3, "Medium");

            queueItems.Add(queueItem10A);
            queueItems.Add(queueItem10B);
            queueItems.Add(queueItem09A);
            queueItems.Add(queueItem09B);
            queueItems.Add(queueItem03C);

            // act
            IBattle returnBattleReady = queueItems.AddTanksToBattleReady(new Battle(), 3);

            // assert
            queueItems.Contains(queueItem10A).Should().BeFalse();
            queueItems.Contains(queueItem10B).Should().BeFalse();
            queueItems.Contains(queueItem09A).Should().BeFalse();
            queueItems.Contains(queueItem09B).Should().BeFalse();
            queueItems.Contains(queueItem03C).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldRemoveQueueItem()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem = new QueueItem(new Player(1), new Tank(1, "Light"));
            queueItems.Add(queueItem);

            // act
            bool success = queueItems.Remove(queueItem);

            // 
            success.Should().BeTrue();
            queueItems.Contains(queueItem).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnNullMatchPairObjectIfQueueItemsDoesNotHaveTwoElements()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Light"));
         //   queueItems.Add(queueItem01);

            // act
            IMatchPair matchPair = queueItems.GetMatchPair(queueItems); 

            // assert
            matchPair.Contains(queueItem01).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCreateMatchPair()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Light"));
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player(1), new Tank(1, "Light"));
            queueItems.Add(queueItem02);

            // act
            IMatchPair matchPair = queueItems.GetMatchPair(queueItems);

            // assert
            matchPair.Contains(queueItem01).Should().BeTrue();
            matchPair.Contains(queueItem02).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldRemoveQueueItemsFromPoolWhenCreatingMatchPair()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Light"));
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player(1), new Tank(1, "Light"));
            queueItems.Add(queueItem02);

            // act
            IMatchPair matchPair = queueItems.GetMatchPair(queueItems);

            // assert
            queueItems.Contains(queueItem01).Should().BeFalse();
            queueItems.Contains(queueItem02).Should().BeFalse();
            matchPair.Contains(queueItem01).Should().BeTrue();
            matchPair.Contains(queueItem02).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldFilterByRank()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem01 = new QueueItem(new Player(1), new E100());
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player(1), new Maus());
            queueItems.Add(queueItem02);

            QueueItem queueItem03 = new QueueItem(new Player(1), new Maus());
            queueItems.Add(queueItem03);

            QueueItem queueItem04 = new QueueItem(new Player(1), new T110E5());
            queueItems.Add(queueItem04);

            // act
           QueueItems items = queueItems.ByRank("Heavy");

            // assert
            items.Contains(queueItem01).Should().BeTrue();
            items.Contains(queueItem02).Should().BeTrue();
            items.Contains(queueItem03).Should().BeTrue();
            items.Contains(queueItem04).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldFilterByWinRate()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            Player player01 = new Player(1, 55);
            QueueItem queueItem01 = new QueueItem(player01, new E100());
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player(2, 47), new E100());
            queueItems.Add(queueItem02);

            QueueItem queueItem03 = new QueueItem(new Player(3, 49), new E100());
            queueItems.Add(queueItem03);

            Player player02 = new Player(4, 56);
            QueueItem queueItem04 = new QueueItem(player02, new E100());
            queueItems.Add(queueItem04);

            // act
            QueueItems items = queueItems.ByWinRate(4);

            // assert
            items.Contains(queueItem01).Should().BeTrue();
            items.Contains(queueItem04).Should().BeTrue();
            items.Contains(queueItem02).Should().BeFalse();
            items.Contains(queueItem03).Should().BeFalse();
        }

        private QueueItem CreateQueueItem(int tier, string tankType)
        {
            return CreateQueueItem(1,tier, tankType);
        }

        private QueueItem CreateQueueItem(int player, int tier, string tankType)
        {
            return new QueueItem(new Player(player), new Tank(tier, tankType));
        }

        private void AddGivenNumberOfTanksOfTier(int numberToAdd, int tier, string tankType, QueueItems queueItems)
        {
            for (int i = 0; i < numberToAdd; i++)
            {
                queueItems.Add(CreateQueueItem(tier, tankType));
            }
        }
    }
}
