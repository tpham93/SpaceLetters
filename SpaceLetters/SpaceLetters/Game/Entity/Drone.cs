using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SpaceLetters
{
    class Drone : Entity
    {
        // change texture
        private static Texture texture = new Texture("Content/InGame/breeder.png");
        private float maxspeed;
        private static Random rand;

        public Drone(Vec2f position, float rotation, float hp, Vec2f velocity)
            :base(position, rotation,  8,  hp, 2,  velocity,  Team.Good,  "Drone",  new Sprite(texture))
        {

            initialize();

        }

        public override EntityType getEntityType()
        {
            return EntityType.Drone;
        }

        public override void initialize()
        {
            
        }

        public override void loadContent()
        {
            //throw new NotImplementedException();
        }

        public override void update(GameTime gameTime)
        {
           // throw new NotImplementedException();
        }

        public override void draw(GameTime gameTime, RenderWindow renderWindow)
        {
            sprite.Position = position;
            renderWindow.Draw(sprite);
        }
        private Smaragd searchtarget(){
            return null;
        }
    }
}
