using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Tetris;

namespace Tetris
{
    public class graph
    {
        public graph()
        {
        }


        static public void DrawSquare(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, int x, int y, Color color)
        {
            Texture2D _texture;
            int xPix = TetrisGame.BOARD_X + TetrisGame.SQUARE_SIDE * x;
            int yPix = TetrisGame.BOARD_Y + TetrisGame.SQUARE_SIDE * y;
            int wPix = TetrisGame.SQUARE_SIDE - TetrisGame.SQUARE_BORDER;
            int hPix = TetrisGame.SQUARE_SIDE - TetrisGame.SQUARE_BORDER;

            if (yPix < TetrisGame.BOARD_Y)
                return;

            Rectangle rect = new Rectangle(xPix, yPix, wPix, hPix);

            _texture = new Texture2D(graphicsDevice, 1, 1);
            _texture.SetData(new Color[] { color });

            spriteBatch.Draw(_texture, rect, color);
        }
    }


}

