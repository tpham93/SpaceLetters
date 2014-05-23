using System;
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
            
        }

        public override EGameStates update(GameTime gameTime)
        {
            return EGameStates.InGame;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {

        }
    }
}
