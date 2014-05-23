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
        private float damage;

        public float Damage
        {
            get { return damage; }
        }

        public Projectiles(Vec2f position, float rotation, float hp, float radius, Vec2f velocity, Team team, String name, Sprite sprite, float damage)
            :base(position, rotation, hp, radius, velocity, team, name,sprite)
        {
            this.damage = damage;
        }

        public override void loadContent()
        {
            SFML.Window.Vector2u middle = sprite.Texture.Size / 2;
            sprite.Origin = new SFML.Window.Vector2f(middle.X, middle.Y);
        }

        public override void update(GameTime gameTime)
        {
            position += velocity * (float)gameTime.ElapsedTime.TotalSeconds;
        }

        public override void draw(GameTime gameTime, RenderWindow renderWindow)
        {
            sprite.Position = Game.mouseInput.getMousePos();
            sprite.Rotation = rotation;
            sprite.Draw(renderWindow, RenderStates.Default);
        }
    }
}
