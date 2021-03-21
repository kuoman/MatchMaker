using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SimpleStrategy : IStrategy
    {
        public IBattle CreateBattle(QueueItems queueItems)
        {
            return queueItems.AddTanksToBattleReady(new BattleReady(), 7);
        }
    }
}