using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SameWinRateCategoryTest
    {
        [TestMethod]
        public void ShouldCreateMatchPairByQueueItem()
        {
            // arrange
            Player player = new Player(1, 51, 499);
            QueueItem queueItem1 = new QueueItem(player, new Tank(6, "Medium", "Heavy"));
            QueueItem queueItem2 = new QueueItem(new Player(2, 53, 499), new Tank(3, "Medium", "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5, 40, 499), new Tank(4, "Heavy", "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new SameWinRateCategory().CreateMatchPair(queueItems, queueItem1);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldCreateMatchPairWithoutPlayer()
        {
            // arrange
            Player player = new Player(1, 51, 499);
            QueueItem queueItem1 = new QueueItem(player, new Tank(6, "Medium", "Heavy"));
            QueueItem queueItem2 = new QueueItem(new Player(2, 53, 499), new Tank(3, "Medium", "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5, 40, 499), new Tank(4, "Heavy", "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new SameWinRateCategory().CreateMatchPair(queueItems, queueItem1);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
        }
    }
}