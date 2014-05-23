﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;


namespace SpaceLetters
{
    class World
    {
        List<Entity> entities = new List<Entity>();

        Sprite backgroundSprite;

        public World()
        {



        }

        public void loadContent()
        {

           backgroundSprite  = new Sprite(new Texture("Content/InGame/worldBg.png"),new IntRect(0,0,(int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));
        }

        public void update(GameTime gameTime)
        {


        }

        public void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            window.Draw(backgroundSprite);
        }
    }
}