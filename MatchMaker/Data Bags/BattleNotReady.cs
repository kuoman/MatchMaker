namespace MatchMaker.Data_Bags
{
    public class BattleNotReady : IBattle
    {
        public bool IsReadyToFight()
        {
            return false;
        }

        public bool IsNotReadyToFight()
        {
            return true;
        }

        public bool ContainsPlayer(Player player)
        {
            return false;
        }
    }
}
