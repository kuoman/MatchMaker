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
            QueueItem queueItem1 = new QueueItem(new Player((int) 1, (double) 50d, (int) 499), new Tank((int) 3, (string) "Medium", (string) "Heavy"));
            QueueItem queueItem2 = new QueueItem(new Player((int) 2, (double) 50d, (int) 499), new Tank((int) 3, (string) "Medium", (string) "Heavy"));

            QueueItem anchorItem = new QueueItem(new Player((int) 2, (double) 50d, (int) 499), new Tank((int) 3, (string) "Medium", (string) "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player((int) 5, (double) 50d, (int) 499), new Tank((int) 4, (string) "Heavy", (string) "Heavy")));
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
            QueueItem queueItem1 = new QueueItem(new Player((int) 1, (double) 50d, (int) 499), new Tank((int) 3, (string) "Medium", (string) "Heavy"));
            QueueItem queueItem2 = new QueueItem(new Player((int) 2, (double) 50d, (int) 499), new Tank((int) 3, (string) "Medium", (string) "Heavy"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player((int) 5, (double) 50d, (int) 499), new Tank((int) 4, (string) "Heavy", (string) "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IBattle battle = new SameTier().PopulateBattle(queueItems, new Battle(), queueItem1);

            // assert
            battle.ContainsPlayer(new Player((int) 1, (double) 50d, (int) 499)).Should().BeTrue();
            battle.ContainsPlayer(new Player((int) 2, (double) 50d, (int) 499)).Should().BeTrue();
        }
    }
}

