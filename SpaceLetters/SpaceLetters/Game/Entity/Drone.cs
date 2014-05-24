﻿using System;
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
        private static Random rand = new Random();
        private float maxspeed;
        private Smaragd target;
        private TimeSpan cooldown, threshold;
        private Player player;
        public bool noTarget;

        public Drone(Vec2f position, float rotation, float hp, Vec2f velocity, Player player)
            : base(position, rotation, 8, hp, 2, velocity, Team.Good, "Drone", new Sprite(texture))
        {

            noTarget = true;
            maxspeed = 10 * (float)rand.NextDouble();
            target = null;
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
            cooldown += gameTime.ElapsedTime;

            if (target == null)
            {
                moveTowardsEntity(player);

                noTarget = (cooldown >= threshold);

            }
            else
            {
                moveTowardsEntity(target);
            }
            position += velocity;
        }

        public override void draw(GameTime gameTime, RenderWindow renderWindow)
        {
            sprite.Position = position;
            renderWindow.Draw(sprite);
        }
        public void setTarget(Smaragd smaragt)
        {
            target = smaragt;
            noTarget = target == null;
            if (!noTarget)
            {
                target.Drone = this;
            }

        }

        private void moveTowardsEntity(Entity ent)
        {
            Vec2f path = ent.Position - Position;
            if (maxspeed < path.length() && maxspeed > 0)
            {
                path = (maxspeed / path.length()) * path;
            }
            velocity = path;
        }
        public override void onDeath()
        {
            if (target != null)
            {
                target.Drone = null;
            }
        }
    }
}
