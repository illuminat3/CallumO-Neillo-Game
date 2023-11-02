/* Copyright © 2014 Dr Peter O’Neill Sheffield Hallam University.
 * Updated in 2023 to improve readability, bring the language closer to the the current nomenclature 
 * and introduce the Point class and a custom exception class.
 * 
 * This Class, places a grid of images onto the sent Form with the images referenced in the cardArray, 
 * you place top and left, it calculates the same distance for right and bottom, giving a spacing 
 * between the images of Border. The ImagePath is relevant to the executional application.
 * 
 * On the main form, where the class is instantiated you need the following line and its eventhandler:
 * 
 * <GameBoardImageArray Variable>.TileClicked += new GameBoardImageArray.TileClickedEventDelegate(GameTileClicked);
 * 
 * Where "GameTileClicked" is the evethandler inside the parent form with a method header: 
 * private void GameTileClicked(object sender, EventArgs e)
 * 
 * Of course you can give your event handler a different name, but it must return void and accept 
 * an object as the first parameter and an EventArgs as the second parameter.
*/

namespace GameboardGUI
{
    public class GameboardImageArray : UserControl
    {
        /// <summary>
        /// A delegate class to represent the event that will be raised each time a tile is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void TileClickedEventDelegate(object sender, EventArgs e);

        /// <summary>
        /// An instance of the delegate, which will be used to raise an event each time a tile is clicked on the GameBoardImageArray.
        /// 
        /// To use it, create an event handler inside the parent form with a header similar to
        /// private void TileHasBeenClicked(object sender, EventArgs e)
        /// This event handler inside the form is the one that handles the events raised within 
        /// GameBoardImageArray when a tile is clicked.
        /// </summary>
        public event TileClickedEventDelegate TileClicked;


        private int _topY, _topX, _boardRows, _boardCols, _tileMargin, _tileWidth, _tileHeight;
        private PictureBox[,] _boardTiles;
        private Form _containingForm;
        private string _tileImagesPath;

        /// <summary>
        /// GImageArray is the constructor and generates an Array of Images from an int array sent to it. 
        /// </summary>
        /// <param name="parentForm">This is the Windows Forms object on which the gameboard tiles will be displayed.</param>
        /// <param name="gameBoardStateArray">The int Array of game state data</param>
        /// <param name="topY">The position of the top left corner of the game board relative to the parentForm's top border</param>
        /// <param name="topX">The position of the top left corner of the game board relative to the parentForm's left border</param>
        /// <param name="bottomY">The position of the bottom right corner of the game board relative to the parentForm's bottom border</param>
        /// <param name="bottomX">The position of the bottom right corner of the game board relative to the parentForm's right border</param>
        /// <param name="tileMargin">The gap between each image, e.g., Top, Left, Right and Bottom </param>
        /// <param name="tileImagePath">The literal path to each image</param>
        public GameboardImageArray(Form parentForm, int[,] gameBoardStateArray, Point topCorner, 
            Point bottomCorner, int tileMargin, string tileImagePath) {
            _containingForm = parentForm;
            _boardRows = gameBoardStateArray.GetLength(0);
            _boardCols = gameBoardStateArray.GetLength(1);

            // Calculate the available Height for the game board, based on the size of the parent form and provided board parameters
            int boardHeight = parentForm.ClientSize.Height - ((topCorner.Y + bottomCorner.Y) + (tileMargin * _boardCols - 1));
            // Calculate the available Width for the game board, based on the size of the parent form and provided board parameters
            int boardWidth = parentForm.ClientSize.Width - ((topCorner.X + bottomCorner.X) + (tileMargin * _boardRows - 1));
            _topY = topCorner.Y;
            _topX= topCorner.X;
            this._tileMargin = tileMargin;
            _tileImagesPath = tileImagePath;

            _tileWidth = ComputeTileWidth(boardWidth);
            _tileHeight = ComputeTileHeight(boardHeight);

            // Check if the game board GUI is large enough. Throw a GameBoardImageArraySizeException if the board is too small
            if ((_tileWidth < 5) || (_tileHeight < 5))
            {
                string exceptionMessage = "The Images requested will be to small." +
                    "\rPlease increase the window size or reduce the number of elements required!";
                throw new GameboardImageArraySizeException(exceptionMessage);
            }
            else
            {
                _boardTiles = new PictureBox[_boardRows, _boardCols];

                RenderGameStateToGui(parentForm, gameBoardStateArray);
            }
        }
        /// <summary>
        /// Destructor, Removes the images from the Form and dispose of them before disposing of itself
        /// </summary>
        ~GameboardImageArray()
        {
            for (int r = 0; r < _boardRows; r++)
            {
                for (int c = 0; c < _boardCols; c++)
                {
                    _containingForm.Controls.Remove(_boardTiles[r, c]);
                    _boardTiles[r, c].Dispose();
                }
            }
        }
        
        /// <summary>
        /// Updates the Game Board display based on the gameboard state data array parameter
        /// </summary>
        /// <param name="gameStateArray"> The array containing the current game state.</param>
        public void UpdateBoardGui(int[,] gameStateArray)
        {
            for (int r = 0; r < _boardRows; r++)
            {
                for (int c = 0; c < _boardCols; c++)
                {
                    _boardTiles[r, c].ImageLocation = _tileImagesPath + gameStateArray[r, c].ToString() + ".PNG";
                }
            }
        }
        
        /// <summary>
        /// Returns the index of the Column, of the selected object, e.g., the images clicked on by the mouse
        /// </summary>
        /// <param name="sender">The object selected within the grid array</param>
        /// <returns>index of the column where the object is stored in the array</returns>
        public int GetCurrentColumnIndex(object sender)
        {
            for (int r = 0; r < _boardRows; r++)
            {
                for (int c = 0; c < _boardCols; c++)
                {
                    // Check if the sender is the same object as this object in the array
                    if (sender == _boardTiles[r, c])
                    {
                        return c;
                    }
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns the index of the Row, of the selected object, e.g., the images clicked on by the mouse
        /// </summary>
        /// <param name="sender"> The object selected within the grid array</param>
        /// <returns>index of the row where the object is stored in the array</returns>
        public int GetCurrentRowIndex(object sender)
        {
            for (int r = 0; r < _boardRows; r++)
            {
                for (int c = 0; c < _boardCols; c++)
                {
                    if (sender == _boardTiles[r, c])
                    {
                        return r;
                    }
                }
            }
            return -1;
        }
       
        /// <summary>
        /// GetTile is passed the row and column indices and returns the 
        /// PictureBox at the indexed location
        /// </summary>
        /// <param name="row">row index of the element</param>
        /// <param name="col">column index of the element</param>
        /// <returns>The PictureBox</returns>
        public PictureBox GetTile(int row, int col)
        {
            return _boardTiles[row, col];
        }
        
        /// <summary>
        /// SetTile sets the image at the specified row and column index to the image specified by imageName
        /// </summary>
        /// <param name="row">index Row of the element</param>
        /// <param name="col">index Column of the element</param>
        /// <param name="imageName">The name of the PNG file to be used without the .png extension included in the name.</param>
        /// <returns></returns>
        public bool SetTile(int row, int col, string imageName)
        {
            _boardTiles[row, col].ImageLocation = _tileImagesPath + imageName + ".PNG";
            return true;
        }
        
        /// <summary>
        /// Changes all images within the array to Red.png or Blue.png.
        /// Use this to change all the tiles to Red or Blue.
        /// These files must be present at default image location provided to the class constructor.
        /// When tileColor is not specified or an invalid tileColor value (not Red of Blue) is used, it defaults to Blue.
        /// </summary>
        /// <param name="tileColor">This is the filename stored within the default image location e.g. Red or Blue</param>
        public void ToRedOrBlueBoard(string tileColor = "Blue")
        {
            switch(tileColor[0].ToString().ToLower())
            {
                case "r": tileColor = "Red";
                    break;
                case "b": tileColor = "Blue";
                    break;
                default: tileColor = "Blue";
                    break;
            }
            for (int r = 0; r < _boardRows; r++)
            {
                for (int c = 0; c < _boardCols; c++)
                {
                    _boardTiles[r, c].ImageLocation = _tileImagesPath + tileColor + ".PNG";
                }
            }

        }

        /// <summary>
        /// This method Shows the  image stated within the sent array in it location.
        /// </summary>
        /// <param name="updateArray">The int 2D array</param>
        /// <param name="row">The row index that needs to be updated/displayed</param>
        /// <param name="c">The col index that needs to be updated/displayed</param>
        /// <returns>Return True if it succeeds and False if it does not.</returns>
        public bool ShowElement(int[,] updateArray, int row, int c)
        {
            // Checks to see if requested element is within the boundaries
            if ((row < _boardRows) && (c < _boardCols))
            {
                _boardTiles[row, c].ImageLocation = _tileImagesPath + updateArray[row, c].ToString() + ".PNG";
                return true;
            }            
                
            return false;
        }
        
        /// <summary>
        /// This method update the location of the images within the frame as the frame changes sizes.
        /// </summary>
        public void UpdateLocation()
        {
            // Calculate the Height of each element related to the size of the Form and number required
            int Available_Height = _containingForm.ClientSize.Height - ((Top + Bottom) + (_tileMargin * _boardCols - 1));
            // Calculate the Width of each element related to the size of the Form and number required
            int Available_Width = _containingForm.ClientSize.Width - ((Left + Right) + (_tileMargin * _boardRows - 1));
            _topY = Top;
            _topX = Left;

            for (int r = 0; r < _boardRows; r++)
            {
                for (int c = 0; c < _boardCols; c++)
                {
                    int l = _topX;
                    if (c > 0)
                        l = l + (_tileWidth * c) + (_tileMargin * c);
                    int t = _topY;
                    if (r > 0)
                        t = t + (_tileHeight * r) + (_tileMargin * r);
                    _boardTiles[r, c].Location = new Point(l, t);
                    _boardTiles[r, c].Size = new Size(_tileWidth, _tileHeight);
                }
            }
        }

        /// <summary>
        /// This method displays the gameState on the GUI
        /// </summary>
        /// <param name="parentForm"></param>
        /// <param name="gameStateArray"></param>
        private void RenderGameStateToGui(Form parentForm, int[,] gameStateArray)
        {
            for (int r = 0; r < _boardRows; r++)
            {
                for (int c = 0; c < _boardCols; c++)
                {
                    int l = _topX;
                    if (c > 0)
                        l = l + (_tileWidth * c) + (_tileMargin * c);
                    int t = _topY;
                    if (r > 0)
                        t = t + (_tileHeight * r) + (_tileMargin * r);
                    _boardTiles[r, c] = new PictureBox();
                    _boardTiles[r, c].SizeMode = PictureBoxSizeMode.StretchImage;
                    _boardTiles[r, c].Location = new Point(l, t);
                    _boardTiles[r, c].Size = new Size(_tileWidth, _tileHeight);
                    _boardTiles[r, c].ImageLocation = _tileImagesPath + gameStateArray[r, c].ToString() + ".PNG";
                    _boardTiles[r, c].Click += new EventHandler(TileClickListener);
                    _containingForm.Controls.Add(_boardTiles[r, c]);
                }
            }
        }

        /// <summary>
        /// This method is registered to listen to the click event on each tile 
        /// and raise the event that will be handled by the parent form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TileClickListener(object sender, EventArgs e)
        {
            // Delegate the event to the caller
            if (this != null)
                TileClicked(sender, e);
        }

        private int ComputeTileHeight(int boardHeight)
        {
            int tileHeight = boardHeight/_boardCols;
            return tileHeight;
        }
        
        private int ComputeTileWidth(int boardWidth)
        {
            int tileWidth = boardWidth/_boardRows;
            return tileWidth;
        }
    }

    public class GameboardImageArraySizeException: Exception
    {
        public GameboardImageArraySizeException() : base() { }
        public GameboardImageArraySizeException(string message) : base(message) { }
        public GameboardImageArraySizeException(string message, Exception inner) : base(message, inner) { }

    }
}