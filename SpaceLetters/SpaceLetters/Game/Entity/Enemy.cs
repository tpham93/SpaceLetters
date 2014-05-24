using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SpaceLetters
{
    class Enemy : Entity
    {
        public Enemy(Vec2f position, float rotation, float radius, float hp, float damage, Vec2f velocity, Team team, String name, Sprite sprite)
            :base(position, rotation,  radius,  hp, damage,  velocity,  team,  name,  sprite)
        {

            initialize();
        }

        public override void loadContent()
        {
            //throw new NotImplementedException();
        }

        public override void update(GameTime gameTime)
        {
            
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            sprite.Position = Position;
            renderWindow.Draw(sprite);
        }

        public override EntityType getEntityType()
        {
            return EntityType.Enemy;
        }

        public override void initialize()
        {
            //throw new NotImplementedException();
        }

        protected void moveTowardsEntity(Entity player, float distance)
        {
            Vec2f path = player.Position - Position;
            if (distance < path.length() && distance >0)
            {
                path = (distance / path.length()) * path;
            }
            velocity = path;
        }

        protected void shootAtPlayer(Player player, float distance)
        {
            Vec2f path = player.Position - Position;
            if (radius > path.length())
            {
                path = (distance / path.length()) * path;
            }
            //TODO
        }

    }
}
