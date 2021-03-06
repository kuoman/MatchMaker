using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks.Tier10;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SameRankTests
    {
        [TestMethod]
        public void ShouldCreateMatchPairSameRank()
        {
            QueueItem queueItem1 = new QueueItem(ObjectBuider.CreatePlayer(1, 50d, 499), new Maus());
            QueueItem queueItem2 = new QueueItem(ObjectBuider.CreatePlayer(2, 50d, 499), new E100());

            QueueItem anchorItem = new QueueItem(ObjectBuider.CreatePlayer(2, 50d, 499), new E100());

            QueueItems queueItems = new QueueItems();
            queueItems.Add(queueItem1);
            queueItems.Add(new QueueItem(ObjectBuider.CreatePlayer(5, 50d, 499), new T110E5()));
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new SameRank().CreateMatchPair(queueItems, anchorItem);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(anchorItem).Should().BeTrue();
        }
    }
}