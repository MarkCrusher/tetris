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


        static public void DrawRect(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, int x, int y, Color color)
        {
            Texture2D _texture;
            Rectangle Rect = new Rectangle(Game1.SQUARE_SIDE * x, Game1.SQUARE_SIDE * y, Game1.SQUARE_SIDE - Game1.SQUARE_BOARDER, Game1.SQUARE_SIDE - Game1.SQUARE_BOARDER);

            _texture = new Texture2D(graphicsDevice, 1, 1);
            _texture.SetData(new Color[] { color });

            spriteBatch.Draw(_texture, Rect, color);
        }
    }


}

