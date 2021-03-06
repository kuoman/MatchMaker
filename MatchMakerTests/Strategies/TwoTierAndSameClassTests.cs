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

            QueueItem queueItem01 = new QueueItem(ObjectBuider.CreatePlayer(3, 50d, 499), ObjectBuider.CreateTank(4, "Tank Destroyer", "Heavy"));
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(ObjectBuider.CreatePlayer(12, 50d, 499), ObjectBuider.CreateTank(4, "Light", "Heavy"));
            queueItems.Add(queueItem02);

            QueueItem queueItem03 = new QueueItem(ObjectBuider.CreatePlayer(13, 50d, 499), ObjectBuider.CreateTank(3, "Heavy", "Heavy"));
            queueItems.Add(queueItem03);

            QueueItem queueItem04 = new QueueItem(ObjectBuider.CreatePlayer(14, 50d, 499), ObjectBuider.CreateTank(4, "Light", "Heavy"));
            queueItems.Add(queueItem04);

            IStrategy sameTierSameClass = new SameTierSameClass();

            //Act
            IMatchPair matchPair = sameTierSameClass.CreateMatchPair(queueItems, queueItem02);

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

            QueueItem queueItem01 = new QueueItem(ObjectBuider.CreatePlayer(3, 50d, 499), ObjectBuider.CreateTank(4, "Tank Destroyer", "Heavy"));
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(ObjectBuider.CreatePlayer(12, 50d, 499), ObjectBuider.CreateTank(4, "Light", "Heavy"));
            queueItems.Add(queueItem02);

            QueueItem queueItem03 = new QueueItem(ObjectBuider.CreatePlayer(13, 50d, 499), ObjectBuider.CreateTank(3, "Heavy", "Heavy"));
            queueItems.Add(queueItem03);

            QueueItem queueItem04 = new QueueItem(ObjectBuider.CreatePlayer(14, 50d, 499), ObjectBuider.CreateTank(4, "Light", "Heavy"));
            queueItems.Add(queueItem04);

            IStrategy sameTierSameClass = new SameTierSameClass();

            //Act
            IBattle battle = sameTierSameClass.PopulateBattle(queueItems, new Battle(), queueItem02);

            //Assert
            battle.ContainsPlayer(ObjectBuider.CreatePlayer(12, 50d, 499)).Should().BeTrue();
            battle.ContainsPlayer(ObjectBuider.CreatePlayer(14, 50d, 499)).Should().BeTrue();
        }
    }
}