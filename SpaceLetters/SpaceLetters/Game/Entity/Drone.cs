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
        public Drone(Vec2f position, float rotation, float radius, float hp, Vec2f velocity, Team team, String name, Sprite sprite)
            :base(position, rotation,  radius,  hp,  velocity,  team,  name,  sprite)
        {

            initialize();
        }

        public override EntityType getEntityType()
        {
            return EntityType.Drone;
        }

        public override void initialize()
        {
            //throw new NotImplementedException();
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
            //throw new NotImplementedException();
        }
    }
}
