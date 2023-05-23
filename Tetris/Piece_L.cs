using System;
namespace Tetris
{
	public class Piece_L : PieceBase
	{
		public Piece_L()
		{
            pieceType = PieceType.L;
            array2D = new int[,]
            {
                { 0, 0, 1 },
                { 1, 1, 1 },
                { 0, 0, 0 },
            };
            x_center_offset = 1;
            y_center_offset = 1;
        }
	}
}

