using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicTacToe.classes
{
    public class Settings
    {
        public GameTypeEnum GameType{
            get;set;
        }
    }
    public enum GameTypeEnum
    {
        Player1 = 1, Player2
    }
}
