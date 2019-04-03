using System.Collections.Generic;
using Domain;
using Domain.Pieces;
using FileSystem;
using Helpers;


namespace ChessSolution
{
    public class Solution
    {
        // Make new gameboard, default measures are 8x8
        private readonly GameBoard _board = new GameBoard();

        // Make new piece, which is wanted to use.
        private readonly Piece _piece = new Knight();

        /// <summary>
        /// Get and set data, find shortest path from start to the end position.
        /// </summary>
        /// <param name="input">Input file.</param>
        /// <returns>Shortest path and amount of moves.</returns>
        public string FindSolution(System.IO.StreamReader input)
        {
            // Get and validate all data from input file.
            ReadFile.GetInfo(input, _board);

            // Set occupied squares.
            SetData.SetGameboard(_board);

            var res = FindShortestPath(_piece);
            return res;
        }


        /// <summary>
        /// Find shortest path from start to the end.
        /// Using BFS algorithm.
        /// </summary>
        /// <param name="piece">Piece which is moving.</param>
        /// <returns>Shortest path and amount of moves.</returns>
        public string FindShortestPath(Piece piece)
        {
            int xCoord = GetCoordinates.GetXCoord(_board, _board.StartPosition);
            int yCoord = GetCoordinates.GetYCoord(_board.StartPosition);

            _board.Squares[xCoord][yCoord].X = xCoord;
            _board.Squares[xCoord][yCoord].Y = yCoord;

            var q = new Queue<Square>();
            q.Enqueue(_board.Squares[xCoord][yCoord]);

            var shortestDist = 0;
            Square endSquare = null;

            while (q.Count > 0)
            {
                var square = q.Dequeue();
                var dist = square.Dist;

                if (square.IsEndPosition)
                {
                    shortestDist = dist;
                    endSquare = square;
                    break;
                }

                square.IsVisited = true;

                // Goes through all possible piece's moves.
                for (int i = 0; i < piece.NumOfMoves; i++)
                {
                    int x = square.X + piece.RowMoves[i];
                    int y = square.Y + piece.ColMoves[i];

                    if (x >= 0 && x < _board.Width && y >= 0 && y < _board.Height && !_board.Squares[x][y].IsBlocked
                        && !_board.Squares[x][y].IsVisited)
                    {
                        _board.Squares[x][y].Dist = dist + 1;
                        _board.Squares[x][y].X = x;
                        _board.Squares[x][y].Y = y;
                        _board.Squares[x][y].Previous = square;

                        q.Enqueue(_board.Squares[x][y]);
                    }
                }
            }

            // Find the path used.
            var squareList = new List<Square>();
            Square current = endSquare;
            var path = "";

            while (!current.IsStartPosition)
            {
                squareList.Add(current);
                current = current.Previous;
            }

            squareList.Reverse();

            foreach (var square in squareList)
            {
                path += _board.Letters.Substring(square.X, 1) + (square.Y + 1) + ", ";
            }

            path = path.Substring(0, path.Length - 2);

            var answer = shortestDist + "\r\n" + path;

            return answer;
        }
    }
}