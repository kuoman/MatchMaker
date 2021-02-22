using System.Collections.Generic;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SimpleStrategy
    {
        public IBattle CreateBattle(List<QueueItem> queueItems)
        {
            if (13 >= queueItems.Count ) return new BattleNotReady();

            BattleReady battleReady = new BattleReady();

            for (int i = 0; i < 7; i++)
            {
                battleReady.AddQueueItemToTeamA(queueItems[i]);
            }

            for (int i = 7; i < 14; i++)
            {
                battleReady.AddQueueItemToTeamB(queueItems[i]);
            }

            return battleReady;
        }
    }
}