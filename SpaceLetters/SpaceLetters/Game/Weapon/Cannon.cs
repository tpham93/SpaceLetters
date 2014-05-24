using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Cannon : Weapon
    {
         public Cannon(Vec2f position, float rotation, float radius, Sprite sprite)  : base (position,rotation, radius, sprite)
        {

        }

        public override void initialize()
        {
            //throw new NotImplementedException();
        }

        public override void loadContent()
        {
            sprite.Origin = new Vec2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y / 2);
            //throw new NotImplementedException();
        }

        public override void update(GameTime gameTime)
        {
            //throw new NotImplementedException();
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            Sprite.Position = Position;
            renderWindow.Draw(Sprite);
        }

        public override bool fire(Vec2f target)
        {
            //throw new NotImplementedException();
            return false;
        }
    }
}
