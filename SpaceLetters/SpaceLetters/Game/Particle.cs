using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Particle
    {
        private Vec2f position;
        private float lifeTime;
        private float startLifeTime;
        private Vec2f velocity;
        public static Texture texture = new Texture("Content/InGame/particle.png");
        private Sprite sprite;

        private bool dead = false;

        public bool Dead
        {
            get { return dead; }
        }


        public Particle(Vec2f position, float lifeTime, Vec2f velocity)
        {
            this.position = position;
            this.lifeTime = lifeTime;
            this.startLifeTime = lifeTime;
            this.velocity = velocity;

            sprite = new Sprite(texture);

        }

        public void update(GameTime gameTime)
        {
            position += velocity;
            lifeTime -= (float)gameTime.ElapsedTime.TotalMilliseconds;

            if (lifeTime <= 0)
                dead = true;
        }

        public void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            sprite.Position = position;
            sprite.Scale = new Vec2f((float)Math.Sqrt(lifeTime / startLifeTime), (float)Math.Sqrt(lifeTime / startLifeTime));
            sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, (byte)((Math.Sqrt(lifeTime / startLifeTime)) * 255));
            window.Draw(sprite);

        }
    }
}
