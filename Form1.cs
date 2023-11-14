using GameboardGUI;
using System.Numerics;
using System.Reflection.Metadata.Ecma335;

namespace Oneillo_2
{
    public partial class Form1 : Form
    {
        GameboardImageArray _gameboardGui;

        const int rows = 8, columns = 8;
        int[,] boardData;
        int gameMoves = 0;
        int row, col, changeInRow, changeInCol;
        int numOfBlack, numOfWhite;

        string imagepaths = "C:\\Users\\CallumCunningham\\source\\repos\\Oneillo_2\\resources\\";
        string player;
        string winner;

        bool moveIsPossible;
        bool legalMove;
        bool black = true;
        bool isAnyMovePossible;

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


        }
        // CLick Listener 
        public void GameTileClicked(object sender, EventArgs e)
        {
            gameMoves++;
            int RowCLicked = _gameboardGui.GetCurrentRowIndex(sender);
            int ColumnClicked = _gameboardGui.GetCurrentColumnIndex(sender);

            if (boardData[RowCLicked, ColumnClicked] == 0)
            {
                if (gameMoves % 2 == 0)
                {
                    _gameboardGui.SetTile(RowCLicked, ColumnClicked, 2.ToString());
                    player = "Black";
                }
                else
                {
                    _gameboardGui.SetTile(RowCLicked, ColumnClicked, 1.ToString());
                    player = "Orange";  

                }
            }
            
                 IsAnyMoveValid(row, col, changeInRow, changeInCol, isAnyMovePossible);
                 IsGameFinished(numOfBlack, numOfWhite);
        }


        private bool IsAnyMoveValid(int row, int col, int changeInRow, int changeInCol, bool isAnyMovePossible)
        {
            int trueCount = 0;

            List<int> validRow = new List<int>();
            List<int> validCol = new List<int>();

            validRow.Add(row);
            validCol.Add(col);

            row += changeInRow;
            col += changeInCol;

            bool sameCounterFound = false;

            while ((row >= 0) && (row < 8) && (col >= 0) && (col < 8))
            {

                if (boardData[row, col] == gameMoves)
                {
                    sameCounterFound = true;
                    break;
                }
                if (boardData[row, col] == 10)
                {
                    break;
                }

                validRow.Add(row);
                validCol.Add(col);

                //validMoveArray[row, col] = 3;


                row += changeInRow;
                col += changeInCol;
                trueCount++;
            }


            if ((trueCount >= 1) && (sameCounterFound == true))
            {
                isAnyMovePossible = true;
            }

            _gameboardGui.UpdateBoardGui(validMoveArray);
    //       return isAnyMovePossible;
        }


        public void IsGameFinished(int numOfBlack, int numOfWhite)
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
            for (int row = 0; row <= 7; row++)
            {
                for (int col = 0; col <= 7; col++)
                {
                    if (boardData[row, col] == 10)
                    {
                        isAnyMovePossible = IsAnyMoveValid(row, col, 0, 1, isAnyMovePossible);
                        if (isAnyMovePossible) _gameboardGui.SetTile(row, col + 1, 3.ToString());
                        isAnyMovePossible = IsAnyMoveValid(row, col, 1, -1, isAnyMovePossible);
                        isAnyMovePossible = IsAnyMoveValid(row, col, -1, 1, isAnyMovePossible);
                        isAnyMovePossible = IsAnyMoveValid(row, col, 0, -1, isAnyMovePossible);
                        isAnyMovePossible = IsAnyMoveValid(row, col, 1, 0, isAnyMovePossible);
                        isAnyMovePossible = IsAnyMoveValid(row, col, -1, 0, isAnyMovePossible);
                        isAnyMovePossible = IsAnyMoveValid(row, col, -1, -1, isAnyMovePossible);
                        isAnyMovePossible = IsAnyMoveValid(row, col, 1, 1, isAnyMovePossible);

                       

                    }
                }

            }
            _gameboardGui.UpdateBoardGui(validMoveArray);

            //if gameNotWon is not equal to true(IF THE GAME HAS BEEN WON)
            if ((gameNotWonByFullBoard != true) || (gameNotWonByNoCounters != true))
                WinnerCheck(numOfBlack, numOfWhite);

            else if (isAnyMovePossible == false)
                ForfeitGame();

            else
                return;
        }
        
        private void ForfeitGame()  //Function to be completed
        {
            return;
        }

        private void WinnerCheck(int numOfBlack, int numOfWhite)  //Function to be compketed
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