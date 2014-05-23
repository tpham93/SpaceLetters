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

        public static Vec2f WINDOWSIZE = new Vec2f(800, 480);

        public Game(): base((int)WINDOWSIZE.X, (int)WINDOWSIZE.Y, "Epic Game", Styles.Default)
        {


        }



        public override void update(GameTime gameTime)
        {
            window.Clear(new Color(100, 149, 237));

            //throw new NotImplementedException();
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            //throw new NotImplementedException();
        }
    }
}
