﻿using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;
using MatchMaker.Strategies;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace MatchMakerTests.Strategies
{
    [TestClass]
    public class SameClassTests
    {
        [TestMethod]
        public void ShouldCreateMatchPairByQueueItem()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(6, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItem anchorItem = new QueueItem(new Player(1), new Tank(4, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5), new Tank(4, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IMatchPair matchPair = new SameClass().CreateMatchPair(queueItems, anchorItem);

            // assert
            matchPair.Contains(queueItem1).Should().BeTrue();
            matchPair.Contains(queueItem2).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldPopulateBattle()
        {
            // arrange
            QueueItem queueItem1 = new QueueItem(new Player(1), new Tank(6, "Medium"));
            QueueItem queueItem2 = new QueueItem(new Player(2), new Tank(3, "Medium"));

            QueueItems queueItems = new QueueItems();
            queueItems.Add(new QueueItem(new Player(5), new Tank(4, "Heavy")));
            queueItems.Add(queueItem1);
            queueItems.Add(queueItem2);

            // act 
            IBattle battle = new SameClass().PopulateBattle(queueItems, new Battle(), queueItem1);

            // assert
            battle.ContainsPlayer(new Player(1)).Should().BeTrue();
            battle.ContainsPlayer(new Player(2)).Should().BeTrue();
        }
    }
}
