namespace MatchMaker.Data_Bags
{
    public class BattleNotReady : IBattle
    {
        public bool IsReadyToFight()
        {
            return false;
        }
    }
}
