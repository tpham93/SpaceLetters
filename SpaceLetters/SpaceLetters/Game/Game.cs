using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;
using SFML.Graphics;
using SFML.Window;

namespace SpaceLetters
{
    class Game : AbstractGame
    {
        public static KeyboardInput keyboardInput = null;
        public static JoystickInput joystickInput = null;
        public static MouseInput mouseInput = null;
        public static string playerName = null;

        private AGameState currentGameStateObject;
        private AGameState backedUpGameStateObject;
        private EGameStates currentGameState;

        private Sprite cursor;

        public static Font smaraFont;

        Vec2f mouseMove = new Vec2f();


        private EGameStates CurrentGameState
        {
            get { return currentGameState; }
            set
            {
                if (value != currentGameState)
                {
                    switch (value)
                    {
                        case EGameStates.MainMenu:
                            backedUpGameStateObject = null;
                            currentGameStateObject = new MainMenu();
                            currentGameStateObject.initialize();
                            currentGameStateObject.loadContent();
                            break;
                        case EGameStates.InGame:
                            if (currentGameState == EGameStates.Pause)
                            {
                                currentGameStateObject = backedUpGameStateObject;
                                backedUpGameStateObject = null;
                            }
                            else
                            {
                                backedUpGameStateObject = null;
                                currentGameStateObject = new InGame();
                                currentGameStateObject.initialize();
                                currentGameStateObject.loadContent();
                            }
                            break;
                        case EGameStates.Pause:
                            backedUpGameStateObject = currentGameStateObject;
                            currentGameStateObject = new Pause();
                            currentGameStateObject.initialize();
                            currentGameStateObject.loadContent();
                            break;
                        case EGameStates.Credits:
                            backedUpGameStateObject = null;
                            //currentGameStateObject = new Credits();
                            currentGameStateObject.initialize();
                            currentGameStateObject.loadContent();
                            break;
                        case EGameStates.Score:
                            backedUpGameStateObject = null;
                            currentGameStateObject = new ScoreGameState();
                            currentGameStateObject.initialize();
                            currentGameStateObject.loadContent();
                            break;
                        case EGameStates.Exit:
                            window.Close();
                            break;
                    }
                    currentGameState = value;
                }
            }
        }

        public static Vec2f WINDOWSIZE = new Vec2f(800, 480);

        public Game()
            : base((int)WINDOWSIZE.X, (int)WINDOWSIZE.Y, "Epic Game", Styles.Default)
        {
            playerName = "";
            currentGameState = EGameStates.MainMenu;
            currentGameStateObject = new MainMenu();
            backedUpGameStateObject = null;

            currentGameStateObject.initialize();
            currentGameStateObject.loadContent();
            // keyboard & mouse
            List<Keyboard.Key> usedButtons = new List<Keyboard.Key>();
            // add keys
            for (int i = (int)Keyboard.Key.Num0; i <= (int)Keyboard.Key.Num9; ++i)
            {
                usedButtons.Add((Keyboard.Key)i);
            }
            for (int i = (int)Keyboard.Key.Numpad0; i <= (int)Keyboard.Key.Numpad9; ++i)
            {
                usedButtons.Add((Keyboard.Key)i);
            }
            for (int i = (int)Keyboard.Key.A; i <= (int)Keyboard.Key.Z; ++i)
            {
                usedButtons.Add((Keyboard.Key)i);
            }
            usedButtons.Add(Keyboard.Key.Escape);
            usedButtons.Add(Keyboard.Key.Back);

            keyboardInput = new KeyboardInput(usedButtons);
            mouseInput = new MouseInput(window);
            joystickInput = new JoystickInput();

            smaraFont = new Font("Content/Fonts/Days.otf");
            window.SetMouseCursorVisible(false);

            cursor = new Sprite(new Texture("Content/Cursor.png"));
            cursor.Origin = new Vector2f(cursor.Texture.Size.X, cursor.Texture.Size.Y) / 2;
        }



        public override void update(GameTime gameTime)
        {
            // updating mouse and keyboard
            mouseInput.update();
            keyboardInput.update();
            joystickInput.update();


            if (joystickInput.getRightStick().X > 20)
                mouseMove.X = 4 * joystickInput.getRightStick().X * (float)gameTime.ElapsedTime.TotalSeconds;
            else if (joystickInput.getRightStick().X < -20)
                mouseMove.X = 4 * joystickInput.getRightStick().X * (float)gameTime.ElapsedTime.TotalSeconds;

            if (joystickInput.getRightStick().Y > 20)
                mouseMove.Y = 4 * -joystickInput.getRightStick().Y * (float)gameTime.ElapsedTime.TotalSeconds;
            else if (joystickInput.getRightStick().Y < -20)
                mouseMove.Y = 4 * -joystickInput.getRightStick().Y * (float)gameTime.ElapsedTime.TotalSeconds;

            Mouse.SetPosition(new Vector2i((int)(Mouse.GetPosition(window).X + mouseMove.X), (int)(Mouse.GetPosition(window).Y + mouseMove.Y)), window);


            mouseMove = new Vec2f(0, 0);


            // updating gamestate
            CurrentGameState = currentGameStateObject.update(gameTime);
            //throw new NotImplementedException();

        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            window.Clear(new Color(100, 149, 237));
            if (backedUpGameStateObject != null)
            {
                backedUpGameStateObject.draw(gameTime, window);
            }
            currentGameStateObject.draw(gameTime, window);
            cursor.Position = mouseInput.getMousePos();
            window.Draw(cursor);
            //throw new NotImplementedException();
        }


    }
}
