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
        private float spawnChancePerFrame;

        public float SpawnChancePerFrame
        {
            get { return spawnChancePerFrame; }
            set { spawnChancePerFrame = value; }
        }
        public Spawner(float spawnChancePerFrame, Entity player)
        {
            rand = new Random();
            this.spawnChancePerFrame = spawnChancePerFrame;
            this.player = player;
        }
        public Entity spawn()
        {
            if(rand.NextDouble() <= spawnChancePerFrame)
            {
                Console.WriteLine("blah");
                Entity e = null;
                float radius  = Math.Max(Game.WINDOWSIZE.X,Game.WINDOWSIZE.Y)/2 + 30;
                Vec2f ePosition = Game.WINDOWSIZE / 2 + (float)Math.Pow(-1,rand.Next(2))* new Vec2f((float)rand.NextDouble() + 0.001f,(float)rand.NextDouble() + 0.001f).normalized() * radius;
                Vec2f eVelocity = new Vec2f(0, 0);
                const int enemyTypeNum = 2;
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
                        Console.WriteLine("missing enemy");
                        e = null;
                        break;
                }
                return e;
            }

            return null;
        }
    }
}
