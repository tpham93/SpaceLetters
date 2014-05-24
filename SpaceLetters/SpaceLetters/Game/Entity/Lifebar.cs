using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;

namespace SpaceLetters

{
    class Lifebar
    {
        private Entity ent;
        private Vec2f offset;
        private RectangleShape r1,r2;

        public Lifebar(Entity ent)//:base(new Vec2f(ent.Position.X,ent.Position.Y + 15),0,1,0,0,new Vec2f(0,0),Team.Neutral,sprite)
        {
            this.ent = ent;
            r1 = new RectangleShape(new Vec2f(120,2));
            r2 = new RectangleShape(new Vec2f(120,2));  
            initialize();
        }
        private void initialize()
        {
            offset = new Vec2f(-50, -90);
        }

        public void update(GameTime gameTime)
        {
            r2.Size = new Vec2f(120 * ent.Hp / 100, 2);
        }
        public void draw(GameTime gameTime, RenderWindow renderWindow)
        {
            r1.Position = ent.Position + offset;
            r2.Position = ent.Position + offset;

            r1.FillColor = Color.Red;
            renderWindow.Draw(r1);
            r2.FillColor = Color.Green;
            renderWindow.Draw(r2);

        }
    }
}
