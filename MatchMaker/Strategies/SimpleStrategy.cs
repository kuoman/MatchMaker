using System.Collections.Generic;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SimpleStrategy : IStrategy
    {
        public IBattle CreateBattle(List<QueueItem> queueItems)
        {
            if (13 >= queueItems.Count ) return new BattleNotReady();

            BattleReady battleReady = new BattleReady();

            for (int i = 0; i < 14; i = i + 2)
            {
                battleReady.AddQueueItemToTeamA(queueItems[i]);
                battleReady.AddQueueItemToTeamB(queueItems[i + 1]);
            }

            return battleReady;
        }
    }
}