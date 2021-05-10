﻿using MatchMaker.Data_Bags;

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

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady, QueueItem queueItem)
        {
            return CreateMatchPair(queueItems, queueItem).AddMatchToBattle(battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByTankType(queueItem).GetMatchPair(queueItems, queueItem);
        }
    }
}