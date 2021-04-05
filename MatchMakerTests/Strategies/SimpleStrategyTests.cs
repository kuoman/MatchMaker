using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SimpleStrategyTests
    {
        [TestMethod]
        public void ShouldReturnBattleReadyThatIsReadyToFight()
        {
            // arrange
            SimpleStrategy simpleStrategy = new SimpleStrategy();

            QueueItems queueItems = new QueueItems();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(CreateQueueItem());
            }

            IBattle battleReady = simpleStrategy.CreateBattle(queueItems);

            // act // arrange
            battleReady.IsReadyToFight().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnBattleNotReadyIfTeamsAreNotReady()
        {
            // arrange
            QueueItems queueItems = new QueueItems();

            for (int i = 0; i < 13; i++)
            {
                queueItems.Add(CreateQueueItem());
            }

            SimpleStrategy simpleStrategy = new SimpleStrategy();

            IBattle battleReady = simpleStrategy.CreateBattle(queueItems);

            // act // arrange
            battleReady.IsReadyToFight().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldFinalizeBattle()
        {
            // arrange
            SimpleStrategy simpleStrategy = new SimpleStrategy();

            QueueItem queueItem = new QueueItem(new Player(1), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(queueItem);

            for (int i = 0; i < 13; i++)
            {
                queueItems.Add(CreateQueueItem());
            }

            // act
            IBattle battleReady = simpleStrategy.CreateBattle(queueItems);

            // assert
            battleReady.Should().NotBeNull();
            battleReady.ContainsPlayer(new Player(1)).Should().BeTrue();
            queueItems.Contains(queueItem).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldCreateMatchPair()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(3, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new SimpleStrategy().CreateMatchPair(queueItems);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateMatchPairWithSameTier()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(3, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5), new Tank(5, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new TwoTier(3).CreateMatchPair(queueItems);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateMatchPairWithFallBackTier()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(3, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5), new Tank(5, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new TwoTier(4).CreateMatchPair(queueItems);

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
            queueItems.Add(new QueueItem(new Player(5), new Tank(5, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IBattle battle = new TwoTier(4).PopulateBattle(queueItems, new BattleReady());

            // assert
            battle.ContainsPlayer(new Player(1)).Should().BeTrue();
            battle.ContainsPlayer(new Player(2)).Should().BeTrue();
        }

        private static QueueItem CreateQueueItem()
        {
            return new QueueItem(new Player(1), new Tank(1, null));
        }
    }

}
