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
            if(Game.keyboardInput.isClicked(Keyboard.Key.Escape) || Game.joystickInput.isClicked(JoystickButton.Select))
                return EGameStates.InGame;

            return EGameStates.Pause;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            Text pauseText = new Text("pause", Game.smaraFont);
            Vec2f textSize = new Vector2f(pauseText.GetLocalBounds().Width, pauseText.GetLocalBounds().Height);
            pauseText.Position = (Game.WINDOWSIZE - textSize) / 2 + new Vec2f(0, -150);
            renderWindow.Draw(pauseText);
            pauseText = new Text("press escape to continue", Game.smaraFont);
            textSize = new Vector2f(pauseText.GetLocalBounds().Width, pauseText.GetLocalBounds().Height);
            pauseText.Position = (Game.WINDOWSIZE - textSize) / 2 + new Vec2f(0, -50);
            renderWindow.Draw(pauseText);
        }
    }
}
