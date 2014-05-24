using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SpaceLetters
{
    class Projectiles : Entity
    {
        private static Texture texture = new Texture("Content/InGame/projectiles.png");
        private float damage;

        private Entity entity;

        private float lifeTime;

        public float Damage
        {
            get { return damage; }
        }

        public Projectiles(Vec2f position, float rotation, float hp, float radius, Vec2f velocity, Team team, String name, float damage, Entity entity, float lifeTime)
            :base(position, rotation, hp, radius, velocity, team, name,new Sprite(texture))
        {
            this.damage = damage;
            this.entity = entity;
            this.lifeTime = lifeTime;
        }

        public override void loadContent()
        {
            SFML.Window.Vector2u middle = sprite.Texture.Size / 2;
            sprite.Origin = new SFML.Window.Vector2f(middle.X, middle.Y);
        }

        public override void update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedTime.TotalSeconds;

            lifeTime -= (float)gameTime.ElapsedTime.TotalMilliseconds;

            if (lifeTime <= 0)
                toDelete = true;
        }

        public override void draw(GameTime gameTime, RenderWindow renderWindow)
        {
            sprite.Position = position;
            sprite.Rotation = rotation;
            sprite.Draw(renderWindow, RenderStates.Default);
        }

        public override EntityType getEntityType()
        {
            return EntityType.Projectile;
        }

        public override void initialize()
        {
           // throw new NotImplementedException();
        }
    }
}
