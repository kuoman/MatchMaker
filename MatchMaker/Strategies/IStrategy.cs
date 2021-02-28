using System.Collections.Generic;
using MatchMaker.Data_Bags;

namespace MatchMaker.Strategies
{
    public interface IStrategy
    {
        IBattle CreateBattle(List<QueueItem> queueItems);
    }
}