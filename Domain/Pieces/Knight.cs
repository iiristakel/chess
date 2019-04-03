
namespace Domain.Pieces
{
    public class Knight : Piece
    {
        public Knight()
        {
            RowMoves = new[] {2, 2, -2, -2, 1, 1, -1, -1};
            ColMoves = new[] {-1, 1, 1, -1, 2, -2, 2, -2};
            NumOfMoves = 8;
        }
    }
}