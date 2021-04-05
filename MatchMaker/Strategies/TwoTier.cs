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

        public IBattle CreateBattle(QueueItems queueItems)
        {
            IBattle battleReady = queueItems.ByTier(_tier).AddTanksToBattleReady(new BattleReady(), 7);

            if (battleReady.IsNotReadyToFight())
            {
                queueItems.ByTier(GetFallbackTier(_tier)).AddTanksToBattleReady(battleReady, 7);
            }

            if (battleReady.IsNotReadyToFight()) return new BattleNotReady();

            battleReady.FinalizeBattle(queueItems);

            return battleReady;
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            IMatchPair matchPair = queueItems.ByTier(_tier).GetMatchPair();

            if (matchPair.IsPairFull()) return matchPair;

            return queueItems.ByTier(GetFallbackTier(_tier)).GetMatchPair();
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