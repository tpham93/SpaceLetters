using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML.Graphics;
using SFML.Window;


namespace SpaceLetters
{
    class World
    {
        List<Entity> entities = new List<Entity>();

        Sprite backgroundSprite;

        public World()
        {
            Texture playerTexture = new Texture("Content/InGame/player.png");
            entities.Add(new Player(new Vec2f(0, 0), 0, 9001, Math.Max(playerTexture.Size.X,playerTexture.Size.X)/2, new Vec2f(0, 0), Team.Good, "Player - Horst", new Sprite(playerTexture)));

        }

        public void loadContent()
        {

            foreach (Entity ent in entities)
                ent.loadContent();

           backgroundSprite  = new Sprite(new Texture("Content/InGame/worldBg.png"),new IntRect(0,0,(int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));
        }

        public void update(GameTime gameTime)
        {
            foreach (Entity ent in entities)
                ent.update(gameTime);

        }

        public void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            window.Draw(backgroundSprite);
            foreach (Entity ent in entities)
                ent.draw(gameTime, window);
        }



    }
}
