using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SpaceLetters
{
    public abstract class AGameState
    {
        public abstract EGameStates getGameStateType();
        public abstract void loadContent();
        public abstract EGameStates update(GameTime gameTime);
        public abstract void draw(GameTime gameTime, RenderWindow renderWindow);
    }
}
