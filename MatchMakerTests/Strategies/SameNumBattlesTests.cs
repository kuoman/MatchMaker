using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SameNumBattlesTests
    {
        [TestMethod]
        public void ShouldCreateMatchPairByQueueItem()
        {
            // arrange
            Player player = ObjectBuider.CreatePlayer(1, 51, 6500);
            QueueItem queueItem1 = new QueueItem(player, ObjectBuider.CreateTank(6, "Medium", "Heavy"));
            QueueItem queueItem2 = new QueueItem(ObjectBuider.CreatePlayer(2, 53, 9999), ObjectBuider.CreateTank(3, "Medium", "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(ObjectBuider.CreatePlayer(5, 40, 20), ObjectBuider.CreateTank(4, "Heavy", "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new SameNumBattlesCategory().CreateMatchPair(queueItems, queueItem1);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
        }
    }
}