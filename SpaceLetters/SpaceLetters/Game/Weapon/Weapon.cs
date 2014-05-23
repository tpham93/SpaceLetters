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
        private float coolDown;

        protected Vec2f position;
        protected float rotation;
        protected float radius;
        protected Sprite sprite;

        protected float runCoolDownTime;

         public Weapon(Vec2f position, float rotation, float radius, Sprite sprite)
        {
            this.position = position;
            this.rotation = rotation;
            this.radius = radius;
            this.sprite = sprite;

            initialize();
            
        }



        public bool isCoolDownOver()
        {
            return runCoolDownTime >= coolDown;

        }

        public abstract bool fire(Vec2f target);



        public abstract void initialize();

        public abstract void loadContent();
        public abstract void update(GameTime gameTime);

        public abstract void draw(GameTime gameTime, RenderWindow renderWindow);

    }
}
