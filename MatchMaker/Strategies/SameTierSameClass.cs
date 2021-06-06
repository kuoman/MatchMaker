using System;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameTierSameClass : Strategy
    {
        // todo: test this one too
        override 
        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByTier(queueItem).ByTankType(queueItem).GetMatchPairTeamA(queueItems, queueItem);
        }

    }
}