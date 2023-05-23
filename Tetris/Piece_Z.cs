using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    public class Piece_Z : PieceBase
    {
        public Piece_Z()
        {
            pieceType = PieceType.Z;
            array2D = new int[,]
            {
                { 1, 1, 0 },
                { 0, 1, 1 },
                { 0, 0, 0 },
            };
            x_center_offset = 1;
            y_center_offset = 1;

        }
    }
}

