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

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady)
        {
            return CreateMatchPair(queueItems).AddMatchToBattle(battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.ByTier(_tier).ByTankType(_tankType).GetMatchPair(queueItems);
        }

    }
}