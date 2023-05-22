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
   

    KeyboardState currentKeyboardState;
    KeyboardState previousKeyboardState;
    private double elapsed;
    private double delay;

    public TetrisGame()
    {
        board = new Board();
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

            board.DropOneDown();
        }

        // Save the previous state
        previousKeyboardState = currentKeyboardState;
        // Get the new state
        currentKeyboardState = Keyboard.GetState();

        if (WasKeyPressed(Keys.Right) | WasKeyPressed(Keys.D))
        {
            board.MoveRight();
        }

        if (WasKeyPressed(Keys.Left) | WasKeyPressed(Keys.A))
        {
            board.MoveLeft();
        }

        if (WasKeyPressed(Keys.Up) | WasKeyPressed(Keys.W))
        {
            board.Rotate();
        }

        if (WasKeyPressed(Keys.Down) | WasKeyPressed(Keys.S))
        {
            board.DropAllTheWay();
        }

        base.Update(gameTime);
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        board.Draw(GraphicsDevice, _spriteBatch);
        
        _spriteBatch.End();

        base.Draw(gameTime);
    }


    // Method to check if a key was just pressed
    private bool WasKeyPressed(Keys key)
    {
        return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
    }

}

