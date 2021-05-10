using System;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameTierSameClass : IStrategy
    {
        private readonly int _tier;
        private readonly string _tankType;

        public SameTierSameClass()
        {
        }

        public SameTierSameClass(int tier, string tankType)
        {
            _tier = tier;
            _tankType = tankType;
        }

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady, QueueItem queueItem)
        {
            return CreateMatchPair(queueItems, queueItem).AddMatchToBattle(battleReady);
        }

        // todo: test this one too
        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByTier(queueItem).ByTankType(queueItem).GetMatchPair(queueItems, queueItem);
        }

    }
}