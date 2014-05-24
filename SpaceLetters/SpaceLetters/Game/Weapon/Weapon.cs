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
        protected float projectileDamage;
        protected Vec2f position;
        protected float rotation;
        protected float radius;
        protected Sprite sprite;
        protected float coolDownFactor;
        protected float projectileDamageFactor;

        public Vec2f Position
        {
            get { return position; }
            set { position = value; }
        }
        public float CoolDownFactor
        {
            get { return coolDownFactor; }
            set { coolDownFactor = value; }
        }
        public float ProjectileDamageFactor
        {
            get { return projectileDamageFactor; }
            set { projectileDamageFactor = value; }
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

         public Weapon(Vec2f position, float rotation, float radius, Sprite sprite, float coolDown, float projectileDamage)
        {
            this.position = position;
            this.rotation = rotation;
            this.radius = radius;
            this.sprite = sprite;
            this.coolDown = coolDown;
            this.projectileDamage = projectileDamage;
            this.runCoolDownTime = 0;
            this.coolDownFactor = 1.0f;
            this.projectileDamageFactor = 1.0f;
            initialize();
            
        }


        


        public abstract Entity fire( Vec2f target, Entity entity, bool left, Vec2f playerPos, Weapon weapon);



        public abstract void initialize();

        public abstract void loadContent();
        public abstract void update(GameTime gameTime);

        public abstract void draw(GameTime gameTime, RenderWindow renderWindow);

    }
}
