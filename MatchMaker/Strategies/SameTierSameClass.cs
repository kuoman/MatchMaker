using System;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameTierSameClass : IStrategy
    {
        private readonly int _tier;
        private readonly string _tankType;

        public SameTierSameClass(int tier, string tankType)
        {
            _tier = tier;
            _tankType = tankType;
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.ByTier(_tier).ByTankType(_tankType).GetMatchPair();
        }

        public IBattle CreateBattle(QueueItems queueItems)
        {
           throw new NotImplementedException();
        }
    }
}