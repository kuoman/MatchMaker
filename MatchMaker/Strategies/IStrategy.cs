using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public interface IStrategy
    {
        IBattle PopulateBattle(QueueItems queueItems, IBattle battleReady);
        IMatchPair CreateMatchPair(QueueItems queueItems);
    }
}