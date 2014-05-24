using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceLetters
{
    class PSpawner
    {
        Vec2f position = new Vec2f();
        List<Particle> particles;

        float totalSpawnTime;

        private static Random random = new Random();

        public PSpawner(Vec2f position, float totalSpawnTime)
        {
            this.position = position;
            this.totalSpawnTime = totalSpawnTime;
            particles = new List<Particle>();

        }

        private void spawnParticles()
        {
            particles.Add(new Particle(position,888,new Vec2f((float)random.NextDouble()-0.5f,(float)random.NextDouble()-0.5f)));

        }

        public void update(GameTime gameTime)
        {
            totalSpawnTime -= (float)gameTime.ElapsedTime.TotalMilliseconds;

            if (totalSpawnTime > 0)
            {
                for (int i = 0; i < random.Next(2, 10); i++)
                    spawnParticles();
            }
            for (int i = particles.Count-1; i >= 0; i--)
            {
              particles[i].update(gameTime);
              if (particles[i].Dead)
                  particles.RemoveAt(i);
            }
            
        }

        public bool isSpawnerFinish()
        {
            return (totalSpawnTime <= 0 && particles.Count == 0);
        }

        public void draw(GameTime gameTime, SFML.Graphics.RenderWindow window)
        {
            foreach (Particle particle in particles)
            {
                particle.draw(gameTime, window);
            }
        }

    }
}
