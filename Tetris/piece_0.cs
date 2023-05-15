using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Tetris;

namespace Tetris
{
	public class Piece_0
	{
		public Piece_0()
		{
		}


        public static int GetNextX(int state, int x, int delta)
        {
            x = x + delta;
            if (state == 0)
            {
                if (x < 0) x = 0;
                if (x > Game1.BOARD_SIZE_WIDTH-2) x = Game1.BOARD_SIZE_WIDTH-2;
            }
            else if (state == 1)
            {
                if (x < 1) x = 1;
                if (x > Game1.BOARD_SIZE_WIDTH - 2) x = Game1.BOARD_SIZE_WIDTH - 2;
            }
            else if (state == 2)
            {
                if (x < 1) x = 1;
                if (x > Game1.BOARD_SIZE_WIDTH - 1) x = Game1.BOARD_SIZE_WIDTH - 1;
            }
            else if (state == 3)
            {
                if (x < 1) x = 1;
                if (x > Game1.BOARD_SIZE_WIDTH - 2) x = Game1.BOARD_SIZE_WIDTH - 2;
            }
            return x;

        }


        public static bool CheckBottom(int state, int x, int y, Board board)
        {
            if (state == 3)
            {
                if (y > Game1.BOARD_SIZE_HEIGHT-2)
                {
          
                    board.squares[x,y] = 1;
                    board.squares[x-1, y] = 1;
                    board.squares[x + 1, y] = 1;
                    board.squares[x, y - 1] = 1;
                    return true;

                }
            }
            return false;
      
        }

            public static void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, int state, int x, int y)
        {
            if (state == 0)
            {
                // X
                // 0X
                // X
     
                graph.DrawRect(graphicsDevice, spriteBatch, x, y - 1, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y + 1, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x + 1, y, Color.Blue);
            }
            else if (state == 1)
            {
                // X0X
                //  X
                graph.DrawRect(graphicsDevice, spriteBatch, x, y, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y + 1, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x + 1, y, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x - 1, y, Color.Blue);
            }
            else if (state == 2)
            {
                //  X
                // X0
                //  X
                graph.DrawRect(graphicsDevice, spriteBatch, x, y - 1, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y + 1, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x - 1, y, Color.Blue);
            }
            else if (state == 3)
            {
                //  X
                // X0X
                graph.DrawRect(graphicsDevice, spriteBatch, x, y, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x, y - 1, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x + 1, y, Color.Blue);
                graph.DrawRect(graphicsDevice, spriteBatch, x - 1, y, Color.Blue);
            }

        }
    }
}

