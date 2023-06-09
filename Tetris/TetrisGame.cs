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
    public const int SQUARE_BORDER = SQUARE_SIDE / 10;
    public const int GAME_WIDTH = SQUARE_SIDE * BOARD_SIZE_WIDTH + 200;
    public const int GAME_HEIGHT = SQUARE_SIDE * BOARD_SIZE_HEIGHT + 100;
    public const int BOARD_X = (GAME_WIDTH - (SQUARE_SIDE * BOARD_SIZE_WIDTH)) / 2;
    public const int BOARD_Y = (GAME_HEIGHT - (SQUARE_SIDE * BOARD_SIZE_HEIGHT)) / 2;

    public static Color BOARD_COLOR = Color.White;
    public Board board;
   

    KeyboardState currentKeyboardState;
    KeyboardState previousKeyboardState;
    private double elapsed;

    public TetrisGame()
    {
        board = new Board();
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
        // Set the preferred window size
        _graphics.PreferredBackBufferWidth = GAME_WIDTH;
        _graphics.PreferredBackBufferHeight = GAME_HEIGHT; 

    }

    protected override void Initialize()
    {
        Window.Title = "Tetris by Mark Eskenazi";
        currentKeyboardState = Keyboard.GetState();
        previousKeyboardState = currentKeyboardState;

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


        // Save the previous state
        previousKeyboardState = currentKeyboardState;
        // Get the new state
        currentKeyboardState = Keyboard.GetState();

        if(WasKeyPressed(Keys.Space))
        {
             board.ResetGame();
        }

        if (!board.IsGameOver())
        {
            // Check if elapsed is larger than delay
            if (elapsed >= board.GetDropDelay())
            {
                // Reset elapsed
                elapsed = 0;

                board.DropOneDown();
            }

            if (WasKeyPressed(Keys.Right) | WasKeyPressed(Keys.D))
            {
                board.MoveRight();
                // Console.WriteLine("Keys.Right");
            }
            else if (WasKeyPressed(Keys.Left) | WasKeyPressed(Keys.A))
            {
                board.MoveLeft();
               // Console.WriteLine("Keys.Left");
            }
            else if (WasKeyPressed(Keys.Up) | WasKeyPressed(Keys.W))
            {
                board.Rotate();
                // Console.WriteLine("Keys.Up");
            }
            else if (WasKeyPressed(Keys.Down) | WasKeyPressed(Keys.S))
            {
                board.DropAllTheWay();
                // Console.WriteLine("Keys.Down");
            }
        }

        base.Update(gameTime);
    }


    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();

        board.Draw( GraphicsDevice, _spriteBatch);
        
        _spriteBatch.End();

        Window.Title = "Tetris by Mark Eskenazi - Score: " + board.GetScore().ToString();

        base.Draw(gameTime);
    }


    // Method to check if a key was just pressed
    private bool WasKeyPressed(Keys key)
    {
        return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
    }

}

