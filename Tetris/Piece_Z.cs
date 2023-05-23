using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    public class Piece_Z : Piece
    {
        public static PieceType pieceType = PieceType.Z;

        int[,] array2D = new int[,]
        {
            { 1, 1, 0 },
            { 0, 1, 1 },
            { 0, 0, 0 },
        };
        int x_center_offset = 1;
        int y_center_offset = 1;

        public Piece_Z()
        {
        }


        public void Rotate()
        { 
            array2D = Utils.RotateMatrix90DegreesClockwise(array2D);
        }


        public int GetNextX(PieceState state, int x, int delta)
        {
            int x_min = 0;
            int right_border = TetrisGame.BOARD_SIZE_WIDTH - 1;


            int newX = x + delta;

            for (int row = 0; row < array2D.GetLength(0); row++) // Loop over rows
            {
                for (int col = 0; col < array2D.GetLength(1); col++) // Loop over columns in a row
                {
                    int element = array2D[row, col];
                    if (element > 0)
                    {
                        int effectiveX = col + x - x_center_offset;

                        int proposedX = effectiveX + delta;

                        if (proposedX < x_min) {
                            newX = x_min + x_center_offset;
                            return newX;
                        }
                        if (proposedX > right_border)
                        {
                            newX = right_border - x_center_offset;
                            return newX;
                        }
                    }
                }
            }

            return newX;
        }


        public bool HasBottomed(PieceState state, int x, int y, Board board)
        {
            const int y_max = TetrisGame.BOARD_SIZE_HEIGHT - 1;

            for (int row = 0; row < array2D.GetLength(0); row++) // Loop over rows
            {
                for (int col = 0; col < array2D.GetLength(1); col++) // Loop over columns in a row
                {
                    int element = array2D[row, col];
                    if (element > 0)
                    {
                        int effectiveX = col + x - x_center_offset;
                        int effectiveY = row + y - y_center_offset;

                        // Check if it hit the emtpy bottom
                        if (effectiveY >= y_max)
                        {
                            return true;
                        }

                        // Check if it hit existing blocks
                        if (board.squares[effectiveX, effectiveY + 1] > 0)
                        {
                            return true;
                        }

                    }
                }
            }
            
            return false;
        }

        public void SetPieceOnBoard(PieceState state, int x, int y, Board board)
        {
            for (int row = 0; row < array2D.GetLength(0); row++) // Loop over rows
            {
                for (int col = 0; col < array2D.GetLength(1); col++) // Loop over columns in a row
                {
                    int element = array2D[row, col];
                    if (element > 0)
                    {
                        int effectiveX = col + x - x_center_offset;
                        int effectiveY = row + y - y_center_offset;
                        board.squares[effectiveX, effectiveY] = PieceType.T;
                    }
                }
            }
        }


        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Board board)
        {
            Microsoft.Xna.Framework.Color color = PieceColor.GetPieceColor(pieceType);
            int x = board.x_piece;
            int y = board.y_piece;

            for (int row = 0; row < array2D.GetLength(0); row++) // Loop over rows
            {
                for (int col = 0; col < array2D.GetLength(1); col++) // Loop over columns in a row
                {
                    int element = array2D[row, col];
                    int effectiveX = col + x - x_center_offset;
                    int effectiveY = row + y - y_center_offset;

                    Microsoft.Xna.Framework.Color colorToUse = element > 0 ? color : Microsoft.Xna.Framework.Color.Gray;

                    graph.DrawSquare(graphicsDevice, spriteBatch, effectiveX, effectiveY, colorToUse);

                }
            }
        }
    }
}

