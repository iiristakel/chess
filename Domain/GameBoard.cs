using System;
using System.Collections.Generic;
using System.IO;

namespace Domain
{
    public class GameBoard
    {
        public int Width { get; set; }
        public int Height { get; set; }
        public List<List<Square>> Squares { get; set; } = new List<List<Square>>();
        public string StartPosition { get; set; }
        public string EndPosition { get; set; }

        // Squares which are already occupied by other pieces.
        public List<string> OccupiedSquares { get; set; } = new List<string>();

        // All letters that can be used for horizontal coordinates, maximum is 26.
        public string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";


        /// <summary>
        /// Constructor for gameboard.
        /// Adds new lists of squares and new empty squares into lists. 
        /// </summary>
        /// <param name="width">Gameboard width.</param>
        /// <param name="height">Gameboard height.</param>
        /// <exception cref="InvalidDataException">Occurs when chosen measures are not valid.</exception>
        public GameBoard(int width = 8, int height = 8)
        {
            Width = width;
            Height = height;

            if (Width < 5 || Width > 26 || Height < 5 || Height > 26)
            {
                throw new InvalidDataException("Width and height must be between 5 and 26! " +
                                               "You chose: \"width: " + Width + "\" and \"height: " + Height + "\"!");
            }

            for (int i = 0; i < height; i++)
            {
                Squares.Add(new List<Square>());
                for (int j = 0; j < width; j++)
                {
                    Squares[i].Add(new Square());
                }
            }
        }
    }
}