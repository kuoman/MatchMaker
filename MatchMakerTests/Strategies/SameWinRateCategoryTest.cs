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
            Player player = new Player((int) 1, (double) 51, (int) 499);
            QueueItem queueItem1 = new QueueItem(player, new Tank((int) 6, (string) "Medium", (string) "Heavy"));
            QueueItem queueItem2 = new QueueItem(new Player((int) 2, (double) 53, (int) 499), new Tank((int) 3, (string) "Medium", (string) "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player((int) 5, (double) 40, (int) 499), new Tank((int) 4, (string) "Heavy", (string) "Heavy")));
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
            Player player = new Player((int) 1, (double) 51, (int) 499);
            QueueItem queueItem1 = new QueueItem(player, new Tank((int) 6, (string) "Medium", (string) "Heavy"));
            QueueItem queueItem2 = new QueueItem(new Player((int) 2, (double) 53, (int) 499), new Tank((int) 3, (string) "Medium", (string) "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player((int) 5, (double) 40, (int) 499), new Tank((int) 4, (string) "Heavy", (string) "Heavy")));
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
