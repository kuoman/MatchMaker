using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
using MatchMaker.Data_Bags.Tanks.Tier10;
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
        public void ShouldSortByTierByTank()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem10A = CreateQueueItem(10, "Heavy");
            QueueItem queueItem10B = CreateQueueItem(10, "Heavy");
            QueueItem queueItem10C = CreateQueueItem(10, "Heavy");
            QueueItem queueItem09A = CreateQueueItem(9, "Heavy");
            QueueItem queueItem09B = CreateQueueItem(9, "Heavy");
            QueueItem queueItem09C = CreateQueueItem(9, "Heavy");
            QueueItem queueItem03A = CreateQueueItem(3, "Heavy");
            QueueItem queueItem03B = CreateQueueItem(3, "Heavy");
            QueueItem queueItem03C = CreateQueueItem(3, "Heavy");

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
            QueueItems result = queueItems.ByTier(new Maus());

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
        public void ShouldSortByTierByQueueItem()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem10A = CreateQueueItem(10, "Heavy");
            QueueItem queueItem10B = CreateQueueItem(10, "Heavy");
            QueueItem queueItem10C = CreateQueueItem(10, "Heavy");
            QueueItem queueItem09A = CreateQueueItem(9, "Heavy");
            QueueItem queueItem09B = CreateQueueItem(9, "Heavy");
            QueueItem queueItem09C = CreateQueueItem(9, "Heavy");
            QueueItem queueItem03A = CreateQueueItem(3, "Heavy");
            QueueItem queueItem03B = CreateQueueItem(3, "Heavy");
            QueueItem queueItem03C = CreateQueueItem(3, "Heavy");

            queueItems.Add(queueItem10A);
            queueItems.Add(queueItem10B);
            queueItems.Add(queueItem10C);
            queueItems.Add(queueItem09A);
            queueItems.Add(queueItem09B);
            queueItems.Add(queueItem09C);
            queueItems.Add(queueItem03A);
            queueItems.Add(queueItem03B);
            queueItems.Add(queueItem03C);

            QueueItem testSimilar = CreateQueueItem(10, "Heavy");

            // act
            QueueItems result = queueItems.ByTier(testSimilar);


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
        public void ShouldSortByTankTypeByTank()
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
            QueueItems result = queueItems.ByTankType(new Sheridan());

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
        public void ShouldSortByTankTypeByQueueItem()
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

            QueueItem testSimilar = CreateQueueItem(10, "Light");

            // act
            QueueItems result = queueItems.ByTankType(testSimilar);

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
        public void ShouldReturnNullMatchPairObjectIfQueueItemsDoesNotHaveAnyElements()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Light"));

            // act
            IMatchPair matchPair = queueItems.GetMatchPair(queueItems, queueItem01); 

            // assert
            matchPair.Contains(queueItem01).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCreateMatchPair()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Light"));

            QueueItem queueItem02 = new QueueItem(new Player(1), new Tank(1, "Light"));
            queueItems.Add(queueItem02);

            // act
            IMatchPair matchPair = queueItems.GetMatchPair(queueItems, queueItem01);

            // assert
            matchPair.Contains(queueItem01).Should().BeTrue();
            matchPair.Contains(queueItem02).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldHandleOneQueueItemThatHasNotBeenCleanedUpRight()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem01 = new QueueItem(new Player(1), new Tank(1, "Light"));
            queueItems.Add(queueItem01);

            // act
            IMatchPair matchPair = queueItems.GetMatchPair(queueItems, queueItem01);

            // assert
            queueItems.Contains(queueItem01).Should().BeTrue();
            matchPair.Contains(queueItem01).Should().BeFalse();
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
            IMatchPair matchPair = queueItems.GetMatchPair(queueItems, queueItem01);

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
        public void ShouldFilterByRankByQueueItem()
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

            QueueItem testSimilar = new QueueItem(new Player(1), new Maus());

            // act
            QueueItems items = queueItems.ByRank(testSimilar);

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

        [TestMethod]
        public void ShouldFilterByWinRateByQueueItem()
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

            Player playerX = new Player(1, 55);
            QueueItem queueItemX = new QueueItem(playerX, new E100());

            // act
            QueueItems items = queueItems.ByWinRate(queueItemX);

            // assert
            items.Contains(queueItem01).Should().BeTrue();
            items.Contains(queueItem04).Should().BeTrue();
            items.Contains(queueItem02).Should().BeFalse();
            items.Contains(queueItem03).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldFilterByNumBattlesCategoryByQueueItem()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            Player player01 = new Player(1, 47, 9000);
            QueueItem queueItem01 = new QueueItem(player01, new E100());
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player(2, 47,17890), new E100());
            queueItems.Add(queueItem02);

            QueueItem queueItem03 = new QueueItem(new Player(3, 49, 110000), new E100());
            queueItems.Add(queueItem03);

            Player player02 = new Player(4, 47, 8000);
            QueueItem queueItem04 = new QueueItem(player02, new E100());
            queueItems.Add(queueItem04);

            Player playerX = new Player(1, 47, 7800);
            QueueItem queueItemX = new QueueItem(playerX, new E100());

            // act
            QueueItems items = queueItems.ByNumBattles(queueItemX);

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
