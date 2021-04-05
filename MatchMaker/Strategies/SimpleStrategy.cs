using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SimpleStrategy : IStrategy
    {
        public IBattle CreateBattle(QueueItems queueItems)
        {
            IBattle battleReady =  queueItems.AddTanksToBattleReady(new BattleReady(), 7);

            if (battleReady.IsNotReadyToFight()) return new BattleNotReady();

            battleReady.FinalizeBattle(queueItems);

            return battleReady;
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.GetMatchPair();
        }
    }
}