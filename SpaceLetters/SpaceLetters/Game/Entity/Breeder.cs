﻿using System;
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
        private static int breeder_count = 0;
        private int maxcount;
        private TimeSpan cooldown, threshold;
        private bool readyToSpawn;
        private Random rand;
        private Entity target;
        private float shootChance = 0.01f;

        public bool ReadyToSpawn
        {
            get { return readyToSpawn; }
            set { readyToSpawn = value; }
        }
        public Breeder(Vec2f position, float rotation, Vec2f velocity, String name, Entity target)
            : base(position, rotation, 10, 7, 3, velocity, Team.Evil, name, new Sprite(texture))
        {
            this.cooldown = TimeSpan.FromSeconds(0);
            this.threshold = TimeSpan.FromSeconds(5);
            this.rand = new Random();
            this.target = target;
            breeder_count++;
            maxcount = 333;
        }

        public override EntityType getEntityType()
        {
            return EntityType.EnemyBreeder;
        }


        public override void update(GameTime gameTime)
        {
            cooldown += gameTime.ElapsedTime;
            if (breeder_count < maxcount && cooldown >= threshold)
            {
                readyToSpawn = true;
                cooldown = TimeSpan.FromSeconds(rand.NextDouble() * threshold.TotalSeconds / 2);
                threshold = threshold.Add(threshold);
                Hp = Hp + 2;
            }
            moveTowardsEntity((Player)target, 1);
            position += velocity;
        }
        public override void onDeath()
        {
            breeder_count--;
        }

        public override Projectiles shoot()
        {
            Vec2f v = (target.Position - position);
            v.normalize();
            v *= 300;
            if (rand.NextDouble() <= shootChance)
            {
                Projectiles p = new Projectiles(position, 0, 1, 2, v, Team.Evil, "Projectiles", 10, null, 10000f);
                p.loadContent();
                return p;
            }
            return null;
        }

    }
}
