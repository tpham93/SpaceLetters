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
        public Enemy(Vec2f position, float rotation, float radius, float hp, Vec2f velocity, Team team, String name, Sprite sprite)
            :base(position, rotation,  radius,  hp,  velocity,  team,  name,  sprite)
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
            
        }

        public override EntityType getEntityType()
        {
            return EntityType.Enemy;
        }

        public override void initialize()
        {
            throw new NotImplementedException();
        }

        protected void moveTowardsPlayer(Player player, float distance)
        {
            Vec2f path = player.Position - position;
            path = (distance / path.length()) *path;
            velocity = path;
        }
    }
}
