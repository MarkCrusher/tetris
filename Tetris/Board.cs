using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

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
            for (int x = 0; x < TetrisGame.BOARD_SIZE_WIDTH; x++)
            {
                for (int y = 0; y < TetrisGame.BOARD_SIZE_HEIGHT; y++)
                {
                    squares[x, y] = 0;
                }
            }
        }

        private void GenerateNextPiece()
        {
            Random random = new Random();

            // Generate a random integer between 0 and 2
            int randomNumber = random.Next(2);
            if (randomNumber == 0)
            {
                piece = new Piece_O();
            }
            else if (randomNumber == 1)
            {
                piece = new Piece_T();
            }

            piece = new Piece_Z();
        }

        public bool DropOneDown()
        {
            y_piece++;

            if (piece.CheckBottom(piece_state, x_piece, y_piece, this))
            {
                ResetPiecePosition();
                GenerateNextPiece();
                return true;
            }

            if (y_piece > TetrisGame.BOARD_SIZE_HEIGHT - 1)
            {
                ResetPiecePosition();
                GenerateNextPiece();
                return true;
            }

            return false;
        }

        public void DropAllTheWay()
        {
            while (!DropOneDown());
           GenerateNextPiece();

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
            x_piece = piece.GetNextX(piece_state, x_piece, 0);
        }

        public bool CheckBottom()
        {
            return piece.CheckBottom(piece_state, x_piece, y_piece, this);
        }

        public void ResetPiecePosition()
        {
            x_piece = TetrisGame.BOARD_SIZE_WIDTH / 2;
            y_piece = 0;
        }

        public void Draw(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            DrawBoard(graphicsDevice, spriteBatch);
            DrawPiece(graphicsDevice, spriteBatch);
        }

        public void DrawBoard(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            for (int x = 0; x < TetrisGame.BOARD_SIZE_WIDTH; x++)
            {
                for (int y = 0; y < TetrisGame.BOARD_SIZE_HEIGHT; y++)
                {
                    graph.DrawSquare(graphicsDevice, spriteBatch, x, y, PieceColor.GetPieceColor(squares[x, y]));
                }
            }
        }

        public void DrawPiece(GraphicsDevice graphicsDevice, SpriteBatch spriteBatch)
        {
            piece.Draw(graphicsDevice, spriteBatch, this);
        }


    }
}

