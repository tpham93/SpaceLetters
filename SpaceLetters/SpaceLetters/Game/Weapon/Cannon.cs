using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Cannon : Weapon
    {
        private static Texture texture = new Texture("Content/InGame/cannon.png");

        public Cannon(Vec2f position, float rotation, float radius, float coolDown, float projectTileDamage)
            : base(position, rotation, radius, new Sprite(texture), coolDown, projectTileDamage)
        {

        }

        public override void initialize()
        {
            //throw new NotImplementedException();
        }

        public override void loadContent()
        {
            sprite.Origin = new Vec2f(sprite.Texture.Size.X / 2, sprite.Texture.Size.Y / 2);
            //throw new NotImplementedException();
        }

        public override void update(GameTime gameTime)
        {
            if(runCoolDownTime<=coolDown)
                runCoolDownTime += (float)gameTime.ElapsedTime.TotalMilliseconds;

           
            //throw new NotImplementedException();
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            Sprite.Position = position;
            renderWindow.Draw(Sprite);
        }

        public override Entity fire(Vec2f target, Entity entity)
        {
            if (runCoolDownTime > coolDown * CoolDownFactor)
            {
                //throw new NotImplementedException();
                Vec2f velocity = (target - position) * 3;

                velocity.normalize();
                velocity *= 300;
                runCoolDownTime = 0;
                return new Projectiles(position, 0, 1, 10, velocity, Team.Good, "Projectiles", projectileDamage * ProjectileDamageFactor, null, 10000f);
                
            }
            return null;
        }
    }
}
