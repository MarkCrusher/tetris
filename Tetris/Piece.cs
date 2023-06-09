using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
	public interface Piece
	{

        public int GetNextX(int x, int delta);

        public void Rotate();

        public bool HasBottomed(int x, int y, Board board);

        public void SetPieceOnBoard( int x, int y, Board board);

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Board board);
    }
}

