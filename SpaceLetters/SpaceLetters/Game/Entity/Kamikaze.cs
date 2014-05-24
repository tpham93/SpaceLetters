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
        private static Texture texture = new Texture("Content/InGame/kamikaze.png");

        private Entity target;
        private float maxSpeed = 2;
        public Kamikaze(Vec2f position, float rotation, Vec2f velocity, String name, Entity target)
            : base(position, rotation, 10, 5, 1, velocity, SpaceLetters.Team.Evil, name, new Sprite(texture))
        {
            this.target = target;
        }

        public override void loadContent()
        {
            base.loadContent();
        }

        public override void update(GameTime gameTime)
        {
            moveTowardsEntity(target, maxSpeed);
            position += velocity;
        }
    }
}
