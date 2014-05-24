using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SpaceLetters
{
    class Breeder : Enemy
    {
        private int cooldown, threshold;
        public Breeder(Vec2f position, float rotation, float radius, float hp, Vec2f velocity, Team team, String name, Sprite sprite)
            :base(position, rotation,  7,  hp,  velocity,  team,  name,  sprite)
        {


            cooldown = 0;
            threshold = 9;
        }

        public override void update(GameTime gameTime)
        {
            cooldown++;
            if (cooldown >= threshold)
            {
                breed();
                cooldown = 0;
                threshold = threshold*2;
            }

        }

        private void breed()
        {
            //TODO
        }
    }
}
