using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameRank : Strategy
    {
        override 
        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByRank(queueItem).GetMatchPair(queueItems, queueItem);
        }
    }
}