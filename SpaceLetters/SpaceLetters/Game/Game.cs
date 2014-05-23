﻿using System;
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
                            //currentGameStateObject = new InGame();
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
                        case EGameStates.Exit:
                            window.Close();
                            break;
                    }
                    currentGameState = value;
                }
            }
        }

        public static Vec2f WINDOWSIZE = new Vec2f(1024, 640);

        public Game(): base((int)WINDOWSIZE.X, (int)WINDOWSIZE.Y, "Epic Game", Styles.Default)
        {
            currentGameState = EGameStates.InGame;
            currentGameStateObject = new MainMenu();
            backedUpGameStateObject = null;

            currentGameStateObject.initialize();
            currentGameStateObject.loadContent();
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