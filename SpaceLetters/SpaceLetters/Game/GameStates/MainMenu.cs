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
        private Sprite sprite_ingame, sprite_exit, sprite_credits, backgroundSprite, sprite_rocket;

        private List<Entity> entities = new List<Entity>();

        private Vec2f playerPos = new Vec2f((float)Game.WINDOWSIZE.X * 0.75f, (float)Game.WINDOWSIZE.Y / 2);

        private Player player;


        public override void initialize()
        {
            player = new Player(playerPos, 0, 100, 50, new Vec2f(0, 0), Team.Num, "PLayer");
            for (int i = 0; i < 5; i++ )
                player.upgrade(UpgradeType.AddCannon, null);
        }

        public override void loadContent()
        {
            backgroundSprite = new Sprite(new Texture("Content/InGame/worldBg.png"), new IntRect(0, 0, (int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));

            button_x = (int)((Game.WINDOWSIZE.X - button_width) / 2 - Game.WINDOWSIZE.X/3);
            button_y_distance = (int)((Game.WINDOWSIZE.Y - 150) / 4);
            
            toIngame = new Vec2f(button_x,button_y_distance);
            toCredits = new Vec2f(button_x, button_height + 2 * button_y_distance);
            toExit = new Vec2f(button_x, 2 * button_height + 3 * button_y_distance);

            sprite_ingame = new Sprite(new Texture("Content/main_menu/main_menu_ingame.png"));
            sprite_exit = new Sprite(new Texture("Content/main_menu/main_menu_exit.png"));
            sprite_credits = new Sprite(new Texture("Content/main_menu/main_menu_credits.png"));
            sprite_ingame.Position = toIngame;
            sprite_exit.Position = toExit;
            sprite_credits.Position = toCredits;

            player.loadContent();
            

            //Console.WriteLine("Positionen: " + Game.WINDOWSIZE.X + "+" + button_x + " : " + button_height + "+" + button_y_distance);
        }

        public override EGameStates update(GameTime gameTime)
        {
            Vec2f mousepos = Game.mouseInput.getMousePos();
            //Console.WriteLine(mousepos.X + "    " + mousepos.Y);

            if (Game.mouseInput.leftClicked() && button_x <= mousepos.X && mousepos.X <= button_x + button_width)
            {
                if (button_y_distance <= mousepos.Y && mousepos.Y <= button_y_distance + button_height)
                {
                    //start
                    Console.WriteLine("start");
                    return EGameStates.InGame;
                }
                else if (button_y_distance * 2 + button_height <= mousepos.Y && mousepos.Y <= button_y_distance * 2 + button_height * 2)
                {
                    //credits
                    Console.WriteLine("credits");
                    return EGameStates.Credits;
                }
                else if (button_y_distance * 3 + button_height * 2 <= mousepos.Y && mousepos.Y <= button_y_distance * 3 + button_height * 3)
                {
                    //exit
                    Console.WriteLine("exit");
                    return EGameStates.Exit;
                }
            }

            player.update(gameTime);
            player.Position = playerPos;
            entities.AddRange(player.spawnNewEnemy());

            for (int i = entities.Count - 1; i >= 0; --i)
            {
                entities[i].update(gameTime);

                if (entities.ElementAt(i).ToDelete)
                {

                    entities[i].onDeath();
                    entities.RemoveAt(i);
                }
            }





            if (Game.keyboardInput.isClicked(SFML.Window.Keyboard.Key.Escape))
                return EGameStates.Exit;

            return EGameStates.MainMenu;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {


            renderWindow.Draw(backgroundSprite);

            player.draw(gameTime, renderWindow);
            renderWindow.Draw(sprite_ingame);
            renderWindow.Draw(sprite_credits);
            renderWindow.Draw(sprite_exit);

            foreach(Entity entity in entities)
            {
                entity.draw(gameTime, renderWindow);

            }

        }
    }
}
