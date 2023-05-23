using System;
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

        public Board()
        {
            GenerateNextPiece();
            InitBoard();
            ResetPiecePosition();
        }

        private void InitBoard()
        {
            for (int row = 0; row < squares.GetLength(0); row++)
            {
                for (int col = 0; col < squares.GetLength(1); col++)
                {
                    squares[row, col] = 0;
                }
            }
        }

        private void GenerateNextPiece()
        {
            Random random = new Random();

            // Generate a random integer between 0 and 2
            int randomNumber = random.Next(5);
            if (randomNumber == 0)
            {
                piece = new Piece_O();
            }
            else if (randomNumber == 1)
            {
                piece = new Piece_T();
            }
            else if (randomNumber == 2)
            {
                piece = new Piece_Z();
            }
            else if (randomNumber == 3)
            {
                piece = new Piece_L();
            }
            else if (randomNumber == 4)
            {
                piece = new Piece_I();
            }

            piece = new Piece_I();

        }

        public bool DropOneDown()
        {
            AdvancePieceOneDown();

            if (CheckBottom())
            {
                SetPieceOnBoard();
                RemoveFullRows();
                ResetPiecePosition();
                GenerateNextPiece();
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
            piece_state = (PieceState)(((int)piece_state + 1) % 4);
            piece.Rotate();
            CheckPieceIsWithinBorders();
        }

        private void CheckPieceIsWithinBorders()
        {
            x_piece = piece.GetNextX(piece_state, x_piece, 0);
        }

        public bool CheckBottom()
        {
            return piece.HasBottomed(piece_state, x_piece, y_piece, this);
        }


        public void RemoveFullRows()
        {

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
        }

        public void DrawBoard(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            for (int row = 0; row < TetrisGame.BOARD_SIZE_WIDTH; row++)
            {
                for (int col = 0; col < TetrisGame.BOARD_SIZE_HEIGHT; col++)
                {
                    graph.DrawSquare(graphicsDevice, spriteBatch, row, col, PieceColor.GetPieceColor(squares[row, col]));
                }
            }
        }

        public void DrawPiece(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            piece.Draw(graphicsDevice, spriteBatch, this);
        }


    }
}

