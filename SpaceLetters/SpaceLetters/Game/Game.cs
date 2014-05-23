using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Template;
using SFML.Graphics;
using SFML.Window;

namespace SpaceLetters
{
    class Game : AbstractGame
    {

        public Game() : base (800,480, "Epic Game", Styles.Default)
        {


        }


        public override void update(GameTime gameTime)
        {
            window.Clear(Color.Blue);

            //throw new NotImplementedException();
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            //throw new NotImplementedException();
        }
    }
}
