using System;
using System.Data.Common;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    public class Board
    {
        public Piece piece;
        public int x_piece;
        public int y_piece;
        public PieceState piece_state = PieceState.Up;
        public PieceType[,] squares = new PieceType[TetrisGame.BOARD_SIZE_WIDTH, TetrisGame.BOARD_SIZE_HEIGHT];
        public int fullRowCount = 0;
        public double initial_delay = 500;
        public int max_levels = 10;

        public Board()
        {
            ResetGame();
        }

        private void InitBoard()
        {
            for (int column = 0; column < squares.GetLength(0); column++)
            {
                for (int row = 0; row < squares.GetLength(1); row++)
                {
                    squares[column, row] = 0;
                }
            }
            fullRowCount = 0;
            y_piece = 0;
            
        }

        public void ResetGame()
        {
            GenerateNextPiece();
            InitBoard();
            ResetPiecePosition();
        }

        public int GetScore()
        {
            int score = fullRowCount * 100;
            return score;
        }

        public double GetDropDelay()
        {
            int rows_per_level = 1;
            int level = (fullRowCount / rows_per_level) + 1;
            double delay = initial_delay - initial_delay * level / (max_levels);
            return delay;

        }

        private void GenerateNextPiece()
        {
            Random random = new Random();

            // Generate a random integer between 0 and 2
            PieceType randomNumber = (PieceType)(random.Next(7) + 1);
            switch (randomNumber)
            {
                case PieceType.T: piece = new Piece_T(); break;
                case PieceType.O: piece = new Piece_O(); break;
                case PieceType.L: piece = new Piece_L(); break;
                case PieceType.S: piece = new Piece_S(); break;
                case PieceType.Z: piece = new Piece_Z(); break;
                case PieceType.J: piece = new Piece_J(); break;
                case PieceType.I: piece = new Piece_I(); break;

            }
        }

        public bool DropOneDown()
        {
            AdvancePieceOneDown();

            if (BottomWasHit())
            {
                SetPieceOnBoard();
                RemoveFullRows();
                GenerateNextPiece();
                ResetPiecePosition();
                return true;
                
            }

            return false;
        }

        public void DropAllTheWay()
        {
            while (!DropOneDown());
        }


        public void AdvancePieceOneDown()
        {
            y_piece++;
        }

        public void MoveRight()
        {
            x_piece = piece.GetNextX(piece_state, x_piece, 1);
        }

        public void MoveLeft()
        {
            x_piece = piece.GetNextX(piece_state, x_piece, -1);
        }

        public void Rotate()
        {
            piece.Rotate();
            CheckPieceIsWithinBorders();
        }

        private void CheckPieceIsWithinBorders()
        {
            x_piece = piece.GetNextX(piece_state, x_piece, 0);
        }

        public bool BottomWasHit()
        {
            return piece.HasBottomed(piece_state, x_piece, y_piece, this);
        }


        public void RemoveFullRows()
        {
            int rowCount = squares.GetLength(1);
            for (int row = 0; row < rowCount; row++)
            {
                if (IsRowFull(row))
                {
                    RemoveRow(row);
                }
            }
        }

        public bool IsGameOver()
        {
            for (int col = 0; col < squares.GetLength(0); col++)
            {
                if (squares[col, 0] > 0)
                    return true;
            }
            return false;
        }

        public bool IsRowFull(int row)
        {
            bool isRowFull = true;
            for (int col = 0; col < squares.GetLength(0); col++)
            {
                isRowFull = isRowFull && squares[col, row] > 0;
            }
            return isRowFull;
        }

        public void RemoveRow(int rowToDelete)
        {
            int rowCount = squares.GetLength(1);
            for (int row = rowCount; row > 0; row--)
            {
                for (int col = 0; col < squares.GetLength(0); col++)
                {
                    if (row <= rowToDelete)
                    {
                        squares[col, row] = squares[col, row-1];
                    }
                }
            }

            fullRowCount++;
        }

        public void ResetPiecePosition()
        {
            x_piece = TetrisGame.BOARD_SIZE_WIDTH / 2;
            y_piece = 0;
        }

        public void SetPieceOnBoard()
        {
           piece.SetPieceOnBoard(piece_state, x_piece, y_piece, this);
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            DrawBoard(graphicsDevice, spriteBatch);
            DrawPiece(graphicsDevice, spriteBatch);
            DrawScore(graphicsDevice, spriteBatch);
        }

        public void DrawBoard(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            for (int column = 0; column < TetrisGame.BOARD_SIZE_WIDTH; column++)
            {
                for (int row = 0; row < TetrisGame.BOARD_SIZE_HEIGHT; row++)
                {
                    graph.DrawSquare(graphicsDevice, spriteBatch, column, row, PieceColor.GetPieceColor(squares[column, row]));
                }
            }
        }

        public void DrawPiece(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            piece.Draw(graphicsDevice, spriteBatch, this);
        }

        public void DrawScore(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            // To do: display the score in the game instead of the title.
        }


    }
}

