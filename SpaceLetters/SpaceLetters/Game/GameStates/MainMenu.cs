﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SpaceLetters
{
    class MainMenu : AGameState
    {
        private Vec2f toIngame, toCredits, toExit;
        private const int button_width = 200, button_height = 50;
        private int button_x, button_y_distance;
        private Sprite sprite_ingame, sprite_exit, sprite_credits;

        public override void initialize()
        {
            // TODO
        }

        public override void loadContent()
        {
            button_x = (int) (Game.WINDOWSIZE.X/2-button_width/2.0);
            button_y_distance = (int)((Game.WINDOWSIZE.Y - 150) / 4);
            
            toIngame = new Vec2f(button_x,button_y_distance);
            toCredits = new Vec2f(button_x, button_height + 2* button_y_distance);
            toExit = new Vec2f(button_x, 2 * button_height + 3 * button_y_distance);

            sprite_ingame = new Sprite(new Texture("Content/main_menu/main_menu_ingame.png"));
            sprite_exit = new Sprite(new Texture("Content/main_menu/main_menu_exit.png"));
            sprite_credits = new Sprite(new Texture("Content/main_menu/main_menu_credits.png"));
            sprite_ingame.Position = toIngame;
            sprite_exit.Position = toExit;
            sprite_credits.Position = toCredits;

        }

        public override EGameStates update(GameTime gameTime)
        {
            Vec2f mousepos = new Vec2f(42, 42); // TODO entfernen

            if (button_x <= mousepos.X && mousepos.X <= button_x + button_width)
            {
                
            }

            

            return EGameStates.MainMenu;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            //Console.WriteLine((int)toCredits.X +"   "+(int)toCredits.Y);
            renderWindow.Draw(sprite_ingame);
            renderWindow.Draw(sprite_credits);
            renderWindow.Draw(sprite_exit);

        }
    }
}
