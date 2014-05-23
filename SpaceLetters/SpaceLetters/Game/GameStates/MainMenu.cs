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
        private const float button_width = 200, button_height = 50;
        private Texture texture_ingame, texture_credits, texture_exit;
        public override EGameStates getGameStateType()
        {
            return EGameStates.MainMenu;
        }

        public override void loadContent()
        {
            // TODO
            toIngame = new Vec2f(300,100);
            toCredits = new Vec2f(300, 200);
            toExit = new Vec2f(300, 300);

            !texture_ingame.loadFromFile("Content\main_menu\main_menu_ingame.png");
            if (!texture_ingame.loadFromFile("Content\main_menu\main_menu_ingame.png") || !texture_exit.loadFromFile("Content\main_menu\main_menu_exit.png") || !texture_credits.loadFromFile("Content\main_menu\main_menu_credits.png"))
            {
            }
        }

        public override EGameStates update(GameTime gameTime)
        {

            

            return EGameStates.MainMenu;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            Console.WriteLine("blah");



        }
    }
}
