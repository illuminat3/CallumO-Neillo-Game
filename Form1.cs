using GameboardGUI;
using System.Data.Common;
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
        int player = 1;

        string imagepaths = "C:\\Users\\CallumCunningham\\source\\repos\\Oneillo_2\\resources\\";
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

            GameEnded();
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
                    player = 1;
                }
                if (gameMoves % 2 != 0)
                {
                    _gameboardGui.SetTile(RowCLicked, ColumnClicked, 1.ToString());
                    player = 2;
                }
            }
        }

        private void Validator(int row, int col, int changeInRow, int changeInCol)
        {
            int trueCount = 0;
            //here we are making lists containing the rows and the columns that need colouring in
            List<int> validRow = new List<int>();
            List<int> validCol = new List<int>();

            validRow.Add(row);
            validCol.Add(col);
            //adding the change in direction to the row to be checked
            row += changeInRow;
            col += changeInCol;
            //a bool for if the same counter as the player is met - helps with the validation
            bool sameCounterFound;
            sameCounterFound = false;


            //we need to make a while in the bounds of the array so that an error isnt thrown
            while ((row >= 0) && (row < 8) && (col >= 0) && (col < 8))
            {
                //we need to go through each item in the row/col/diagonal in array but we
                //need to make sure they are not green or the colour of the player
                if (boardData[row, col] == player)
                {
                    sameCounterFound = true;
                    break;
                }
                if (boardData[row, col] == 10)
                {
                    break;
                }
                //adding to a list of valid moves which I can later go through-- ones that need colouring
                //the list will only be gone through if the move is valid
                validRow.Add(row);
                validCol.Add(col);

                row += changeInRow;
                col += changeInCol;
                trueCount++;
            }

            if ((trueCount >= 1) && (sameCounterFound == true))
            {
                for (int countNumber = 0; countNumber < validRow.Count; countNumber++)
                {
                    boardData[validRow[countNumber], validCol[countNumber]] = player;
                }
                _gameboardGui.UpDateImages(boardData);
                legalMove = true;
            }
        }



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
            return;
        }

        private void GameEnded()
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