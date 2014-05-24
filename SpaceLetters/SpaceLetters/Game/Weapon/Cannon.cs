using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Audio;

namespace SpaceLetters
{
    class Cannon : Weapon
    {
        private static Music sound = new Music("Content/Sounds/Laser_Shoot2.wav");
		private static Texture texture = new Texture("Content/InGame/cannon.png");

        public Cannon(Vec2f position, float rotation, float radius, float coolDown, float projectTileDamage)
            : base(position, rotation, radius, new Sprite(texture), coolDown, projectTileDamage)
        {
            sound.Loop = false;
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

        public override Entity fire(Vec2f target, Entity entity, bool left, Vec2f playerPos, Weapon weapon)
        {
            if (runCoolDownTime > coolDown * CoolDownFactor)
            {
                Vec2f velocity = (target - position) * 3;
                sound.Play();

                if (left)
                    velocity = (target - position) * 3;
                else
                    velocity = (weapon.Position - playerPos) * 3;

                velocity.normalize();
                velocity *= 300;
                runCoolDownTime = 0;

                Projectiles p = new Projectiles(position, 0, 1, 10, velocity, Team.Good, "Projectiles", projectileDamage*projectileDamageFactor, null, 10000f);
                p.loadContent();
                return p;
                
            }
            return null;
        }
    }
}
