using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameTier : IStrategy
    {
        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady, QueueItem queueItem)
        {
            return CreateMatchPair(queueItems, queueItem).AddMatchToBattle(battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByTier(queueItem).GetMatchPair(queueItems, queueItem);
        }
    }
}