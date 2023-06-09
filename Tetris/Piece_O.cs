using System;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    public class Piece_O : PieceBase
    {
        public Piece_O()
        {
            pieceType = PieceType.O;
            array2D = new int[,]
            {
                { 1, 1, 0 },
                { 1, 1, 0 },
                { 0, 0, 0 },
            };
            x_center_offset = 0;
            y_center_offset = 0;

        }

        public override void Rotate()
        {
            // Console.WriteLine("Piece_O Rotate");
            // The O piece does not need to be rotated.

        }
    }
}

