using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
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

            QueueItem queueItem01 = new QueueItem(new Player((int) 3, (double) 50d, (int) 499), new Tank((int) 4, (string) "Tank Destroyer", (string) "Heavy"));
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player((int) 12, (double) 50d, (int) 499), new Tank((int) 4, (string) "Light", (string) "Heavy"));
            queueItems.Add(queueItem02);

            QueueItem queueItem03 = new QueueItem(new Player((int) 13, (double) 50d, (int) 499), new Tank((int) 3, (string) "Heavy", (string) "Heavy"));
            queueItems.Add(queueItem03);

            QueueItem queueItem04 = new QueueItem(new Player((int) 14, (double) 50d, (int) 499), new Tank((int) 4, (string) "Light", (string) "Heavy"));
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

            QueueItem queueItem01 = new QueueItem(new Player((int) 3, (double) 50d, (int) 499), new Tank((int) 4, (string) "Tank Destroyer", (string) "Heavy"));
            queueItems.Add(queueItem01);

            QueueItem queueItem02 = new QueueItem(new Player((int) 12, (double) 50d, (int) 499), new Tank((int) 4, (string) "Light", (string) "Heavy"));
            queueItems.Add(queueItem02);

            QueueItem queueItem03 = new QueueItem(new Player((int) 13, (double) 50d, (int) 499), new Tank((int) 3, (string) "Heavy", (string) "Heavy"));
            queueItems.Add(queueItem03);

            QueueItem queueItem04 = new QueueItem(new Player((int) 14, (double) 50d, (int) 499), new Tank((int) 4, (string) "Light", (string) "Heavy"));
            queueItems.Add(queueItem04);

            IStrategy sameTierSameClass = new SameTierSameClass();

            //Act
            IBattle battle = sameTierSameClass.PopulateBattle(queueItems, new Battle(), queueItem02);

            //Assert
            battle.ContainsPlayer(new Player((int) 12, (double) 50d, (int) 499)).Should().BeTrue();
            battle.ContainsPlayer(new Player((int) 14, (double) 50d, (int) 499)).Should().BeTrue();
        }
    }
}
