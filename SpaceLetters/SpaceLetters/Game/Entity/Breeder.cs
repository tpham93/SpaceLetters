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
        private Vec2f vec2f1;
        private int p1;
        private int p2;
        private Vec2f vec2f2;
        private EntityType entityType;
        private string p3;
        public Breeder(Vec2f position, float rotation,  float hp, Vec2f velocity, Team team, String name)
            : base(position, rotation, 7, hp, velocity, team, name, new Sprite(new Texture("Content/InGame/player.png")))
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
