using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris
{
	public class Board
	{
        public int x_piece = Game1.BOARD_SIZE_WIDTH / 2;
        public int y_piece = 0;
        public int piece_state = 0;
        public int[,] squares = new int[Game1.BOARD_SIZE_WIDTH, Game1.BOARD_SIZE_HEIGHT];

        public Board()
		{
            InitBoard();
		}

		private void InitBoard()
		{
            for (int x = 0; x < Game1.BOARD_SIZE_WIDTH; x++)
            {
                for (int y = 0; y < Game1.BOARD_SIZE_HEIGHT; y++)
                {
                    squares[x,y] = 0;
                }
            }
        }

        public bool DropOneDown()
        {
            y_piece++;
            if (y_piece > Game1.BOARD_SIZE_HEIGHT-1)
            {
                y_piece = 0;
            }

            return CheckBottom();
        }

        public void DropAllTheWay()
        {
            while (!DropOneDown());
        }

        public void MoveRight()
        {
            x_piece = Piece_0.GetNextX(piece_state, x_piece, 1);
        }

        public void MoveLeft()
        {
            x_piece = Piece_0.GetNextX(piece_state, x_piece, -1);
        }

        public void Rotate()
        {
            piece_state = (piece_state + 1) % 4;
            x_piece = Piece_0.GetNextX(piece_state, x_piece, 0);
        }

        public bool CheckBottom()
        {
            return Piece_0.CheckBottom(piece_state, x_piece, y_piece, this);
        }




    }
}

