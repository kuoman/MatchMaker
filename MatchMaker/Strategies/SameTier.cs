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
        public IBattle CreateBattle(QueueItems queueItems)
        {
            BattleReady battleReady = queueItems.ByTier(_tier).AddTanksToBattleReady(new BattleReady(), 7);

            if (battleReady.IsNotReadyToFight()) return new BattleNotReady();

            battleReady.FinalizeBattle(queueItems);

            return battleReady;
        }
    }
}