using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class TwoTier : IStrategy
    {
        private readonly int _tier;

        public TwoTier(int tier)
        {
            _tier = tier;
        }

        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady)
        {
            return CreateMatchPair(queueItems).AddMatchToBattle(battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            IMatchPair matchPair = queueItems.ByTier(_tier).GetMatchPair(queueItems);

            if (matchPair.IsPairFull()) return matchPair;

            return queueItems.ByTier(GetFallbackTier(_tier)).GetMatchPair(queueItems);
        }

        private int GetFallbackTier(int tier)
        {
            if (tier == 1)
            {
                return tier + 1;
            }

            return tier - 1;
        }
    }
}