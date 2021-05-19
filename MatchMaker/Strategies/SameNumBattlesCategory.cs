using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameNumBattlesCategory: Strategy
    {
        override
            public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByNumBattles(queueItem).GetMatchPair(queueItems, queueItem);
        }
    }
}