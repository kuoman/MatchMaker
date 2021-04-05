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
            IBattle battleReady = queueItems.ByTier(_tier).AddTanksToBattleReady(new BattleReady(), 7);

            if (battleReady.IsNotReadyToFight()) return new BattleNotReady();

            battleReady.FinalizeBattle(queueItems);

            return battleReady;
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.ByTier(3).GetMatchPair();
        }
    }
}