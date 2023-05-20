using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris;

public class TetrisGame : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch _spriteBatch;
    public const int BOARD_SIZE_WIDTH = 10;
    public const int BOARD_SIZE_HEIGHT = 20;
    public const int SQUARE_SIDE = 20;
    public const int SQUARE_BOARDER = SQUARE_SIDE / 10;
    public static Color BOARD_COLOR = Color.White;
    public Board board;
    public Piece piece;


    KeyboardState currentKeyboardState;
    KeyboardState previousKeyboardState;
    private double elapsed;
    private double delay;

    public TetrisGame()
    {
        board = new Board();
        piece = GenerateNextPiece();
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        // Set the preferred window size
        _graphics.PreferredBackBufferWidth = SQUARE_SIDE* BOARD_SIZE_WIDTH;
        _graphics.PreferredBackBufferHeight = SQUARE_SIDE*BOARD_SIZE_HEIGHT; 

    }

    protected override void Initialize()
    {
        currentKeyboardState = Keyboard.GetState();
        previousKeyboardState = currentKeyboardState;

        delay = 500;

        this.TargetElapsedTime = TimeSpan.FromSeconds(1f / 20);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        _spriteBatch = new SpriteBatch(GraphicsDevice);

        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // Add elapsed game time since last frame to elapsed
        elapsed += gameTime.ElapsedGameTime.TotalMilliseconds;

        // Check if elapsed is larger than delay
        if (elapsed >= delay)
        {
            // Reset elapsed
            elapsed = 0;

            if (board.DropOneDown(piece))
            {
                piece = GenerateNextPiece();
            }

        }

        // Save the previous state
        previousKeyboardState = currentKeyboardState;
        // Get the new state
        currentKeyboardState = Keyboard.GetState();

        if (WasKeyPressed(Keys.Right))
        {
            board.MoveRight(piece);

        }

        if (WasKeyPressed(Keys.Left))
        {
            board.MoveLeft(piece);
        }

        if (WasKeyPressed(Keys.Up))
        {
            board.Rotate(piece);
        }


        if (WasKeyPressed(Keys.Down))
        {
            board.DropAllTheWay(piece);
            piece = GenerateNextPiece();
        }

        base.Update(gameTime);

    }

    protected Piece GenerateNextPiece()
    {
        Random random = new Random();

        // Generate a random integer between 0 and 2
        int randomNumber = random.Next(2);
        if (randomNumber == 0) {
            return new Piece_O();
        } else if (randomNumber == 1)
        {
            return new Piece_T();
        }
        return null;
;
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();


        board.Draw(GraphicsDevice, _spriteBatch);
        piece.Draw(GraphicsDevice, _spriteBatch, board);

        _spriteBatch.End();

        base.Draw(gameTime);
    }


    // Method to check if a key was just pressed
    private bool WasKeyPressed(Keys key)
    {
        return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
    }

}

