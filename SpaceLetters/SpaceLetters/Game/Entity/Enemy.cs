using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Enemy : Entity
    {
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
    }
}
