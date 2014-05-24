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

        Sprite backgroundSprite;

        public World()
        {

            rand = new Random();
            
        }

        public void loadContent()
        {
            


            backgroundSprite  = new Sprite(new Texture("Content/InGame/worldBg.png"),new IntRect(0,0,(int)Game.WINDOWSIZE.X, (int)Game.WINDOWSIZE.Y));
            Texture playerTexture = new Texture("Content/InGame/player.png");
            player = new Player(new Vec2f(0, 0), 0, 9001, Math.Max(playerTexture.Size.X, playerTexture.Size.X) / 2, new Vec2f(0, 0), Team.Good, "Player - Horst", new Sprite(playerTexture));
            entities.Add(player);
            entities.Add(new Breeder(new Vec2f(100,100), 0, 1, new Vec2f(0, 0), SpaceLetters.Team.Evil, ""));


            foreach (Entity ent in entities)
                ent.loadContent();


        }

        public void update(GameTime gameTime)
        {
            List<Entity> tmp = new List<Entity>();

            foreach (Entity ent in entities)
            {
                ent.update(gameTime);

                // Spezialbehandlung für einige klassen
                EntityType type =ent.getEntityType();
               switch (type){
                    case EntityType.EnemyBreeder:
                        Breeder bre = (Breeder)ent;
                        if (bre.ReadyToSpawn)
                        {
                            float alpha = (float) rand.NextDouble() * 360;
                            Breeder bre2 = new Breeder(bre.Position + (new Vec2f((float) (40 * Math.Cos(alpha)),(float) (40 *Math.Sin(alpha)))), 0, 1,new Vec2f(0,0),  SpaceLetters.Team.Evil, "");
                            tmp.Add(bre2);

                            bre.ReadyToSpawn = false;
                            Console.WriteLine("blob");
                        }

                        break;

                    default :
                        break;
                }
                

            }
            entities.AddRange(tmp);    

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
