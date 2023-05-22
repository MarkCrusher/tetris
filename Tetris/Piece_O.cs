using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace Tetris
{
	public class Piece_O : Piece
	{
        public static PieceType pieceType = PieceType.O;
        public Piece_O()
		{
		}

        public void Rotate()
        {
        }

            public int GetNextX(PieceState state, int x, int delta)
        {
            int x_min = 0, x_max = 0;
            int right_border = TetrisGame.BOARD_SIZE_WIDTH - 1;

            x = x + delta;

            // OX
            // XX
            x_min = 0;
            x_max = right_border - 1;


            if (x < x_min) x = x_min;
            if (x > x_max) x = x_max;
            return x;

        }


        public bool CheckBottom(PieceState state, int x, int y, Board board)
        {
            if (hasBottomed(state, x, y, board))
            {
                SetPieceOnBoard(state, x, y, board);

                return true;
            }

            return false;

        }


        public bool hasBottomed(PieceState state, int x, int y, Board board)
        {
            if (y > TetrisGame.BOARD_SIZE_HEIGHT - 3)
            {
                return true;
            }

            // OX
            // XX
            // C
            if (board.squares[x, y + 2] > 0)
                return true;

            // OX
            // XX
            //  C
            if (board.squares[x + 1, y + 2] > 0)
                return true;

            return false;

        }

        public void SetPieceOnBoard(PieceState state, int x, int y, Board board)
        {
            // OX
            // XX
            board.squares[x, y] = pieceType;
            board.squares[x + 1, y] = pieceType;
            board.squares[x + 1, y + 1] = pieceType;
            board.squares[x, y + 1] = pieceType;
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Board board)
        {
            Color color = PieceColor.GetPieceColor(pieceType);
            int x = board.x_piece;
            int y = board.y_piece;
            PieceState state = board.piece_state;

            // OX
            // XX
            graph.DrawSquare(graphicsDevice, spriteBatch, x, y, color);
            graph.DrawSquare(graphicsDevice, spriteBatch, x, y + 1, color);
            graph.DrawSquare(graphicsDevice, spriteBatch, x + 1, y, color);
            graph.DrawSquare(graphicsDevice, spriteBatch, x + 1, y + 1, color);
            
        }

    }
}

