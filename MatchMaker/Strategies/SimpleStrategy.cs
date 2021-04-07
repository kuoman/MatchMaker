using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public class SimpleStrategy : IStrategy
    {
        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady)
        {
            return CreateMatchPair(queueItems).AddMatchToBattle(battleReady);
        }

        public IMatchPair CreateMatchPair(QueueItems queueItems)
        {
            return queueItems.GetMatchPair(queueItems);
        }
    }
}