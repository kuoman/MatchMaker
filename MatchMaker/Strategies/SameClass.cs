using System;
using System.Collections.Generic;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameClass : IStrategy
    {
        private readonly string _tankType;

        public SameClass()
        {
        }

        public SameClass(string tankType)
        {
            _tankType = tankType;
        }
        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady)
        {
            return CreateMatchPair(queueItems).AddMatchToBattle(battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.ByTankType(_tankType).GetMatchPair(queueItems);
        }
    }
}