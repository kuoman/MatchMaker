﻿using FluentAssertions;
using MatchMaker.Data_Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class QueueItemTests
    {
        [TestMethod]
        public void ShouldFindPlayer()
        {
            // arrange
            Player player = new Player(1);

            QueueItem queueItem = CreateQueueItem(1);

            // act // assert
            queueItem.HasPlayer(player).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldNotFindPlayer()
        {
            // arrange
            QueueItem queueItem = CreateQueueItem(1);

            // act // assert
            queueItem.HasPlayer(new Player(2)).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfCorrectTier()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItem(5);

            // act // assert
            queueItem.IsTier(5).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTier()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItem(5);

            // act // assert
            queueItem.IsTier(4).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfCorrectTankType()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Heavy");

            // act // assert
            queueItem.IsTankType("Heavy").Should().BeTrue();
        }


        [TestMethod]
        public void ShouldReturnFalseIfIncorrectTankType()
        {
            // arrange 
            QueueItem queueItem = CreateQueueItemOfTankType("Light");

            // act // assert
            queueItem.IsTankType("Heavy").Should().BeFalse();
        }

        private static QueueItem CreateQueueItem(int tier)
        {
            return new QueueItem(new Player(1), new Tank(tier, null));
        }

        private static QueueItem CreateQueueItemOfTankType(string tankType)
        {
            return new QueueItem(new Player(1), new Tank(1, tankType));
        }

    }
}


