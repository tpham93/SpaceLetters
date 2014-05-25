using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Bomb : Entity
    {

        private static Texture texture = new Texture("Content/InGame/bomb.png");
        private List<Entity> bombParts;
        float explosionTime;
        float runExplosionTime;
        Random random;

        public Bomb(Vec2f position, float rotation, Vec2f velocity, String name, Entity target, float explosionTime)
            : base(position, rotation, float.PositiveInfinity, 20, 3, velocity, Team.Good, name, new Sprite(texture))
        {
            this.explosionTime = explosionTime;
            runExplosionTime = explosionTime;
        }

        public override EntityType getEntityType()
        {
            return EntityType.Bomb;
        }

        public override void initialize()
        {
            random = new Random();
            bombParts = new List<Entity>();
        }

        public override void loadContent()
        {
            sprite.Origin = new Vec2f((float)texture.Size.X/ 2,(float) texture.Size.Y/ 2);
        }

        public override void update(GameTime gameTime)
        {
            runExplosionTime -= (float)gameTime.ElapsedTime.TotalMilliseconds;

            if(runExplosionTime<0)
            {
                for (int i = 0; i < random.Next(15, 35); i++)
                {
                    Projectiles p = new Projectiles(position, 0, 1, 15, new Vec2f((float)(random.NextDouble() - 0.5f)*190, (float)(random.NextDouble() - 0.5f)*190), Team.Good, "Projectiles", 1.5f, null, 4000f+random.Next(1000));
                    p.loadContent();
                    bombParts.Add(p);
                }

            }
        }
        public List<Entity> getBombFragment()
        {
            return bombParts;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            sprite.Position = position;
            renderWindow.Draw(sprite);

        }
    }
}
