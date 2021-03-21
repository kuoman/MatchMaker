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
            BattleReady battleReady = new BattleReady();

            battleReady = queueItems.ByTier(_tier).AddTanksToBattleReady(battleReady, 7);

            if (!battleReady.IsReadyToFight())
            {
                queueItems.ByTier(GetFallbackTier(_tier)).AddTanksToBattleReady(battleReady, 7);
            }

            if (!battleReady.IsReadyToFight()) return new BattleNotReady();

            return battleReady;
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