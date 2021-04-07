using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SameTier : IStrategy
    {
        private readonly int _tier;

        public SameTier(int tier)
        {
            _tier = tier;
        }

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady)
        {
            return CreateMatchPair(queueItems).AddMatchToBattle(battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.ByTier(_tier).GetMatchPair(queueItems);
        }
    }
}