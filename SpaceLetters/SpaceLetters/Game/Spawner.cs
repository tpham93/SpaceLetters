using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class Spawner
    {
        private Random rand;
        private Entity player;
        private float spawnVelocity;
        private float p_breeder,p_kamikaze;

        public float SpawnChancePerFrame
        {
            get { return spawnVelocity; }
            set { spawnVelocity = value; }
        }
        public Spawner(float spawnVelocity, Entity player)
        {
            rand = new Random();
            this.spawnVelocity = spawnVelocity;
            this.player = player;


            

            p_breeder  = 0.3f;
            p_kamikaze = 0.7f;
        }
        public Entity spawn(GameTime gameTime)
        {
            //if(rand.NextDouble()*0.91f *spawnVelocity *  Math.Max(1,gameTime.TotalTime.Minutes) > 1)
            //if(rand.NextDouble() < 0.003f)
            //if (rand.NextDouble() < 0.0025f + gameTime.TotalTime.Minutes/1000)
            if (rand.NextDouble() < 0.0025f + (gameTime.TotalTime.TotalSeconds % 60)/1000)
            {
                

                Console.WriteLine("Spawn  :"+gameTime.TotalTime.Minutes);

                Entity e = null;
                float radius  = Math.Max(Game.WINDOWSIZE.X,Game.WINDOWSIZE.Y)/2 + 30;
                Vec2f ePosition = Game.WINDOWSIZE / 2 + (float)Math.Pow(-1,rand.Next(2))* new Vec2f((float)rand.NextDouble() + 0.001f,(float)rand.NextDouble() + 0.001f).normalized() * radius;
                Vec2f eVelocity = new Vec2f(0, 0);
                //const int enemyTypeNum = 2;
                /*
                int typIndex = rand.Next(enemyTypeNum);
                switch(typIndex)
                {
                    case 0:
                        e = new Kamikaze(ePosition, 0.0f, eVelocity, "Kamikaze", player);
                        break;
                    case 1:
                        e = new Breeder(ePosition, 0.0f, new Vec2f(), "Breeder", player);
                        break;
                    default:
                        return null;
                }*/
                float w = (float) rand.NextDouble();
                if (p_breeder < w)
                {
                    e = new Breeder(ePosition, 0.0f, new Vec2f(), "Breeder", player);
                }
                else// wahrscheinlichkeit p_kamikaze
                {
                    e = new Kamikaze(ePosition, 0.0f, eVelocity, "Kamikaze", player);
                }


                e.loadContent();
                return e;
            }

            return null;
        }
    }
}
