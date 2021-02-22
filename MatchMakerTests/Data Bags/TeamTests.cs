using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MatchMaker;
using MatchMaker.Data_Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class TeamTests
    {
        [TestMethod]
        public void ShouldReturnTrueIfReadyToFight()
        {
            Team team = new Team();

            for (int i = 0; i < 7; i++)
            {
                team.QueueItemList.Add(new QueueItem(new Player(), new Tank()));
            }

            team.HasFullTeam().Should().BeTrue();
        }

        [TestMethod]
        public void ShouldReturnFalseIfReadyToFight()
        {
            Team team = new Team();

            for (int i = 0; i < 6; i++)
            {
                team.QueueItemList.Add(new QueueItem(new Player(), new Tank()));
            }

            team.HasFullTeam().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnTrueIfListNotFull()
        {
            Team team = new Team();

            for (int i = 0; i < 6; i++)
            {
                team.AddQueueItem(new QueueItem(new Player(), new Tank()));
            }

            team.TeamIsFull().Should().BeFalse();
        }

        [TestMethod]
        public void ShouldReturnFalseIfListFull()
        {
            Team team = new Team();

            for (int i = 0; i < 7; i++)
            {
                team.AddQueueItem(new QueueItem(new Player(), new Tank()));
            }

            team.TeamIsFull().Should().BeTrue();
        }
    }

}



