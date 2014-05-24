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


        public bool ReadyToSpawn
        {
            get { return readyToSpawn; }
            set { readyToSpawn = value; }
        }
         public Breeder(Vec2f position, float rotation,  float hp, Vec2f velocity, Team team, String name, Entity target)
            : base(position, rotation, 7, hp, velocity, team, name, new Sprite(texture))
        {

            this.cooldown = TimeSpan.FromSeconds(0);
            this.threshold = TimeSpan.FromSeconds(1);
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
                cooldown = TimeSpan.FromSeconds(rand.NextDouble()*threshold.TotalSeconds / 2);
                threshold = threshold.Add(threshold);
                hp = hp * 2;
            }
            moveTowardsEntity((Player)target,1);
            position += velocity;
            Console.WriteLine(breeder_count);
        }

    }
}
