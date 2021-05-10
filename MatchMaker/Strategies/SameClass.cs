using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameClass : Strategy
    {
        override 
        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByTankType(queueItem).GetMatchPair(queueItems, queueItem);
        }
    }
}