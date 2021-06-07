using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SameTierTests
    {
        [TestMethod]
        public void ShouldCreateMatchPairByQueueItem()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1, 50d, 499), new Tank(3, "Medium", "Heavy"));
            QueueItem queueItem2 = new QueueItem(new Player(2, 50d, 499), new Tank(3, "Medium", "Heavy"));

            QueueItem anchorItem = new QueueItem(new Player(2, 50d, 499), new Tank(3, "Medium", "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5, 50d, 499), new Tank(4, "Heavy", "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new SameTier().CreateMatchPair(queueItems, anchorItem);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(anchorItem).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldPopulateBattle()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1, 50d, 499), new Tank(3, "Medium", "Heavy"));
            QueueItem queueItem2 = new QueueItem(new Player(2, 50d, 499), new Tank(3, "Medium", "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5, 50d, 499), new Tank(4, "Heavy", "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IBattle battle = new SameTier().PopulateBattle(queueItems, new Battle(), queueItem1);

            // assert
            battle.ContainsPlayer(new Player(1, 50d, 499)).Should().BeTrue();
            battle.ContainsPlayer(new Player(2, 50d, 499)).Should().BeTrue();
        }
    }
}