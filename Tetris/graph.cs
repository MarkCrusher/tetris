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
            Rectangle rect = new Rectangle(TetrisGame.SQUARE_SIDE * x, TetrisGame.SQUARE_SIDE * y, TetrisGame.SQUARE_SIDE - TetrisGame.SQUARE_BOARDER, TetrisGame.SQUARE_SIDE - TetrisGame.SQUARE_BOARDER);

            _texture = new Texture2D(graphicsDevice, 1, 1);
            _texture.SetData(new Color[] { color });

            spriteBatch.Draw(_texture, rect, color);
        }
    }


}

