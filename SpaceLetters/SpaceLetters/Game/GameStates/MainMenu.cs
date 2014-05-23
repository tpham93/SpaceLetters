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
        private Texture texture_ingame, texture_credits, texture_exit;
        private Sprite sprite_ingame, sprite_exit, sprite_credits;

        public override void initialize()
        {
            // TODO
        }

        public override void loadContent()
        {
            // TODO
            toIngame = new Vec2f(300,100);
            toCredits = new Vec2f(300, 200);
            toExit = new Vec2f(300, 300);

            sprite_ingame = new Sprite(new Texture("Content/main_menu/main_menu_ingame.png"),new IntRect((int)toIngame.X,(int)toIngame.Y,button_width, button_height));
            sprite_exit = new Sprite(new Texture("Content/main_menu/main_menu_exit.png"),new IntRect((int)toIngame.X,(int)toIngame.Y,button_width, button_height));
            sprite_credits = new Sprite(new Texture("Content/main_menu/main_menu_credits.png"),new IntRect((int)toIngame.X,(int)toIngame.Y,button_width, button_height));

        }

        public override EGameStates update(GameTime gameTime)
        {

            

            return EGameStates.MainMenu;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            Console.WriteLine("blah");
            renderWindow.Draw(sprite_ingame);
            renderWindow.Draw(sprite_credits);
            renderWindow.Draw(sprite_exit);

        }
    }
}
