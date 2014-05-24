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
        private Drone drone;

        public Drone Drone
        {
            get { return drone; }
            set { drone = value; }
        }

        private Text nameText;

        private static Vec2f fontMove;

        public Smaragd(Vec2f position, float rotation, float hp, float radius, Vec2f velocity, Team team, String name)
            :base(position, rotation, hp, 0, radius, velocity, team, name,new Sprite(texture))
        {
            sprite.Origin = new Vec2f(sprite.Texture.Size.X, sprite.Texture.Size.Y)/2;
            nameText = new Text(name, Game.smaraFont);
            FloatRect size = nameText.GetLocalBounds();
            nameText.Origin = new Vec2f(size.Width - size.Left-3, size.Height - size.Top+15)/2;
            nameText.Color = new Color(0, 0, 0, (byte)165);
            nameText.Scale = new Vec2f(0.5f, 0.5f);

            //fontMove = new Vec2f(5+nameText., 0);
            
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
            velocity.normalize();
            velocity *= 2;
            this.position += velocity;
        }

        public override void draw(GameTime gameTime, SFML.Graphics.RenderWindow renderWindow)
        {
            sprite.Position = position;
            nameText.Position = position;
            renderWindow.Draw(sprite);
            renderWindow.Draw(nameText);
        }

        public override void loadContent()
        {
           
        }

    }
}
