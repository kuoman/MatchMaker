using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FluentAssertions;
using MatchMaker;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests
{
    [TestClass]
    public class SimpleStrategyTests
    {
        [TestMethod]
        public void ShouldReturnBattle()
        {
            // arrange
            SimpleStrategy simpleStrategy = new SimpleStrategy();
            List<QueueItem> queueItems = new List<QueueItem>();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(new QueueItem(new Player(), new Tank()));
            }

            // act
            Battle battle = simpleStrategy.CreateBattle(queueItems);

            // assert
            battle.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldReturnBattleWithTeams()
        {
            // arrange
            SimpleStrategy simpleStrategy = new SimpleStrategy();
            List<QueueItem> queueItems = new List<QueueItem>();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(new QueueItem(new Player(), new Tank()));
            }

            // act
            Battle battle = simpleStrategy.CreateBattle(queueItems);

            // assert
            battle.TeamA.Should().NotBeNull();
            battle.TeamB.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldReturnBattleWithTeamsWithPlayerLists()
        {
            // arrange
            SimpleStrategy simpleStrategy = new SimpleStrategy();

            List<QueueItem> queueItems = new List<QueueItem>();
            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(new QueueItem(new Player(), new Tank()));
            }

            // act
            Battle battle = simpleStrategy.CreateBattle(queueItems);

            // assert
            battle.TeamA.QueueItemList.Should().NotBeNull();
            battle.TeamB.QueueItemList.Should().NotBeNull();
        }

        [TestMethod]
        public void ShouldReturnBattleWithTeamsWithPlayerListsOfCount7Each()
        {
            // arrange
            List<QueueItem> queueItems = new List<QueueItem>();

            for (int i = 0; i < 14; i++)
            {
                queueItems.Add(new QueueItem(new Player(), new Tank()));
            }

            SimpleStrategy simpleStrategy = new SimpleStrategy();

            // act
            Battle battle = simpleStrategy.CreateBattle(queueItems);

            // assert
            battle.TeamA.QueueItemList.Should().HaveCount(7);
            battle.TeamB.QueueItemList.Should().HaveCount(7);


            battle.TeamA.QueueItemList.Should().Contain(queueItems[0]);
            battle.TeamA.QueueItemList.Should().Contain(queueItems[1]);
            battle.TeamA.QueueItemList.Should().Contain(queueItems[2]);
            battle.TeamA.QueueItemList.Should().Contain(queueItems[3]);
            battle.TeamA.QueueItemList.Should().Contain(queueItems[4]);
            battle.TeamA.QueueItemList.Should().Contain(queueItems[5]);
            battle.TeamA.QueueItemList.Should().Contain(queueItems[6]);

            battle.TeamB.QueueItemList.Should().Contain(queueItems[7]);
            battle.TeamB.QueueItemList.Should().Contain(queueItems[8]);
            battle.TeamB.QueueItemList.Should().Contain(queueItems[9]);
            battle.TeamB.QueueItemList.Should().Contain(queueItems[10]);
            battle.TeamB.QueueItemList.Should().Contain(queueItems[11]);
            battle.TeamB.QueueItemList.Should().Contain(queueItems[12]);
            battle.TeamB.QueueItemList.Should().Contain(queueItems[13]);

            battle.TeamB.QueueItemList.Should().NotContain(queueItems[0]);
            battle.TeamB.QueueItemList.Should().NotContain(queueItems[1]);
            battle.TeamB.QueueItemList.Should().NotContain(queueItems[2]);
            battle.TeamB.QueueItemList.Should().NotContain(queueItems[3]);
            battle.TeamB.QueueItemList.Should().NotContain(queueItems[4]);
            battle.TeamB.QueueItemList.Should().NotContain(queueItems[5]);
            battle.TeamB.QueueItemList.Should().NotContain(queueItems[6]);

            battle.TeamA.QueueItemList.Should().NotContain(queueItems[7]);
            battle.TeamA.QueueItemList.Should().NotContain(queueItems[8]);
            battle.TeamA.QueueItemList.Should().NotContain(queueItems[9]);
            battle.TeamA.QueueItemList.Should().NotContain(queueItems[10]);
            battle.TeamA.QueueItemList.Should().NotContain(queueItems[11]);
            battle.TeamA.QueueItemList.Should().NotContain(queueItems[12]);
            battle.TeamA.QueueItemList.Should().NotContain(queueItems[13]);
        }
    }

    public class SimpleStrategy
    {
        public Battle CreateBattle(List<QueueItem> queueItems)
        {
            Battle battle = new Battle();

            battle.TeamA = new Team();
            battle.TeamA.QueueItemList = new List<QueueItem>();

            battle.TeamB = new Team();
            battle.TeamB.QueueItemList = new List<QueueItem>();
            
            for (int i = 0; i < 7; i++)
            {
                battle.TeamA.QueueItemList.Add(queueItems[i]);
            }

            for (int i = 7; i < 14; i++)
            {
                battle.TeamB.QueueItemList.Add(queueItems[i]);
            }

            return battle;
        }
    }
}
