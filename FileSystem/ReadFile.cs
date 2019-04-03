using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Domain;

namespace FileSystem
{
    public static class ReadFile
    {
        /// <summary>
        /// Get info from input file, validate it and assign info to board properties.
        /// </summary>
        /// <param name="input">Input file.</param>
        /// <param name="board">Gameboard</param>
        public static void GetInfo(System.IO.StreamReader input, GameBoard board)
        {

            board.StartPosition = ValidateCoordinate(input.ReadLine(), board);
            board.EndPosition = ValidateCoordinate(input.ReadLine(), board);
            
            string[] listOfOccupiedSquares = input.ReadLine()?.Split(',');

            if (listOfOccupiedSquares != null)
                foreach (var square in listOfOccupiedSquares)
                {
                    board.OccupiedSquares.Add(ValidateCoordinate(square, board));
                }

            input.Close();
        }

        /// <summary>
        /// Validate that coordinate is not empty and is inside gameboard's measures.
        /// </summary>
        /// <param name="coordinate">Coordinate</param>
        /// <param name="board">Gameboard</param>
        /// <returns>Validated coordinate.</returns>
        /// <exception cref="InvalidDataException">Occurs when coordinate is not valid.</exception>
        private static string ValidateCoordinate(string coordinate, GameBoard board)
        {
            coordinate = coordinate.Trim().ToUpper();
            
            if (!string.IsNullOrEmpty(coordinate)
                && board.Letters.Substring(0, board.Width)
                    .Contains(coordinate.Substring(0, 1))
                && Int32.Parse(coordinate.Substring(1, coordinate.Length - 1)) <= board.Height)
            {
                return coordinate;
            }

            throw new InvalidDataException("Coordinates must be letter + number! You wrote: \"" + coordinate + "\"");
        }
    }
}