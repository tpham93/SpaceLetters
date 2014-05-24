using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    abstract class Weapon
    {
        protected float coolDown;

        protected Vec2f position;
        protected float rotation;
        protected float radius;
        protected Sprite sprite;

        public Vec2f Position
        {
            get { return position; }
            set { position = value; }
        }
        public Vec2f TextureSize
        {
            get { return new Vec2f(sprite.Texture.Size.X, sprite.Texture.Size.Y); }
 
        }
        public Sprite Sprite
        {
            get { return sprite; }
        }

        protected float runCoolDownTime;

         public Weapon(Vec2f position, float rotation, float radius, Sprite sprite, float coolDown)
        {
            this.position = position;
            this.rotation = rotation;
            this.radius = radius;
            this.sprite = sprite;
            this.coolDown = coolDown;
            this.runCoolDownTime = 0;

            initialize();
            
        }


        


        public abstract Entity fire( Vec2f target, Entity entity);



        public abstract void initialize();

        public abstract void loadContent();
        public abstract void update(GameTime gameTime);

        public abstract void draw(GameTime gameTime, RenderWindow renderWindow);

    }
}
