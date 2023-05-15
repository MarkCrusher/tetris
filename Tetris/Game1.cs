using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Tetris;

public class Game1 : Game
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

    public Game1()
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

            board.DropOneDown();

        }

        // Save the previous state
        previousKeyboardState = currentKeyboardState;
        // Get the new state
        currentKeyboardState = Keyboard.GetState();

        if (WasKeyPressed(Keys.Right))
        {
            board.MoveRight();

        }

        if (WasKeyPressed(Keys.Left))
        {
            board.MoveLeft();
        }

        if (WasKeyPressed(Keys.Up))
        {
            board.Rotate();
        }


        if (WasKeyPressed(Keys.Down))
        {
            board.DropAllTheWay();
        }

        base.Update(gameTime);

    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        _spriteBatch.Begin();


        DrawBoard();
        DrawPiece();

        _spriteBatch.End();

        base.Draw(gameTime);
    }


    void DrawBoard()
    {
        for (int x = 0; x < BOARD_SIZE_WIDTH; x++)
        {
            for (int y = 0; y < BOARD_SIZE_HEIGHT; y++)
            {
                Color color;
                if (board.squares[x, y] == 0)
                {
                    graph.DrawRect(GraphicsDevice, _spriteBatch, x, y, BOARD_COLOR);
                }
                else
                {
                    graph.DrawRect(GraphicsDevice, _spriteBatch, x, y, Color.BlueViolet);
                }
            }
        }

    }

    void DrawPiece()
    {
        Piece_0.Draw(GraphicsDevice, _spriteBatch, board.piece_state, board.x_piece, board.y_piece);

    }

    

    // Method to check if a key was just pressed
    private bool WasKeyPressed(Keys key)
    {
        return currentKeyboardState.IsKeyDown(key) && previousKeyboardState.IsKeyUp(key);
    }
}

