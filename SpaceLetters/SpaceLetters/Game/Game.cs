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
        private AGameState currentGameStateObject;
        private AGameState backedUpGameStateObject;

        private EGameStates currentGameState;

        private EGameStates CurrentGameState
        public static Vec2f WINDOWSIZE = new Vec2f(800, 480);

        public Game(): base((int)WINDOWSIZE.X, (int)WINDOWSIZE.Y, "Epic Game", Styles.Default)
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
                            }
                            break;
                        case EGameStates.InGame:
                            backedUpGameStateObject = null;
                            //currentGameStateObject = new InGame();
                            break;
                        case EGameStates.Pause:
                            backedUpGameStateObject = currentGameStateObject;
                            //currentGameStateObject = new Pause();
                            break;
                        case EGameStates.Credits:
                            backedUpGameStateObject = null;
                            //currentGameStateObject = new Credits();
                            break;
                        case EGameStates.Exit:

                            break;
                    }
                    currentGameState = value;
                }
            }
        }

        public Game()
            : base(800, 480, "Epic Game", Styles.Default)
        {
            currentGameState = EGameStates.MainMenu;
            currentGameStateObject = new MainMenu();
            backedUpGameStateObject = null;

        }



        public override void update(GameTime gameTime)
        {
            currentGameStateObject.update(gameTime);
            //throw new NotImplementedException();
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            window.Clear(new Color(100, 149, 237));
            currentGameStateObject.draw(gameTime, window);
            //throw new NotImplementedException();
        }
    }
}
