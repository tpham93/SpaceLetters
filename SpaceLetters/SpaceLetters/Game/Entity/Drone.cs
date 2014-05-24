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
        private static Random rand = new Random();
        private float maxspeed;
        private Smaragd target;
        private TimeSpan cooldown, threshold;
        private Player player;
        public bool noTarget, loaded;

        public Drone(Vec2f position, float rotation, float hp, Vec2f velocity, Player player)
            : base(position, rotation, 1, hp, 2, velocity, Team.Good, "Drone", new Sprite(texture))
        {
            this.player = player;
            noTarget = true;
            maxspeed = 10;// *(float)rand.NextDouble();
            target = null;
            cooldown = TimeSpan.FromSeconds(0);
            threshold = TimeSpan.FromSeconds(3);

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

                //noTarget = (cooldown >= threshold);
                if (cooldown > threshold)
                {
                    noTarget = true;

                    cooldown = TimeSpan.FromSeconds(0);
                }

            }
            else
            {
                if (loaded)
                {
                    moveTowardsEntity(player);
                }
                else
                {
                    moveTowardsEntity(target);
                    if (collide(target))
                    {
                        loaded = true;
                    }
                }
            }
            position += velocity;
            if (loaded && collide(player))
            {
                loaded = false;
                target = null;
                Console.WriteLine("Fracht abgeliefert");
            }
        }

        public override void draw(GameTime gameTime, RenderWindow renderWindow)
        {
            sprite.Position = position;
            renderWindow.Draw(sprite);
        }
        public bool setTarget(Smaragd smaragd)
        {
            
            noTarget = false;
            if (smaragd !=null && smaragd.Drone == null)
            {
                target = smaragd;
                target.Drone = this;

                return true;
            }
            else
            {
                Console.WriteLine("keine target");
            }
            return false;
        }

        private void moveTowardsEntity(Entity ent)
        {


            Vec2f path = ent.Position - position;
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
