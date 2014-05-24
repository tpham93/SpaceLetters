using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SFML.Graphics;

namespace SpaceLetters
{
    class Kamikaze:Enemy
    {
        private static Texture texture = new Texture("Content/imgame/kamikaze.png");

        private Player target;
        private float maxSpeed = 42;
        public Kamikaze(Vec2f position, float rotation, float radius, float hp, Vec2f velocity, Team team, String name, Sprite sprite)
            :base( position,  rotation,  10,  1,  new Vec2f(0,0),  SpaceLetters.Team.Evil,  name,  new Sprite(texture))
        {

            
        }
        public override void update(GameTime gameTime)
        {
            moveTowardsPlayer(target, maxSpeed);
        }
    }
}
