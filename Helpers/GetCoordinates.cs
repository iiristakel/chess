using System;
using Domain;

namespace Helpers
{
    public static class GetCoordinates
    {
        public static int GetXCoord(GameBoard board, string coordinate)
        {
            return board.Letters.IndexOf(coordinate[0]);
        }

        public static int GetYCoord(string coordinate)
        {
            return Int32.Parse(coordinate.Substring(1, coordinate.Length - 1)) - 1;
        }
    }
}