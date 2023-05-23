using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
	public interface Piece
	{

        public int GetNextX(PieceState state, int x, int delta);

        public void Rotate();

        public bool HasBottomed(PieceState state, int x, int y, Board board);

        public void SetPieceOnBoard(PieceState state, int x, int y, Board board);

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Board board);
    }
}

