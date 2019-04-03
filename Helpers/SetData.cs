using System;
using System.IO;
using Domain;

namespace Helpers
{
    public static class SetData
    {
        /// <summary>
        /// Set start and end positions and already occupied squares into blocked state.
        /// </summary>
        /// <exception cref="InvalidDataException">Occurs when start or end square is marked as occupied.</exception>
        public static void SetGameboard(GameBoard board)
        {
            var endX = GetCoordinates.GetXCoord(board, board.EndPosition);
            var endY = GetCoordinates.GetYCoord(board.EndPosition);
            
            var startX = GetCoordinates.GetXCoord(board, board.StartPosition);
            var startY = GetCoordinates.GetYCoord(board.StartPosition);
            
            board.Squares[endX][endY].IsEndPosition = true;
            board.Squares[startX][startY].IsStartPosition = true;

            foreach (var coord in board.OccupiedSquares)
            {
                if (coord.Equals(board.StartPosition) || coord.Equals(board.EndPosition))
                {
                    throw new InvalidDataException("Start or end coordinate \"" + coord +
                                                   "\"cannot be already occupied!");
                }

                int x = GetCoordinates.GetXCoord(board, coord);
                int y = GetCoordinates.GetYCoord(coord);

                board.Squares[x][y].IsBlocked = true;
            }
        }
    }
}