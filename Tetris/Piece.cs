using System;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
	public interface Piece
	{

        public int GetNextX(PieceState state, int x, int delta);

        public bool CheckBottom(PieceState state, int x, int y, Board board);

        public bool hasBottomed(PieceState state, int x, int y, Board board);

        public void SetPieceOnBottom(PieceState state, int x, int y, Board board);

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Board board);
    }
}

