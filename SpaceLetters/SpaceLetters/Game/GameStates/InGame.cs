﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class InGame : AGameState
    {
        World world;

        public override void loadContent()
        {
            world.loadContent();   
        }

        public override EGameStates update(GameTime gameTime)
        {
            world.update(gameTime);
            if (world.playerDead)
            {
                return EGameStates.MainMenu;
            }

            if (Game.keyboardInput.isPressed(SFML.Window.Keyboard.Key.Escape))
                return EGameStates.Exit;

            return EGameStates.InGame;
            
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            world.draw(gameTime, renderWindow);
        }

        public override void initialize()
        {
            world = new World();
        }

    }
}
