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

        private Random rand;
        private Player player;

        private float spawnTimeSmaragd;
        private float runSpawnTimeSmaragd;

        Sprite backgroundSprite;

        public World()
        {
            entities.Add(new Player(new Vec2f(0, 0), 0, 9001, 50, new Vec2f(0, 0), Team.Good, "Player - Horst"));
            rand = new Random();

            spawnTimeSmaragd = 3000;

        }

        public void loadContent()
        {



            backgroundSprite = new Sprite(new Texture("Content/InGame/worldBg.png"), new IntRect(0, 0, (int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));
            Texture playerTexture = new Texture("Content/InGame/player.png");
            player = new Player(new Vec2f(0, 0), 0, 9001, Math.Max(playerTexture.Size.X, playerTexture.Size.X) / 2, new Vec2f(0, 0), Team.Good, "Player - Horst");
            entities.Add(player);
            entities.Add(new Breeder(new Vec2f(100, 100), 0, 1, new Vec2f(0, 0), SpaceLetters.Team.Evil, "", player));


            foreach (Entity ent in entities)
                ent.loadContent();

        }

        public void update(GameTime gameTime)
        {
            List<Entity> tmp = new List<Entity>();
            for (int i = entities.Count - 1; i >= 0; --i)
            {
                entities.ElementAt(i).update(gameTime);

                // Spezialbehandlung für einige klassen
                EntityType type = entities.ElementAt(i).getEntityType();
                switch (type)
                {
                    case EntityType.EnemyBreeder:
                        Breeder bre = (Breeder)entities.ElementAt(i);
                        if (bre.ReadyToSpawn)
                        {
                            float alpha = (float)rand.NextDouble() * 360;
                            Breeder bre2 = new Breeder(bre.Position + (new Vec2f((float)(20 * Math.Cos(alpha)), (float)(20 * Math.Sin(alpha)))), 0, 1, new Vec2f(0, 0), SpaceLetters.Team.Evil, "Breeder", player);
                            tmp.Add(bre2);
                            bre.ReadyToSpawn = false;
                        }

                        break;

                    default:
                        break;
                }

                if (entities.ElementAt(i).ToDelete)
                    entities.RemoveAt(i);
            }
            entities.AddRange(tmp);

            entities.AddRange(player.spawnNewEnemy());

            runSpawnTimeSmaragd += (float)gameTime.ElapsedTime.TotalMilliseconds;

            if(runSpawnTimeSmaragd> spawnTimeSmaragd)
            {
                runSpawnTimeSmaragd = 0;
                spawnSmaragd();

            }
        }

        private void spawnSmaragd()
        {

            Vec2f velocity = new Vec2f((float)rand.Next((int)Game.WINDOWSIZE.X), (float)rand.Next((int)Game.WINDOWSIZE.Y));
            velocity.normalize();
            velocity *= 60;
            switch(rand.Next(4))
            {
                case 0: entities.Add(new Smaragd(new Vec2f(-30, (float)rand.NextDouble() * Game.WINDOWSIZE.Y), 0, 2, 20, velocity, Team.Neutral, "B"));
                    break;
                case 1: entities.Add(new Smaragd(new Vec2f(Game.WINDOWSIZE.X + 30, (float)rand.NextDouble() * Game.WINDOWSIZE.Y), 0, 2, 20, velocity, Team.Neutral, "B"));
                    break;
                case 2: entities.Add(new Smaragd(new Vec2f((float)rand.NextDouble() * Game.WINDOWSIZE.X, -30), 0, 2, 20, velocity, Team.Neutral, "B"));
                    break;
                case 3: entities.Add(new Smaragd(new Vec2f((float)rand.NextDouble() * Game.WINDOWSIZE.X, Game.WINDOWSIZE.Y + 30), 0, 2, 20, velocity, Team.Neutral, "B"));
                    break;


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
