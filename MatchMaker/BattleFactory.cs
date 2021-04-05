using MatchMaker.Data_Bags;
using MatchMaker.Strategies;

namespace MatchMaker
{
    public class BattleFactory
    {
        public IBattle Create(IStrategy strategy, QueueItems queueItems)
        {
            IBattle battleReady = new BattleReady();

            for (int i = 0; i < 7; i++)
            {
                battleReady = strategy.PopulateBattle(queueItems, battleReady);
            }

            return battleReady;
        }
    }
}
