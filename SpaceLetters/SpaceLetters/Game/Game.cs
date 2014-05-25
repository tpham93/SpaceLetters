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
        public static MouseInput mouseInput = null;

        private AGameState currentGameStateObject;
        private AGameState backedUpGameStateObject;
        private EGameStates currentGameState;

        public static Font smaraFont;

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
                            if(currentGameState == EGameStates.Pause)
                            {
                                currentGameStateObject = backedUpGameStateObject;
                                backedUpGameStateObject = null;
                            }
                            else
                            {
                                backedUpGameStateObject = null;
                                currentGameStateObject = new MainMenu();
                                currentGameStateObject.initialize();
                                currentGameStateObject.loadContent();
                            }
                            break;
                        case EGameStates.InGame:
                            backedUpGameStateObject = null;
                            currentGameStateObject = new InGame();
                            currentGameStateObject.initialize();
                            currentGameStateObject.loadContent();
                            break;
                        case EGameStates.Pause:
                            backedUpGameStateObject = currentGameStateObject;
                            //currentGameStateObject = new Pause();
                            currentGameStateObject.initialize();
                            currentGameStateObject.loadContent();
                            break;
                        case EGameStates.Credits:
                            backedUpGameStateObject = null;
                            //currentGameStateObject = new Credits();
                            currentGameStateObject.initialize();
                            currentGameStateObject.loadContent();
                            break;
                        case EGameStates.Score :
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

        public Game(): base((int)WINDOWSIZE.X, (int)WINDOWSIZE.Y, "Epic Game", Styles.Default)
        {
            currentGameState = EGameStates.MainMenu;
            currentGameStateObject = new MainMenu();
            backedUpGameStateObject = null;

            currentGameStateObject.initialize();
            currentGameStateObject.loadContent();
            // keyboard & mouse
            List<Keyboard.Key> usedButtons = new List<Keyboard.Key>();
            // add keys
            usedButtons.Add(Keyboard.Key.Num1);
            usedButtons.Add(Keyboard.Key.Num2);
            usedButtons.Add(Keyboard.Key.Num3);
            usedButtons.Add(Keyboard.Key.Num4);
            usedButtons.Add(Keyboard.Key.Num5);
            usedButtons.Add(Keyboard.Key.Num6);
            usedButtons.Add(Keyboard.Key.Escape);

            keyboardInput = new KeyboardInput(usedButtons);
            mouseInput = new MouseInput(window);

            smaraFont= new Font("Content/Fonts/Days.otf");
        }



        public override void update(GameTime gameTime)
        {
            // updating mouse and keyboard
            mouseInput.update();
            keyboardInput.update();

            // updating gamestate
            CurrentGameState = currentGameStateObject.update(gameTime);
            //throw new NotImplementedException();
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            window.Clear(new Color(100, 149, 237));
            if(backedUpGameStateObject != null)
            {
                backedUpGameStateObject.draw(gameTime, window);
            }
            currentGameStateObject.draw(gameTime, window);
            //throw new NotImplementedException();
        }
    }
}
