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

        private Entity entity;

        private float lifeTime;
        private float startLifeTime;

        public Projectiles(Vec2f position, float rotation, float hp, float radius, Vec2f velocity, Team team, String name, float damage, Entity entity, float lifeTime)
            :base(position, rotation, hp, damage, radius, velocity, team, name,new Sprite(texture))
        {
            this.entity = entity;
            this.lifeTime = lifeTime;
            this.startLifeTime = lifeTime;
        }

        public override void loadContent()
        {
            SFML.Window.Vector2u middle = sprite.Texture.Size;
            sprite.Origin = new SFML.Window.Vector2f(middle.X/2, middle.Y/2);
            
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
            sprite.Position = Position;
            sprite.Rotation = rotation;
            sprite.Scale = new Vec2f((float)Math.Sqrt(lifeTime / startLifeTime),(float)Math.Sqrt(lifeTime / startLifeTime));
            sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, (byte)((Math.Sqrt(lifeTime/startLifeTime))*255));
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
