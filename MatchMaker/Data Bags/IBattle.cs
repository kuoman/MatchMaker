namespace MatchMaker.Data_Bags
{
    public interface IBattle
    {
        bool IsReadyToFight();
        bool ContainsPlayer(Player player);
    }
}