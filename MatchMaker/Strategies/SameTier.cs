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
            IBattle battleReady = new BattleReady();

            for (int i = 0; i < 7; i++)
            {
                battleReady = CreateMatchPair(queueItems).AddMatchToBattle(battleReady);
            }

            if (battleReady.IsNotReadyToFight()) return new BattleNotReady();

            return battleReady;
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