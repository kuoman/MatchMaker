using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SimpleStrategyTests
    {
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
            IMatchPair matchPair = new SimpleStrategy().CreateMatchPair(queueItems, queueItem2);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
        }
    }
}
