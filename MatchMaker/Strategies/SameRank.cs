using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameRank : IStrategy
    {
        private readonly string _rank;

        public SameRank(string rank)
        {
            _rank = rank;
        }

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady)
        {
            throw new System.NotImplementedException();
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.ByRank(_rank).GetMatchPair(queueItems);
        }
    }
}