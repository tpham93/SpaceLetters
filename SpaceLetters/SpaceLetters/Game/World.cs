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

        
        private Player player;

        Sprite backgroundSprite;

        public World()
        {
            entities.Add(new Player(new Vec2f(0, 0), 0, 9001, 50, new Vec2f(0, 0), Team.Good, "Player - Horst"));

        }

        public void loadContent()
        {



            backgroundSprite  = new Sprite(new Texture("Content/InGame/worldBg.png"),new IntRect(0,0,(int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));
            Texture playerTexture = new Texture("Content/InGame/player.png");
            player = new Player(new Vec2f(0, 0), 0, 9001, Math.Max(playerTexture.Size.X, playerTexture.Size.X) / 2, new Vec2f(0, 0), Team.Good, "Player - Horst");
            entities.Add(player);


            foreach (Entity ent in entities)
                ent.loadContent();


        }

        public void update(GameTime gameTime)
        {
            for (int i = entities.Count-1; i>=0; --i)
            {
                entities.ElementAt(i).update(gameTime);

                if (entities.ElementAt(i).ToDelete)
                    entities.RemoveAt(i);

            }

            if(player.spawnNewEnemy() != null)
            {

                entities.AddRange(player.spawnNewEnemy());
            }

        }

        public void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            window.Draw(backgroundSprite);
            foreach (Entity ent in entities)
                ent.draw(gameTime, window);
        }



    }
}
