using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Tetris;

namespace Tetris
{
	public class Piece_T
	{
        public static PieceType pieceType = PieceType.T;
        public Piece_T()
		{
		}


        public static int GetNextX(PieceState state, int x, int delta)
        {
            int x_min = 0, x_max =0;
            int right_border = Game1.BOARD_SIZE_WIDTH - 1;

            x = x + delta;

            if (state == PieceState.Up)
            {
                //  X
                // X0X
                x_min = 1;
                x_max = right_border - 1;
            }
            else if (state == PieceState.Right)
            {
                //  X
                //  OX
                //  X
                x_min = 0;
                x_max = right_border - 1;
            }
            else if (state == PieceState.Down)
            {
                // X0X
                //  X
                x_min = 1;
                x_max = right_border - 1;
            }
            else if (state == PieceState.Left)
            {

                //  X
                // XO
                //  X
                x_min = 1;
                x_max = right_border;
            }

            if (x < x_min) x = x_min;
            if (x > x_max) x = x_max;
            return x;

        }


        public static bool CheckBottom(PieceState state, int x, int y, Board board)
        {
            if (Piece_T.hasBottomed(state, x, y, board))
            {

                if (state == PieceState.Up)
                {
                    //  X
                    // X0X
                    board.squares[x, y] = PieceType.T;
                    board.squares[x - 1, y] = PieceType.T;
                    board.squares[x + 1, y] = PieceType.T;
                    board.squares[x, y - 1] = PieceType.T;
                }

                if (state == PieceState.Right)
                {
                    //  X
                    //  OX
                    //  X
                    board.squares[x, y] = PieceType.T;
                    board.squares[x, y - 1] = PieceType.T;
                    board.squares[x + 1, y] = PieceType.T;
                    board.squares[x, y + 1] = PieceType.T;
                }

                if(state == PieceState.Down)
                {
                    // X0X
                    //  X
                    board.squares[x, y] = PieceType.T;
                    board.squares[x - 1, y] = PieceType.T;
                    board.squares[x + 1, y] = PieceType.T;
                    board.squares[x, y + 1] = PieceType.T;
                }

                if (state == PieceState.Left)
                {
                    //  X
                    // XO
                    //  X
                    board.squares[x, y] = PieceType.T;
                    board.squares[x, y - 1] = PieceType.T;
                    board.squares[x - 1, y] = PieceType.T;
                    board.squares[x, y + 1] = PieceType.T;
                }

                return true;


            }

            return false;
      
        }


        public static bool hasBottomed(PieceState state, int x, int y, Board board)
        {
            if (state == PieceState.Up)
            {
                if (y > Game1.BOARD_SIZE_HEIGHT - 2)
                {
                    return true;
                }

                //  X
                // X0X
                //  C
                if (board.squares[x, y + 1] > 0)
                    return true;

                //  X
                // X0X
                // C
                if (board.squares[x-1, y + 1] > 0)
                    return true;


                //  X
                // X0X
                //   C
                if (board.squares[x + 1, y + 1] > 0)
                    return true;
            }

            if (state == PieceState.Right)
            {
                if (y > Game1.BOARD_SIZE_HEIGHT - 3)
                {
                    return true;
                }

                //  X
                //  OX
                //  X
                //  C
                if (board.squares[x, y + 2] > 0)
                    return true;

                //  X
                //  OX
                //  XC
                //  
                if (board.squares[x + 1, y + 1] > 0)
                    return true;
            }

            if (state == PieceState.Down)
            {
                if (y > Game1.BOARD_SIZE_HEIGHT - 3)
                {
                    return true;
                }


                // X0X
                //  X
                //  C
                if (board.squares[x, y + 1] > 0)
                    return true;

                // X0X
                // CX
                //  
                if (board.squares[x - 1, y + 1] > 0)
                    return true;


                // X0X
                //  XC
                //  
                if (board.squares[x + 1, y + 1] > 0)
                    return true;
            }

            if (state == PieceState.Left)
            {
                if (y > Game1.BOARD_SIZE_HEIGHT - 3)
                {
                    return true;
                }

                //  X
                // XO
                //  X
                //  C
                if (board.squares[x, y + 2] > 0)
                    return true;

                //  X
                // XO
                // CX
                //  
                if (board.squares[x - 1, y + 1] > 0)
                    return true;
            }
            return false;

        }

        public static void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, PieceState state, int x, int y)
        {
            Color color = PieceColor.GetPieceColor(Piece_T.pieceType);
            if (state == PieceState.Up)
            {
                //  X
                // X0X
                graph.DrawRect(graphicsDevice, spriteBatch, x, y, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y - 1, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x + 1, y, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x - 1, y, color);
            }
            else if (state == PieceState.Right)
            {
                // X
                // 0X
                // X
     
                graph.DrawRect(graphicsDevice, spriteBatch, x, y - 1, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y + 1, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x + 1, y, color);
            }
            else if (state == PieceState.Down)
            {
                // X0X
                //  X
                graph.DrawRect(graphicsDevice, spriteBatch, x, y, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y + 1, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x + 1, y, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x - 1, y, color);
            }
            else if (state == PieceState.Left)
            {
                //  X
                // X0
                //  X
                graph.DrawRect(graphicsDevice, spriteBatch, x, y - 1, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y + 1, color);
                graph.DrawRect(graphicsDevice, spriteBatch, x - 1, y, color);
            }
        }
    }
}

