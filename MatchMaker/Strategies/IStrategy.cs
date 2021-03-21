using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public interface IStrategy
    {
        IBattle CreateBattle(QueueItems queueItems);
    }
}