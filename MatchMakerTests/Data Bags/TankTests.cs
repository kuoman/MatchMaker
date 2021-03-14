using System;
using System.Collections.Generic;
using System.Text;
using FluentAssertions;
using MatchMaker.Data_Bags;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MatchMakerTests.Data_Bags
{
    [TestClass]
    public class TankTests
    {
        [TestMethod]
        public void ShouldConfirmLevel()
        {
            Tank tank = new Tank(5, null);

            tank.IsTier(5).Should().BeTrue();
        }

        [TestMethod]
        public void ShouldConfirmNotLevel()
        {
            Tank tank = new Tank(4, null);

            tank.IsTier(5).Should().BeFalse();
        }

        [TestMethod]
        public void ShouldConfirmTankType()
        {
            Tank tank = new Tank(5, "Heavy");

            tank.IsTankType("Heavy").Should().BeTrue();
        }

        [TestMethod]
        public void ShouldConfirmNotTankType()
        {
            Tank tank = new Tank(5, "Light");

            tank.IsTankType("Heavy").Should().BeFalse();
        }
    }
}

