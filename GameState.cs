using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oneillo_2
{
    [Serializable]
    public class GameState
    {
        public int[,] boardData { get; set; }
        public string playerOneName { get; set; }
        public string playerTwoName { get; set; }
        public int numOfBlack { get; set; }
        public int numOfWhite { get; set; }
        public int player { get; set; }
        public int gameMoves { get; set; }
        public string gameName { get; set; }

        public GameState(int[,] currentBoardData, string CurrentPlayerOneName,string CurrentPlayerTwoName, int CurrentNumOfBlack, int CurrentNumOfWhite, int CurrentPlayer, int CurrentGameMoves, string CurrentGameName)
        {
            boardData = currentBoardData;

            playerOneName = CurrentPlayerOneName;

            playerTwoName = CurrentPlayerTwoName;

            numOfBlack = CurrentNumOfBlack;

            numOfWhite = CurrentNumOfWhite;

            player = CurrentPlayer;

            gameMoves = CurrentGameMoves;

            gameName = CurrentGameName;
        }

    }

}
