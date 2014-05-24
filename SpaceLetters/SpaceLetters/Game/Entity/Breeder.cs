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
        // change texture
        private static Texture texture = new Texture("Content/InGame/breeder.png");
        private TimeSpan cooldown, threshold;
        private bool readyToSpawn;
        private Random rand;

        public bool ReadyToSpawn
        {
            get { return readyToSpawn; }
            set { readyToSpawn = value; }
        }
         public Breeder(Vec2f position, float rotation,  float hp, Vec2f velocity, Team team, String name)
            : base(position, rotation, 7, hp, velocity, team, name, new Sprite(texture))
        {


            cooldown = TimeSpan.FromSeconds(0);
            threshold = TimeSpan.FromSeconds(12);
            rand = new Random();
        }

        public override EntityType getEntityType()
        {
            return EntityType.EnemyBreeder;
        }
        

        public override void update(GameTime gameTime)
        {
            cooldown += gameTime.ElapsedTime;
            if (cooldown >= threshold)
            {
                readyToSpawn = true;
                cooldown = TimeSpan.FromSeconds(rand.NextDouble()*threshold.TotalSeconds / 2);
                threshold = threshold.Add(threshold);
                hp = hp * 2;
            }

        }

    }
}
