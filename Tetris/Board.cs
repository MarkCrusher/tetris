using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris
{
    public class Board
    {
        public int x_piece;
        public int y_piece;
        public PieceState piece_state = PieceState.Up;
        public PieceType[,] squares = new PieceType[TetrisGame.BOARD_SIZE_WIDTH, TetrisGame.BOARD_SIZE_HEIGHT];

        public Board()
        {
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

        public bool DropOneDown(Piece piece)
        {
            y_piece++;

            if (piece.CheckBottom(piece_state, x_piece, y_piece, this))
            {
                ResetPiecePosition();
                return true;
            }

            if (y_piece > TetrisGame.BOARD_SIZE_HEIGHT - 1)
            {
                ResetPiecePosition();
                return true;
            }

            return false;
        }

        public void DropAllTheWay(Piece piece)
        {
            while (!DropOneDown(piece)) ;
        }

        public void MoveRight(Piece piece)
        {
            x_piece = piece.GetNextX(piece_state, x_piece, 1);
        }

        public void MoveLeft(Piece piece)
        {
            x_piece = piece.GetNextX(piece_state, x_piece, -1);
        }

        public void Rotate(Piece piece)
        {
            piece_state = (PieceState)(((int)piece_state + 1) % 4);
            x_piece = piece.GetNextX(piece_state, x_piece, 0);
        }

        public bool CheckBottom(Piece piece)
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
            for (int x = 0; x < TetrisGame.BOARD_SIZE_WIDTH; x++)
            {
                for (int y = 0; y < TetrisGame.BOARD_SIZE_HEIGHT; y++)
                {
                    graph.DrawSquare(graphicsDevice, spriteBatch, x, y, PieceColor.GetPieceColor(squares[x, y]));
                }
            }

        }


    }
}

