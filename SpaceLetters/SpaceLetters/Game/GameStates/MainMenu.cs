using System;
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


        public override void initialize()
        {
            // TODO
        }

        public override void loadContent()
        {
            backgroundSprite = new Sprite(new Texture("Content/InGame/worldBg.png"), new IntRect(0, 0, (int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));

            button_x = (int) ((Game.WINDOWSIZE.X-button_width)/2);
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

            

            Console.WriteLine("Positionen: " + Game.WINDOWSIZE.X + "+" + button_x + " : " + button_height + "+" + button_y_distance);
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

            

            return EGameStates.MainMenu;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {

            renderWindow.Draw(backgroundSprite);

            renderWindow.Draw(sprite_ingame);
            renderWindow.Draw(sprite_credits);
            renderWindow.Draw(sprite_exit);

        }
    }
}
