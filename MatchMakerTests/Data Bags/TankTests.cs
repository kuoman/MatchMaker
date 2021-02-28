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
            Tank tank = new Tank(5);

            tank.IsTier(5).Should().BeTrue();
        }
    }
}

