using SFML.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Smaragd : Entity
    {
        private static Texture texture = new Texture("Content/InGame/LetterCase/smara.png");


        public Smaragd(Vec2f position, float rotation, float hp, float radius, Vec2f velocity, Team team, String name)
            :base(position, rotation, hp, radius, velocity, team, name,new Sprite(texture))
        {

        }

        public override EntityType getEntityType()
        {
            return EntityType.Letter;
        }

        public override void initialize()
        {

        }

        public override void update(GameTime gameTime)
        {
          
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
          
        }

        public override void loadContent()
        {
           
        }
    }
}
