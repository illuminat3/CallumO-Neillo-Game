using GameboardGUI;
using System.Data.Common;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;

namespace Oneillo_2
{
    public partial class Form1 : Form
    {
        GameboardImageArray _gameboardGui;

        const int rows = 8, columns = 8;
        int[,] boardData;
        int gameMoves = 1;
        int row, col, changeInRow, changeInCol;
        int numOfBlack, numOfWhite;
        int player = 1;

        string imagepaths = $"{Environment.CurrentDirectory}\\resources\\";
        string winner;


        bool moveIsPossible;
        bool legalMove;
        bool isAnyMovePossible;

        private bool HasGameEnded()
        {
            foreach (int i in boardData)
            {
                if (i == 10)
                {
                    return false;
                }
            }

            return true;
        }


        private int[,] MakeBoardArray()
        {
            int[,] StartArray = new int[rows, columns];

            StartArray[3, 3] = 1;
            StartArray[4, 4] = 1;
            StartArray[3, 4] = 2;
            StartArray[4, 3] = 2;
            return StartArray;
        }

        // On start setup board data.

        public Form1()
        {

            Point top = new Point(10, 10); // setting up the form size
            Point bottom = new Point(10, 10);
            InitializeComponent();
            boardData = this.MakeBoardArray();  // gets the values of board size
            
            try
            {
                _gameboardGui = new GameboardImageArray(this, boardData, top, bottom, 3, imagepaths); // sets up the board on top of the form
                _gameboardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
                //_gameboardGui.UpdateBoardGui(boardData);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Board Size Too Small! ");  // checks for excpetion
                this.Close();
            }
            AddOutline();
        }
        // CLick Listener 



        private bool IsAnyMoveValid(int RowClicked, int ColumnClicked, int player)
        {
            (int x, int y)[] OFFSETS =
            {
        (1, 0), (1, 1), (0, 1), (-1, 0), (0, -1), (1, -1), (-1, 1), (-1, -1)
         };

            foreach (var offset in OFFSETS)
            {
                int changeInRow = offset.x;
                int changeInCol = offset.y;

                int row = RowClicked + changeInRow;
                int col = ColumnClicked + changeInCol;

                bool isAnyMovePossible = false;
                int trueCount = 0;
                List<int> validRow = new List<int>();
                List<int> validCol = new List<int>();
                validRow.Add(RowClicked);
                validCol.Add(ColumnClicked);

                bool sameCounterFound = false;

                while (row >= 0 && row < 8 && col >= 0 && col < 8)
                {
                    if (boardData[row, col] == player)
                    {
                        sameCounterFound = true;
                        break;
                    }
                    if (boardData[row, col] == 0)
                    {
                        break;
                    }

                    validRow.Add(row);
                    validCol.Add(col);

                    row += changeInRow;
                    col += changeInCol;
                    trueCount++;
                }

                if (trueCount >= 1 && sameCounterFound)
                {
                    isAnyMovePossible = true;
                    return isAnyMovePossible;
                }
            }

            return false;
        }

        public void AddOutline()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col= 0; col < 8; col++)
                {
                    if(IsAnyMoveValid(row, col, player))
                    {
                        _gameboardGui.SetTile(row, col, 3.ToString());
                    }

                }
                    
            }  
        }

        public void ClearPreviousLegalMoves()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (boardData[row, col] == 3) // Assuming the Tag property contains the identifier
                    {
                        _gameboardGui.SetTile(row, col, 0.ToString()); // Change it to the empty square
                    }
                }
            }
        }



        // public void AddOutline()
        // {
        //     for (int row = 0; row < 8; row++)
        //     {
        //         for (int col = 0; col < 8; col++)
        //         {
        //           
        // 
        //         }
        // 
        //     }
        // 
        // 
        // }

        // above is scan 
        // ADD DISPOSE OF OUTLINES 

        // SCAN BOARD  LIKE ADDOUTLINE() AND THEN REPLACE EACH "3" Value in the board with 0 / NULL


        public void GameTileClicked(object sender, EventArgs e)
         {
            int RowCLicked = _gameboardGui.GetCurrentRowIndex(sender);
            int ColumnClicked = _gameboardGui.GetCurrentColumnIndex(sender);


            gameMoves++;
            if (player == 1)
            {
                if (IsAnyMoveValid(RowCLicked, ColumnClicked, player))
                {
                    _gameboardGui.SetTile(RowCLicked, ColumnClicked, 1.ToString());
                    player = 2;
                }
            }
            if (player == 2)
            {
                if (IsAnyMoveValid(RowCLicked, ColumnClicked, player))
                {
                    _gameboardGui.SetTile(RowCLicked, ColumnClicked, 2.ToString());
                    player = 1;

                }
                
            }

            ClearPreviousLegalMoves();
            AddOutline();

            void IsGameFinished(int numOfBlack, int numOfWhite)
            {
                bool gameNotWonByFullBoard = false;
                bool gameNotWonByNoCounters = false;
                bool isAnyMovePossible = false;

                for (int xWinCheck = 0; xWinCheck <= 7; xWinCheck++)
                {
                    for (int yWinCheck = 0; yWinCheck <= 7; yWinCheck++)
                    {
                        //checks whether the board is full by counting the green squares
                        if (boardData[xWinCheck, yWinCheck] == 10)
                            gameNotWonByFullBoard = true;

                        //Here could I add something which checks whether both players have a counter on the board- use the numofcounters variable
                        if ((numOfBlack > 0) && (numOfWhite > 0))
                            gameNotWonByNoCounters = true;
                    }
                }

                int[,] validMoveArray = new int[8, 8];
                boardData.CopyTo(validMoveArray, 0);

                //checks whether any move on the board is possible... only runs the method for green squares as only they can be pressed

                _gameboardGui.UpdateBoardGui(validMoveArray);

                //if gameNotWon is not equal to true(IF THE GAME HAS BEEN WON)
                if ((gameNotWonByFullBoard != true) || (gameNotWonByNoCounters != true))
                    WinnerCheck(numOfBlack, numOfWhite);

                else if (isAnyMovePossible == false)
                    ForfeitGame();

                else
                    return;
            }

            void ForfeitGame()  //Function to be completed
            {
                _gameboardGui.Dispose();
                InitializeComponent();
            }

            void GameEnded()
            {
                if (int.Parse(PlayerOnePieceLbl.Text) > int.Parse(PlayerTwoPieceLbl.Text))
                {
                    MessageBox.Show($"{PlayerOneName.Text} is the winner.");
                }
                else if (int.Parse(PlayerOnePieceLbl.Text) == int.Parse(PlayerTwoPieceLbl.Text))
                {
                    MessageBox.Show("The game was a draw.");
                }
                else
                {
                    MessageBox.Show($"{PlayerTwoName.Text} is the winner.");
                }
            }

            void WinnerCheck(int numOfBlack, int numOfWhite)  //Function to be compketed
            {
                if (numOfBlack > numOfWhite)
                {
                    winner = "Black";
                }
                if (numOfBlack < numOfWhite)
                {
                    winner = "White";
                }
                else
                {
                    winner = "Draw";
                }
            }

        }
    } 
}