using System;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    public class PieceBase : Piece
    {
        protected PieceType pieceType = PieceType.Z;

        protected int[,] array2D = new int[,]
        {
            { 1, 1, 0 },
            { 0, 1, 1 },
            { 0, 0, 1 },
        };
        protected int x_center_offset = 1;
        protected int y_center_offset = 1;

        public PieceBase()
        {
        }


        public virtual void Rotate()
        {
            array2D = Utils.RotateMatrix90DegreesClockwise(array2D); ;
        }


        public int GetNextX(PieceState state, int x, int delta)
        {
            int newX = x + delta;

            int diff = 0;

            for (int i = 0; i < array2D.GetLength(0); i++) // Loop over columns
            {
                for (int j = 0; j < array2D.GetLength(1); j++) // Loop over columns in a i
                {
                    int element = array2D[i, j];
                    if (element > 0)
                    {
                        int new_diff = IsSquareOutsideBoard(newX, j, i);
                        if (Math.Abs(new_diff) > Math.Abs(diff))
                        {
                            diff = new_diff;
                        }
                    }
                }
            }

            return newX - diff;
        }

        public int IsSquareOutsideBoard(int pieceX, int j, int i)
        {
            int diff = 0;
            int x_min = 0;
            int x_max = TetrisGame.BOARD_SIZE_WIDTH - 1;

            int effectiveX = j + pieceX - x_center_offset;
            if (effectiveX < x_min)
            {
                diff = effectiveX - x_min;

            }
            if (effectiveX > x_max)
            {
                diff = effectiveX - x_max;
            }

           // Console.WriteLine("diff: " + diff);
            return diff;
        }


        public bool HasBottomed(PieceState state, int x, int y, Board board)
        {
            const int y_max = TetrisGame.BOARD_SIZE_HEIGHT - 1;

            for (int i = 0; i < array2D.GetLength(0); i++) // Loop over columns
            {
                for (int j = 0; j < array2D.GetLength(1); j++) // Loop over columns in a i
                {
                    int element = array2D[i, j];
                    if (element > 0)
                    {
                        int effectiveX = j + x - x_center_offset;
                        int effectiveY = i + y - y_center_offset;

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
            for (int i = 0; i < array2D.GetLength(0); i++) // Loop over columns
            {
                for (int j = 0; j < array2D.GetLength(1); j++) // Loop over columns in a i
                {
                    int element = array2D[i, j];
                    if (element > 0)
                    {
                        int effectiveX = j + x - x_center_offset;
                        int effectiveY = i + y - y_center_offset;
                        board.squares[effectiveX, effectiveY] = pieceType;
                    }
                }
            }
        }


        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Board board)
        {
            Microsoft.Xna.Framework.Color color = PieceColor.GetPieceColor(pieceType);
            int x = board.x_piece;
            int y = board.y_piece;

            for (int i = 0; i < array2D.GetLength(0); i++) // Loop over columns
            {
                for (int j = 0; j < array2D.GetLength(1); j++) // Loop over columns in a i
                {
                    int element = array2D[i, j];
                    int effectiveX = j + x - x_center_offset;
                    int effectiveY = i + y - y_center_offset;

                    if (element > 0)
                    {
                        graph.DrawSquare(graphicsDevice, spriteBatch, effectiveX, effectiveY, color);
                    }
                    //else
                    //{
                    //    graph.DrawSquare(graphicsDevice, spriteBatch, effectiveX, effectiveY, Microsoft.Xna.Framework.Color.Gray);
                    //}
                }
            }
        }
    }
}

