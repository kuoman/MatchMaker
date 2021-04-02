using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SameTierTests
    {
        [TestMethod]
        public void ShouldCreateBattleReadyWith14QueueItemsOfSameTier()
        {
            // arrange
            SameTier matchingStrategy = new SameTier(5);

            QueueItems queueItems = new QueueItems();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(CreateQueueItem(5));
            }

            // act
            BattleReady battleReady = (BattleReady)matchingStrategy.CreateBattle(queueItems);

            // assert
            battleReady.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldCreateBattleReadyThatIsReadyToFight()
        {
            // arrange
            SameTier strategy = new SameTier(5);

            QueueItems queueItems = new QueueItems();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(CreateQueueItem(1));
                queueItems.Add(CreateQueueItem(5));
            }

            IBattle battleReady = strategy.CreateBattle(queueItems);

            // act // arrange
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateNotReadyBattleIfNotEnoughTanks()
        {
            // arrange
            SameTier strategy = new SameTier(5);

            QueueItems queueItems = new QueueItems();
            for (int i = 0; i < 13; i++)
            {
                queueItems.Add(CreateQueueItem(1));
                queueItems.Add(CreateQueueItem(5));
            }

            IBattle battleReady = strategy.CreateBattle(queueItems);

            // act // arrange
            battleReady.IsReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldFinalizeBattle()
        {
            // arrange
            SameTier matchingStrategy = new SameTier(5);

            QueueItem queueItem = new QueueItem(new Player(333), new Tank(5, "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(queueItem);

            for (int i = 0; i < 13; i++)
            {
                queueItems.Add(CreateQueueItem(5));
            }

            // act
            BattleReady battleReady = (BattleReady)matchingStrategy.CreateBattle(queueItems);

            // assert
            battleReady.ContainsPlayer(new Player(333)).Should().BeTrue();
            queueItems.Contains(queueItem).Should().BeFalse();
        }

        private static QueueItem CreateQueueItem(int tier)
        {
            return new QueueItem(new Player(1), new Tank(tier, null));
        }
    }
}

