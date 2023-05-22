using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Tetris;
using System.Drawing;

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


            int new_x = x + delta;

            for (int i = 0; i < array2D.GetLength(0); i++) // Loop over rows
            {
                for (int j = 0; j < array2D.GetLength(1); j++) // Loop over columns in a row
                {
                    int element = array2D[i, j];
                    if (element > 0)
                    {
                        int x_effective = j + x - x_center_offset;

                        int proposed_x = x_effective + delta;

                        if (proposed_x < x_min) {
                            x = x_min + x_center_offset;
                            return x;
                        }
                        if (proposed_x > right_border)
                        {
                            x = right_border - x_center_offset;
                            return x;
                        }
                    }
                }
            }

            return new_x;
        }


        public bool CheckBottom(PieceState state, int x, int y, Board board)
        {
            if (hasBottomed(state, x, y, board))
            {
                SetPieceOnBottom(state, x, y, board);

                return true;

            }

            return false;
        }


        public bool hasBottomed(PieceState state, int x, int y, Board board)
        {
            for (int i = 0; i < array2D.GetLength(0); i++) // Loop over rows
            {
                for (int j = 0; j < array2D.GetLength(1); j++) // Loop over columns in a row
                {
                    int element = array2D[i, j];
                    if (element > 0)
                    {
                        int x_effective = j + x - x_center_offset;
                        int y_effective = i + y - y_center_offset;
                        if (y_effective >= TetrisGame.BOARD_SIZE_HEIGHT - 1)
                        {
                            return true;
                        }

                        if (board.squares[x_effective, y_effective + 1] > 0)
                        {
                            return true;
                        }

                    }
                }
            }
            
            return false;

        }

        public void SetPieceOnBottom(PieceState state, int x, int y, Board board)
        {
            for (int i = 0; i < array2D.GetLength(0); i++) // Loop over rows
            {
                for (int j = 0; j < array2D.GetLength(1); j++) // Loop over columns in a row
                {
                    int element = array2D[i, j];
                    if (element > 0)
                    {
                        int x_effective = j + x - x_center_offset;
                        int y_effective = i + y - y_center_offset;
                        board.squares[x_effective, y_effective] = PieceType.T;

                    }
                }
            }
        }


        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch, Board board)
        {
            Microsoft.Xna.Framework.Color color = PieceColor.GetPieceColor(pieceType);
            int x = board.x_piece;
            int y = board.y_piece;

            for (int i = 0; i < array2D.GetLength(0); i++) // Loop over rows
            {
                for (int j = 0; j < array2D.GetLength(1); j++) // Loop over columns in a row
                {
                    int element = array2D[i, j];
                    if (element>0)
                    {
                        graph.DrawSquare(graphicsDevice, spriteBatch, j + x - x_center_offset, i + y - y_center_offset, color);
                    }
                    else
                    {
                        graph.DrawSquare(graphicsDevice, spriteBatch, j + x - x_center_offset, i + y - y_center_offset, Microsoft.Xna.Framework.Color.Gray);
                    }
                }
            }
        }
    }
}

