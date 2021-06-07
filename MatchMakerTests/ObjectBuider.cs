using System;
using System.Collections.Generic;
using System.Text;
using MatchMaker.Data_Bags;
using MatchMaker.Data_Bags.Tanks;

namespace MatchMakerTests
{
    static class ObjectBuider
    {
        public static Player CreatePlayer(int id, double winRate, int numBattles)
        {
            return new Player(id, winRate, numBattles);
        }

        public static Tank CreateTank(int tier, string tankType, string rank)
        {
            return new Tank(tier, tankType, rank);
        }
    }
}
