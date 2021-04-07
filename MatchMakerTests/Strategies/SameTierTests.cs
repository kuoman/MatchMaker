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

