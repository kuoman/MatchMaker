using System;
using System.Collections.Generic;
using System.Text;

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
