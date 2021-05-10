using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameTier : Strategy
    {
        override 
        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByTier(queueItem).GetMatchPair(queueItems, queueItem);
        }
    }
}