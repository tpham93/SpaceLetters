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


            

            p_breeder  = 0.2f;
            p_kamikaze = 0.8f;
        }
        public Entity spawn(GameTime gameTime)
        {
            //if(rand.NextDouble()*0.91f *spawnVelocity *  Math.Max(1,gameTime.TotalTime.Minutes) > 1)
            //if(rand.NextDouble() < 0.003f)
            //if (rand.NextDouble() < 0.0025f + gameTime.TotalTime.Minutes/1000)
            //if (rand.NextDouble() < 0.0025f + (gameTime.TotalTime.TotalSeconds % 60)/1000)
            //if(  Math.Pow(gameTime.TotalTime.Minutes,2) * gameTime.TotalTime.Seconds + 0.99f< rand.NextDouble() * Math.Max(gameTime.TotalTime.Minutes,1)    )
            if (rand.NextDouble()/2 + (gameTime.TotalTime.TotalMinutes/60.0f) > 0.495f)
            {
                Entity e = null;
                float radius  = Math.Max(Game.WINDOWSIZE.X,Game.WINDOWSIZE.Y)/2 + 30;
                Vec2f ePosition = Game.WINDOWSIZE / 2 + (float)Math.Pow(-1,rand.Next(2))* new Vec2f((float)rand.NextDouble() + 0.001f,(float)rand.NextDouble() + 0.001f).normalized() * radius;
                Vec2f eVelocity = new Vec2f(0, 0);
                float w = (float) rand.NextDouble();
                if (p_breeder > w)
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
