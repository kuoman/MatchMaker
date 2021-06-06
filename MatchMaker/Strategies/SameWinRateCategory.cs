using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameWinRateCategory: Strategy
    {
        override 
        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByWinRate(queueItem).GetMatchPairTeamA(queueItems, queueItem);
        }
    }
}