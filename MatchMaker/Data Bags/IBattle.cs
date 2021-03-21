namespace MatchMaker.Data_Bags
{
    public interface IBattle
    {
        bool IsReadyToFight();
        bool IsNotReadyToFight();
        bool ContainsPlayer(Player player);
    }
}