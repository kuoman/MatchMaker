using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public abstract class Strategy : IStrategy
    {
        public IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady, QueueItem queueItem)
        {
            return CreateMatchPair(queueItems, queueItem).AddMatchToBattle(battleReady);
        }

        public virtual IMatchPair CreateMatchPair(QueueItems queueItems, QueueItem queueItem)
        {
            return queueItems.GetMatchPairTeamA(queueItems, queueItem);
        }
    }
}
