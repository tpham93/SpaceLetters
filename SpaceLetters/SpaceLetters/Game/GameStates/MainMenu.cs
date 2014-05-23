using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class MainMenu : AGameState
    {
        public override EGameStates getGameStateType()
        {
            return EGameStates.MainMenu;
        }

        public override void loadContent()
        {
            // TODO
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
