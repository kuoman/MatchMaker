using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SameClassTests
    {
        [TestMethod]
        public void ShouldCreateMatchPairByQueueItem()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), ObjectBuider.CreateTank(6, "Medium", "Heavy"));
            QueueItem queueItem2 = new QueueItem(ObjectBuider.CreatePlayer(2, 50d, 499), ObjectBuider.CreateTank(3, "Medium", "Heavy"));

            QueueItem anchorItem = new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), ObjectBuider.CreateTank(4, "Medium", "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(ObjectBuider.CreatePlayer(5, 50d, 499), ObjectBuider.CreateTank(4, "Heavy", "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new SameClass().CreateMatchPair(queueItems, anchorItem);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(anchorItem).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldPopulateBattle()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), ObjectBuider.CreateTank(6, "Medium", "Heavy"));
            QueueItem queueItem2 = new QueueItem(ObjectBuider.CreatePlayer(2, 50d, 499), ObjectBuider.CreateTank(3, "Medium", "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(ObjectBuider.CreatePlayer(5, 50d, 499), ObjectBuider.CreateTank(4, "Heavy", "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IBattle battle = new SameClass().PopulateBattle(queueItems, new Battle(), queueItem1);

            // assert
            battle.ContainsPlayer(ObjectBuider.CreatePlayer(1, 50d, 499)).Should().BeTrue();
            battle.ContainsPlayer(ObjectBuider.CreatePlayer(2, 50d, 499)).Should().BeTrue();
        }
    }
}