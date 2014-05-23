using SFML.Graphics;
using SFML.Window;
using System;


namespace Template
{
    /// <summary>
    /// Abstract class that runs the basic game, such as setting up a window, event polling, game looping...
    /// </summary>
    public abstract class AbstractGame
    {
        public static readonly Color CornflowerBlue = new Color(101, 156, 239);

        public RenderWindow window;
        public GameTime gameTime;

        public static int wheelDelta;

        /// <summary>
        /// Creating a window with the given parameter. Note: you can change everything in derived class aswell.
        /// </summary>
        /// <param name="width">Width of the window.</param>
        /// <param name="height">Height of the window.</param>
        /// <param name="title">Title of the window.</param>
        /// <param name="style">Window style, e.g. fullscreen, default, resizable, not resizable..</param>
        public AbstractGame(int width, int height, String title, Styles style)
        {
            window = new RenderWindow(new VideoMode((uint)width, (uint)height), title, style);

            window.SetMouseCursorVisible(true);

            window.Closed += closeHandler;
            window.MouseWheelMoved += mouseWheelHandler;

            window.SetVerticalSyncEnabled(true);
            window.SetFramerateLimit(60);

            gameTime = new GameTime();
        }

        /// <summary>
        /// Handler for the MouseWheelEvent, just reading the mouse wheel delta.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mouseWheelHandler(object sender, MouseWheelEventArgs e)
        {
            wheelDelta = e.Delta;
        }

        /// <summary>
        /// Event handler for closing the window (aka clicking the "x").
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void closeHandler(object sender, EventArgs e)
        {
            window.Close();
        }

        /// <summary>
        /// Start your game with this method. 
        /// Starts the gametime, keeps the window open, dispatches the window events.
        /// Updates the gametime and the derived class aswell. Calls the draw method of the derived class and displays the window.
        /// </summary>
        public void run()
        {
            gameTime.Start();

            while (window.IsOpen())
            {
                window.DispatchEvents();
                gameTime.Update();

                update(gameTime);
                draw(gameTime, window);

                wheelDelta = 0;
                window.Display();
            }
        }

        /// <summary>
        /// Called every frame once, put your game logic here.
        /// </summary>
        /// <param name="gameTime">The gametime (e.g. elapsed time).</param>
        public abstract void update(GameTime gameTime);

        /// <summary>
        /// Called every frame once. Put your draw calls here.
        /// </summary>
        /// <param name="gameTime">The gametime (e.g. elapsed time).</param>
        /// <param name="window">The window where to be drawn to.</param>
        public abstract void draw(GameTime gameTime, RenderWindow window);
    }

}