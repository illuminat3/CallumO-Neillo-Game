using GameboardGUI;

namespace Oneillo_2
{
    public partial class Form1 : Form
    {
        GameboardImageArray _gameboardGui;

        const int rows = 8, columns = 8;
        int[,] boardData;
        int gameMoves = 1; // implement this in the GUI
        int numOfBlack, numOfWhite;
        int player = 2;

        string imagepaths = $"{Environment.CurrentDirectory}\\resources\\";
        string winner;  // implement this in the GUI

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
                _gameboardGui.UpdateBoardGui(boardData);
            }
            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show("Board Size Too Small! ");  // checks for excpetion
                this.Close();
            }
            AddOutline();
        }
        // CLick Listener 


        private bool IsAnyMoveValid(int rowClicked, int columnClicked, int player)
        {
            if (boardData[rowClicked, columnClicked] != 0)
            {
                return false; // If the tile is not empty, it's not a valid move
            }

            int opponent = 3 - player; // Opponent's color

            (int x, int y)[] OFFSETS =
            {
                (1, 0), (1, 1),
                (0, 1), (-1, 0),
                (0, -1), (1, -1),
                (-1, 1), (-1, -1)
            };

            bool isAnyMovePossible = false;

            foreach (var offset in OFFSETS)
            {
                int changeInRow = offset.x;
                int changeInCol = offset.y;

                int row = rowClicked + changeInRow;
                int col = columnClicked + changeInCol;

                bool validDirection = false;

                while (row >= 0 && row < rows && col >= 0 && col < columns)
                {
                    if (boardData[row, col] == player)
                    {
                        validDirection = true;
                        break;
                    }
                    else if (boardData[row, col] == 0 || boardData[row, col] == 3) // 3 could represent valid moves
                    {
                        break;
                    }

                    row += changeInRow;
                    col += changeInCol;
                }

                if (validDirection)
                {
                    // Check if the opponent's counters can be flanked

                    row -= changeInRow;
                    col -= changeInCol;

                    while (row != rowClicked || col != columnClicked)
                    {
                        if (boardData[row, col] == opponent)
                        {
                            isAnyMovePossible = true;
                            break;
                        }

                        row -= changeInRow;
                        col -= changeInCol;
                    }

                    if (isAnyMovePossible)
                    {
                        break; // Break out if any direction is valid
                    }
                }
            }

            return isAnyMovePossible;
        }

        public void GameEnded()
        {
            bool hasLegalMoves = false;

            // Check for any empty spaces and legal moves
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (_gameboardGui.GetTile(row, col).ImageLocation.EndsWith("3.PNG"))
                    {
                        hasLegalMoves = true;
                        break;
                    }
                }
            }

            // Game end conditions
            if (hasLegalMoves)
            {
                return;
            }
            else
            {
                // Calculate the number of black and white pieces
                CheckNumPieces();

                if (numOfBlack > numOfWhite)
                {
                    winner = "Black";
                    MessageBox.Show("Black Wins! with " + numOfBlack + " counters!");
                }
                else if (numOfBlack < numOfWhite)
                {
                    winner = "White";
                    MessageBox.Show("White Wins! with " + numOfWhite + " counters!");
                }
                else
                {
                    winner = "Draw";
                    MessageBox.Show("Draw!");
                }
            }
        }


        public void AddOutline()
        {
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (IsAnyMoveValid(row, col, player))
                    {
                        _gameboardGui.SetTile(row, col, 3.ToString());
                    }
                }
            }
        }

        public void FlipValidCounters(int row, int col, int player)
        {
            (int x, int y)[] OFFSETS =
            {
                (1, 0), (1, 1),
                (0, 1), (-1, 0),
                (0, -1), (1, -1),
                (-1, 1), (-1, -1)
            };

            int opponent = 3 - player; // Assuming 1 for black, 2 for white

            foreach (var offset in OFFSETS)
            {
                int changeInRow = offset.x;
                int changeInCol = offset.y;

                int r = row + changeInRow;
                int c = col + changeInCol;

                bool flipped = false;

                while (r >= 0 && r < rows && c >= 0 && c < columns && boardData[r, c] == opponent)
                {
                    r += changeInRow;
                    c += changeInCol;
                    flipped = true;
                }

                if (flipped && r >= 0 && r < rows && c >= 0 && c < columns && boardData[r, c] == player)
                {
                    // Flip the opponent's tiles
                    int flipR = row + changeInRow;
                    int flipC = col + changeInCol;

                    while (flipR != r || flipC != c)
                    {
                        boardData[flipR, flipC] = player;
                        flipR += changeInRow;
                        flipC += changeInCol;
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
                    if (boardData[row, col] == 3)
                    {
                        _gameboardGui.SetTile(row, col, 0.ToString());
                    }
                }
            }
        }

        private void CheckNumPieces()
        {
            numOfBlack = 0;
            numOfWhite = 0;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (boardData[row, col] == 1)
                    {
                        numOfBlack = numOfBlack + 1;
                    }
                    if (boardData[row, col] == 2)
                    {
                        numOfWhite = numOfWhite + 1;
                    }
                }
            }
        }

        public void GameTileClicked(object sender, EventArgs e)
        {
            int RowClicked = _gameboardGui.GetCurrentRowIndex(sender);
            int ColumnClicked = _gameboardGui.GetCurrentColumnIndex(sender);

            gameMoves += 1;

            // Clear previous legal moves
            ClearPreviousLegalMoves();

            // Check if the clicked tile is a valid move for the current player
            if (IsAnyMoveValid(RowClicked, ColumnClicked, player))
            {
                // Update the board with the player's move
                boardData[RowClicked, ColumnClicked] = player;

                // Flip counters
                FlipValidCounters(RowClicked, ColumnClicked, player);

                _gameboardGui.UpdateBoardGui(boardData);

                // Switch players
                player = 3 - player; // Assuming 1 for black, 2 for white
            }

            // Add outlines for valid moves for the next player
            CheckNumPieces();
            AddOutline();
            GameEnded();
        }


        void ForfeitGame()  //Function to be completed
        {
            _gameboardGui.Dispose();
            InitializeComponent();
        }

        private void PlayerOneName_TextChanged(object sender, EventArgs e)
        {

        }


        //       private void PlayerOnePieceLbl_Click(object sender, EventArgs e)
        //       {
        //           PlayerOnePieceLbl.Text = numOfBlack.ToString() + " Black Pieces ";
        //       }
        //
        //       private void PlayerTwoPieceLbl_Click(object sender, EventArgs e)
        //       {
        //           PlayerTwoPieceLbl.Text = numOfWhite.ToString() + " White Pieces ";
        //       }


    }
}