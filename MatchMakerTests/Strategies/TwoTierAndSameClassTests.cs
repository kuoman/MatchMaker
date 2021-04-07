using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class TwoTierAndSameClassTests
    {
        [TestMethod]
        public void ShouldSortByTierAndClass()
        {
            //Arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem01 = new QueueItem(new Player(3), new Tank(4, "Tank Destroyer"));
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player(12), new Tank(4, "Light"));
            queueItems.Add(queueItem02);

            QueueItem queueItem03 = new QueueItem(new Player(13), new Tank(3, "Heavy"));
            queueItems.Add(queueItem03);

            QueueItem queueItem04 = new QueueItem(new Player(14), new Tank(4, "Light"));
            queueItems.Add(queueItem04);

            IStrategy sameTierSameClass = new SameTierSameClass(4, "Light");

            //Act
            IMatchPair matchPair = sameTierSameClass.CreateMatchPair(queueItems);

            //Assert
            matchPair.Contains(queueItem01).Should().BeFalse();
            matchPair.Contains(queueItem03).Should().BeFalse();
            matchPair.Contains(queueItem02).Should().BeTrue();
            matchPair.Contains(queueItem04).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldPopulateBattle()
        {
            //Arrange
            QueueItems queueItems = new QueueItems();

            QueueItem queueItem01 = new QueueItem(new Player(3), new Tank(4, "Tank Destroyer"));
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player(12), new Tank(4, "Light"));
            queueItems.Add(queueItem02);

            QueueItem queueItem03 = new QueueItem(new Player(13), new Tank(3, "Heavy"));
            queueItems.Add(queueItem03);

            QueueItem queueItem04 = new QueueItem(new Player(14), new Tank(4, "Light"));
            queueItems.Add(queueItem04);

            IStrategy sameTierSameClass = new SameTierSameClass(4, "Light");

            //Act
            IBattle battle = sameTierSameClass.PopulateBattle(queueItems, new Battle());

            //Assert
            battle.ContainsPlayer(new Player(12)).Should().BeTrue();
            battle.ContainsPlayer(new Player(14)).Should().BeTrue();
        }
    }
}
