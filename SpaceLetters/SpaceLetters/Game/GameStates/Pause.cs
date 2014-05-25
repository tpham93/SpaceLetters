using SFML.Graphics;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Pause : AGameState
    {
        

        public override void initialize()
        {

        }

        public override void loadContent()
        {

        }

        public override EGameStates update(GameTime gameTime)
        {
            if(Game.keyboardInput.isClicked(Keyboard.Key.Escape))
                return EGameStates.InGame;

            return EGameStates.Pause;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            Text t = new Text("Pause", Game.smaraFont);
            renderWindow.Draw(t);
        }
    }
}
