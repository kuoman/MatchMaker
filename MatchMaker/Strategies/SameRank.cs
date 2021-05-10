using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameRank : IStrategy
    {
        private readonly string _rank;
        public SameRank()
        {
            
        }

        public SameRank(string rank)
        {
            _rank = rank;
        }

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady, QueueItem queueItem)
        {
            throw new System.NotImplementedException();
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.ByRank(queueItem).GetMatchPair(queueItems, queueItem);
        }
    }
}