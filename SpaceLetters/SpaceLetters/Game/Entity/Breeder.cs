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
        private bool readyToSpawn;

        public bool ReadyToSpawn
        {
            get { return readyToSpawn; }
            set { readyToSpawn = value; }
        }

        public Breeder(Vec2f position, float rotation,  float hp, Vec2f velocity, Team team, String name)
            : base(position, rotation, 7, hp, velocity, team, name, new Sprite(new Texture("Content/InGame/player.png")))
        {


            cooldown = 0;
            threshold = 300;
        }

        public override EntityType getEntityType()
        {
            return EntityType.EnemyBreeder;
        }
        

        public override void update(GameTime gameTime)
        {
            cooldown++;
            if (cooldown >= threshold)
            {
                readyToSpawn = true;
                cooldown = 0;
                threshold = threshold*2;
                hp = hp * 2;
            }

        }

    }
}
