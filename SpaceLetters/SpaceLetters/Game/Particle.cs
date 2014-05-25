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
            
            sprite.Color = new Color(sprite.Color.R, sprite.Color.G, sprite.Color.B, (byte)((Math.Sqrt(lifeTime / startLifeTime))* 255));

            sprite.Color = Lerp(new Color(218, 165, 0), new Color(255, 0, 0), ((float)Math.Pow(1-lifeTime / startLifeTime,2)));

            window.Draw(sprite);

        }

        public static Color Lerp(Color first, Color second, float amount)
        {
            var r = (byte)(((second.R - first.R) * amount)+first.R);
            var g = (byte)(((second.G - first.G) * amount) + first.G);
            var b = (byte)(((second.B - first.B) * amount) + first.B);
            var a = (byte)(((second.A - first.A) * amount) + first.A);
            return new Color(r, g, b, a);
        }

    }
}
