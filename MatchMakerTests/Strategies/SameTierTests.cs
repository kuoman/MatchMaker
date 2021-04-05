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

        [TestMethod]
        public void ShouldCreateMatchPair()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(3, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5), new Tank(4, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new SameTier(3).CreateMatchPair(queueItems);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
        }


        [TestMethod]
        public void ShouldPopulateBattle()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(3, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5), new Tank(4, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IBattle battle = new SameTier(3).PopulateBattle(queueItems, new BattleReady());

            // assert
            battle.ContainsPlayer(new Player(1)).Should().BeTrue();
            battle.ContainsPlayer(new Player(2)).Should().BeTrue();
        }

        private static QueueItem CreateQueueItem(int tier)
        {
            return new QueueItem(new Player(1), new Tank(tier, null));
        }
    }
}

