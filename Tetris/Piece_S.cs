using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    public class Piece_S : PieceBase
    {
        public Piece_S()
        {
            pieceType = PieceType.S;
            array2D = new int[,]
            {
                { 0, 1, 1 },
                { 1, 1, 0 },
                { 0, 0, 0 },
            };
            x_center_offset = 1;
            y_center_offset = 1;

        }
    }
}

